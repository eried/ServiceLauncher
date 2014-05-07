using ServiceLauncher.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ServiceLauncher
{
    public partial class FormMain : Form
    {
        private RelatedServicesManager _services;
        private readonly XmlSerializer _serializer;
        private readonly FormOptions _programOptions; 
        private ProgramStepStatus _currentStep;
        private Boolean _programNotConfigured, _waitingForSettings;

        public FormMain()
        {
            _currentStep = ProgramStepStatus.JustStarted;
            _waitingForSettings = false;
            _programNotConfigured = false;
            _services = new RelatedServicesManager();
            _serializer = new XmlSerializer(typeof(List<RelatedService>));
            _programOptions = new FormOptions(_services);

            if (Settings.Default.launcher_services.Length == 0)
            {
                _services.AddRelatedServices(Settings.Default.launcher_related_keyword);

                SaveServiceSettings();
                Settings.Default.Save();
            }
            else
            {
                LoadServiceSettings();
            }
 
            InitializeComponent();

            // Cargar la configuración
            Text = Settings.Default.launcher_main_title;
            _programOptions.Text = Settings.Default.launcher_config_title;
            notifyIconTray.Text = Settings.Default.launcher_tray_title;
        }

        /// <summary>
        /// Guarda la configuración, la lista de servicios es serializada
        /// </summary>
        private void SaveServiceSettings()
        {
            var s = new StringWriter();
            _serializer.Serialize(s, _services.Services);

            Settings.Default.launcher_services = s.ToString();
        }

        /// <summary>
        /// Restaura la configuración
        /// </summary>
        private void LoadServiceSettings()
        {
            var s = new StringReader(Settings.Default.launcher_services);
            _services.Services = (List<RelatedService>)_serializer.Deserialize(s);
        }

        internal void FormLoad()
        {
            if (Settings.Default.launcher_tray_icon.Length > 0)
                try
                {
                    notifyIconTray.Icon = new Icon(Settings.Default.launcher_tray_icon);
                }
                catch { }

            notifyIconTray.Visible = Settings.Default.trayicon_enable;

            if (Settings.Default.application_path.Length > 0)
            {
                progressBarStart.Style = ProgressBarStyle.Marquee;

                // Inicio del programa
                timerStartup.Start();
            }
            else
            {
                // No hay configuración , entonces mostrar opciones
                _programNotConfigured = true;

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
            labelStatus.Text = "Starting services...";
            _currentStep = ProgramStepStatus.StartingServices;

            timerCheckStart.Start();
            UseWaitCursor = true;
            backgroundWorkerStart.RunWorkerAsync();
        }

        private void showProgress()
        {
            if (!Settings.Default.hide_progress)
            {
                CenterToScreen();

                Show();
                Focus();

                progressBarStart.Style = ProgressBarStyle.Marquee;
            }
        }

        private void hideProgress()
        {
            Focus();
            Hide();

            progressBarStart.Style = ProgressBarStyle.Blocks;
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
            if (!_waitingForSettings)
            {
                _programOptions.LoadSettings();

                _waitingForSettings = true;

                if (_programNotConfigured)
                    Hide();

                if (Settings.Default.launcher_wizard && _programNotConfigured)
                {
                    // Mostrar el diálogo para elegir el programa
                    Settings.Default.application_path = _programOptions.ShowBrowseForApplication();
                    Settings.Default.Save();

                    if (Settings.Default.application_path.Length > 0)
                        RelaunchMe();
                }
                else
                    if (_programOptions.ShowDialog() == DialogResult.OK)
                    {
                        // Guardar la nueva configuración
                        _services = _programOptions.Services;
                        _services.UpdateSystemConfiguration();
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
                if (_programNotConfigured)
                    ExitApplication();

                _waitingForSettings = false;
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
            _currentStep = ProgramStepStatus.Exiting;
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
            _services.SystemStart(backgroundWorkerStart);
        }

        private void backgroundWorkerStart_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _currentStep = ProgramStepStatus.WaitingApplication;
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
            _currentStep = ProgramStepStatus.StoppingServices;

            this.timerCheckStop.Start();
            backgroundWorkerStop.RunWorkerAsync();
        }

        private void backgroundWorkerStop_DoWork(object sender, DoWorkEventArgs e)
        {
            _services.SystemStop(backgroundWorkerStop);
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

                n = (int)Math.Ceiling(progress / (double)(100 / _services.Services.Count));
            }
            return GetNameOrId(_services.Services[n]);
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
            if (_currentStep == ProgramStepStatus.StartingServices)
                showProgress();
        }

        private void timerCheckStop_Tick(object sender, EventArgs e)
        {
            timerCheckStop.Stop();

            // Comprobar si debería mostrarse la marquesina de progreso
            if (_currentStep == ProgramStepStatus.StoppingServices)
                showProgress();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_currentStep != ProgramStepStatus.Exiting)
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
