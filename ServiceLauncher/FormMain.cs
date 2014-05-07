using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ServiceLauncher.Properties;
using System.Xml.Serialization;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ServiceLauncher
{
    public partial class FormMain : Form
    {
        RelatedServicesManager services; XmlSerializer serializer;
        FormOptions programOptions; ProgramStepStatus currentStep;
        Boolean programNotConfigured, waitingForSettings;

        public FormMain()
        {
            currentStep = ProgramStepStatus.JustStarted;
            waitingForSettings = false;
            programNotConfigured = false;
            services = new RelatedServicesManager();
            serializer = new XmlSerializer(typeof(List<RelatedService>));
            programOptions = new FormOptions(services);

            if (Settings.Default.launcher_services.Length == 0)
            {
                services.AddRelatedServices(Settings.Default.launcher_related_keyword);

                SaveServiceSettings();
                Settings.Default.Save();
            }
            else
            {
                LoadServiceSettings();
            }
 
            InitializeComponent();

            // Cargar la configuración
            this.Text = Settings.Default.launcher_main_title;
            programOptions.Text = Settings.Default.launcher_config_title;
            this.notifyIconTray.Text = Settings.Default.launcher_tray_title;
        }

        /// <summary>
        /// Guarda la configuración, la lista de servicios es serializada
        /// </summary>
        private void SaveServiceSettings()
        {
            StringWriter s = new StringWriter();
            serializer.Serialize(s, services.Services);

            Settings.Default.launcher_services = s.ToString();
        }

        /// <summary>
        /// Restaura la configuración
        /// </summary>
        private void LoadServiceSettings()
        {
            StringReader s = new StringReader(Settings.Default.launcher_services);
            services.Services = (List<RelatedService>)serializer.Deserialize(s);
        }

        internal void FormLoad()
        {
            if (Settings.Default.launcher_tray_icon.Length > 0)
                try
                {
                    this.notifyIconTray.Icon = new Icon(Settings.Default.launcher_tray_icon);
                }
                catch { }

            this.notifyIconTray.Visible = Settings.Default.trayicon_enable;

            if (Settings.Default.application_path.Length > 0)
            {
                progressBarStart.Style = ProgressBarStyle.Marquee;

                // Inicio del programa
                timerStartup.Start();
            }
            else
            {
                // No hay configuración , entonces mostrar opciones
                programNotConfigured = true;

                ShowOptions();
            }
        }

        private void timerStartup_Tick(object sender, EventArgs e)
        {
            timerStartup.Stop();
            StartLauncher();
        }

        private void StartLauncher()
        {
            this.labelStatus.Text = "Starting services...";
            currentStep = ProgramStepStatus.StartingServices;

            timerCheckStart.Start();
            this.UseWaitCursor = true;
            backgroundWorkerStart.RunWorkerAsync();
        }

        private void showProgress()
        {
            if (!Settings.Default.hide_progress)
            {
                CenterToScreen();

                this.Show();
                this.Focus();

                progressBarStart.Style = ProgressBarStyle.Marquee;
            }
        }

        private void hideProgress()
        {
            this.Focus();
            this.Hide();

            this.progressBarStart.Style = ProgressBarStyle.Blocks;
        }

        private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowOptions();
        }

        /// <summary>
        /// Despliega las opciones del programa
        /// </summary>
        private void ShowOptions()
        {
            // Evitar que sea lanzado por diferentes threads
            if (!waitingForSettings)
            {
                programOptions.LoadSettings();

                waitingForSettings = true;

                if (programNotConfigured)
                    this.Hide();

                if (Settings.Default.launcher_wizard && programNotConfigured)
                {
                    // Mostrar el diálogo para elegir el programa
                    Settings.Default.application_path = programOptions.ShowBrowseForApplication();
                    Settings.Default.Save();

                    if (Settings.Default.application_path.Length > 0)
                        RelaunchMe();
                }
                else
                    if (programOptions.ShowDialog() == DialogResult.OK)
                    {
                        // Guardar la nueva configuración
                        this.services = programOptions.Services;
                        this.services.UpdateSystemConfiguration();
                        SaveServiceSettings();
                        Settings.Default.Save();
                    }
                    else
                    {
                        // Restaurar la configuración anterior
                        LoadServiceSettings();
                        Settings.Default.Reload();
                    }

                // Si no hay un programa a ejecutar, entonces se finaliza
                if (programNotConfigured)
                    ExitApplication();

                waitingForSettings = false;
            }
        }

        /// <summary>
        /// Vuelve a lanzar el programa actual
        /// </summary>
        private void RelaunchMe()
        {
            try
            {
                Process.Start(Process.GetCurrentProcess().MainModule.FileName);
            }
            catch { }
        }

        private void ExitApplication()
        {
            currentStep = ProgramStepStatus.Exiting;
            notifyIconTray.Visible = false;
            Application.Exit();
        }

        private void notifyIconTray_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowOptions();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }

        #region "Código principal"

        private void backgroundWorkerStart_DoWork(object sender, DoWorkEventArgs e)
        {
            services.SystemStart(backgroundWorkerStart);
        }

        private void backgroundWorkerStart_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            currentStep = ProgramStepStatus.WaitingApplication;
            hideProgress();

            backgroundWorkerWait.RunWorkerAsync();
        }

        private static T[] SubArray<T>(T[] data, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }

        private void backgroundWorkerWait_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Process p;

                String args = "";
                if (Environment.GetCommandLineArgs().Length > 0)
                {
                    var argsArray = Environment.GetCommandLineArgs();
                    args = String.Join(" ", SubArray(argsArray, 1, argsArray.Length-1));
                }

                if (Settings.Default.launch_limited)
                {
                    int processId = SaferProcess.CreateSaferProcess(Settings.Default.application_path,
                        args, SaferLevel.NormalUser);

                    p = Process.GetProcessById(processId);
                }
                else
                {
                    // Lanzar la aplicación y esperar
                    p = new Process();
                    p.StartInfo.FileName = Settings.Default.application_path;
                    p.StartInfo.Arguments = args;

                    p.Start();
                }

                p.WaitForExit();
            }
            catch
            {
                // Error en el programa
                Settings.Default.application_path = "";
                Settings.Default.Save();

                RelaunchMe();
            }
        }

        private void backgroundWorkerWait_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.labelStatus.Text = "Stopping services...";
            currentStep = ProgramStepStatus.StoppingServices;

            this.timerCheckStop.Start();
            backgroundWorkerStop.RunWorkerAsync();
        }

        private void backgroundWorkerStop_DoWork(object sender, DoWorkEventArgs e)
        {
            services.SystemStop(backgroundWorkerStop);
        }

        private void backgroundWorkerStop_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ExitApplication();
        }

        #endregion

        #region "Actualizaciones del progreso"

        private void backgroundWorkerStart_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            UpdateProgressStatus("Starting {0}...", e.ProgressPercentage);
        }

        private void UpdateProgressStatus(String format, int progress)
        {
            this.labelStatus.Text = String.Format(format,
                GetServiceNameByProgress(progress));
        }

        private string TruncateText(string p, int length)
        {
            if (p.Length < length)
                return p;
            else
                return p.Substring(0, p.Length - 3) + "...";
        }

        private string GetServiceNameByProgress(int progress)
        {
            int n = 0;

            if (progress > 0)
            {
                if (progress > 100)
                    progress = 100;

                n = (int)Math.Ceiling(progress / (double)(100 / services.Services.Count));
            }
            return GetNameOrId(services.Services[n]);
        }

        private string GetNameOrId(RelatedService relatedService)
        {
            if (relatedService.Name.Trim().Length == 0)
                return relatedService.Id;
            return relatedService.Name;
        }

        private void backgroundWorkerStop_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            UpdateProgressStatus("Stopping {0}...", e.ProgressPercentage);
        }
        #endregion

        private void timerCheckStart_Tick(object sender, EventArgs e)
        {
            timerCheckStart.Stop();

            // Comprobar si debería mostrarse la marquesina de progreso
            if (currentStep == ProgramStepStatus.StartingServices)
                showProgress();
        }

        private void timerCheckStop_Tick(object sender, EventArgs e)
        {
            timerCheckStop.Stop();

            // Comprobar si debería mostrarse la marquesina de progreso
            if (currentStep == ProgramStepStatus.StoppingServices)
                showProgress();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (currentStep != ProgramStepStatus.Exiting)
            {
                notifyIconTray.Visible = false;
                e.Cancel = true;
            }
        }

        private void hideIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIconTray.Visible = false;
        }
    }

    /// <summary>
    /// Estado del programa
    /// </summary>
    enum ProgramStepStatus
    {
        JustStarted,
        StartingServices,
        WaitingApplication,
        StoppingServices,
        Exiting
    }
}
