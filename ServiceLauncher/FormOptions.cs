using System;
using System.Windows.Forms;
using ServiceLauncher.Properties;

namespace ServiceLauncher
{
    public partial class FormOptions : Form
    {
        private readonly RelatedServicesManager _services;

        public FormOptions(RelatedServicesManager services)
        {
            _services = services;
            InitializeComponent();
        }

        internal RelatedServicesManager Services
        {
            get { return _services; }
        }

        private void UpdateServices()
        {
            comboBoxServices.Items.Clear();

            foreach (RelatedService s in _services.Services)
                comboBoxServices.Items.Add(s.Name);

            GuiMode(comboBoxServices.Items.Count > 0);
        }

        private void GuiMode(bool hasServices)
        {
            if (hasServices)
                comboBoxServices.SelectedIndex = 0;

            groupBoxStartMode.Enabled = hasServices;
            linkLabelDeleteService.Enabled = hasServices;
            comboBoxServices.Enabled = hasServices;
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            textBoxApplication.Text = ShowBrowseForApplication();
        }

        internal String ShowBrowseForApplication()
        {
            if (openFileDialogApplication.ShowDialog() == DialogResult.OK)
                return openFileDialogApplication.FileName;
            return "";
        }

        private void comboBoxSystemDefault_SelectedIndexChanged(object sender, EventArgs e)
        {
            radioButtonSystemDefault.Checked = true;
            SaveServiceConfigurationOptions();
        }

        private void radioButtonAutomatic_CheckedChanged(object sender, EventArgs e)
        {
            SaveServiceConfigurationOptions();
        }

        private void FormOptions_Load(object sender, EventArgs e)
        {
            UpdateServices();
        }

        internal void LoadSettings()
        {
            labelPath.Text = Settings.Default.application_path_label;
            openFileDialogApplication.Title = Settings.Default.application_path_title;
            openFileDialogApplication.Filter = Settings.Default.application_path_filter;
            openFileDialogApplication.FileName = Settings.Default.application_path_filename;
            linkLabelAddService.Visible = Settings.Default.services_add_allow;
            linkLabelDeleteService.Visible = Settings.Default.services_delete_allow;
            linkLabelDetectServices.Visible = Settings.Default.launcher_related_keyword.Trim().Length > 0;
            comboBoxSystemDefault.SelectedIndex = 0;

            radioButtonProgressNormal.Checked = Settings.Default.hide_progress == false &&
                                                Settings.Default.show_progress == false;
            radioButtonProgressAlways.Checked = Settings.Default.hide_progress == false &&
                                                Settings.Default.show_progress;
            radioButtonProgressNever.Checked = Settings.Default.hide_progress && Settings.Default.show_progress == false;
        }

        private void comboBoxServices_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateServiceConfigurationOptions(GetSelectedService());
        }

        private RelatedService GetSelectedService()
        {
            return _services.Services[comboBoxServices.SelectedIndex];
        }

        private void UpdateServiceConfigurationOptions(RelatedService r)
        {
            bool systemMode = false;
            groupBoxStartMode.Enabled = true;

            switch (r.Mode)
            {
                case CustomStartMode.StartStop:
                    radioButtonAutomaticFull.Checked = true;
                    break;

                case CustomStartMode.StartOnly:
                    radioButtonAutomaticStart.Checked = true;
                    break;

                case CustomStartMode.Unknown:
                    groupBoxStartMode.Enabled = false;
                    break;

                default:
                    systemMode = true;
                    break;
            }

            if (!systemMode) return;

            switch (r.Mode)
            {
                case CustomStartMode.SystemAutomatic:
                    comboBoxSystemDefault.SelectedIndex = 0;
                    break;

                case CustomStartMode.SystemAutomaticDelayed:
                    comboBoxSystemDefault.SelectedIndex = 1;
                    break;

                case CustomStartMode.SystemManual:
                    comboBoxSystemDefault.SelectedIndex = 2;
                    break;

                case CustomStartMode.SystemDisabled:
                    comboBoxSystemDefault.SelectedIndex = 3;
                    break;
            }

            radioButtonSystemDefault.Checked = true;
        }

        private void radioButtonAutomaticFull_CheckedChanged(object sender, EventArgs e)
        {
            SaveServiceConfigurationOptions();
        }

        private void SaveServiceConfigurationOptions()
        {
            if (comboBoxServices.SelectedIndex != -1)
                _services.Services[comboBoxServices.SelectedIndex].Mode = GetSelectedServiceConfiguration();
        }

        private CustomStartMode GetSelectedServiceConfiguration()
        {
            if (groupBoxStartMode.Enabled)
            {
                if (radioButtonAutomaticFull.Checked)
                    return CustomStartMode.StartStop;

                if (radioButtonAutomaticStart.Checked)
                    return CustomStartMode.StartOnly;

                if (radioButtonSystemDefault.Checked)
                {
                    switch (comboBoxSystemDefault.SelectedIndex)
                    {
                        case 0:
                            return CustomStartMode.SystemAutomatic;

                        case 1:
                            return CustomStartMode.SystemAutomaticDelayed;

                        case 2:
                            return CustomStartMode.SystemManual;

                        case 3:
                            return CustomStartMode.SystemDisabled;
                    }
                }
            }

            return CustomStartMode.Unknown;
        }

        private void radioButtonSystemDefault_CheckedChanged(object sender, EventArgs e)
        {
            SaveServiceConfigurationOptions();
        }

        private void linkLabelDetectServices_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bool detectServices = false;

            if (_services.Services.Count > 0)
            {
                if (MessageBox.Show("This will replace all your current configuration. Do you want to continue?",
                    "Detect related services", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _services.Services.Clear();
                    detectServices = true;
                }
            }
            else
                detectServices = true;

            if (detectServices)
            {
                _services.AddRelatedServices(Settings.Default.launcher_related_keyword);

                UpdateServices();
            }
        }

        private void linkLabelDeleteService_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Settings.Default.services_delete_allow)
                if (comboBoxServices.SelectedIndex >= 0)
                {
                    _services.Services.RemoveAt(comboBoxServices.SelectedIndex);

                    UpdateServices();
                }
        }

        private void linkLabelAllAutomatic_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("This will replace all your current configuration. Do you want to continue?",
                "Apply configuration", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (RelatedService s in _services.Services)
                    s.Mode = CustomStartMode.StartStop;

                UpdateServices();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Settings.Default.hide_progress = radioButtonProgressNever.Checked;
            Settings.Default.show_progress = radioButtonProgressAlways.Checked;

            Settings.Default.Save();
        }

        private void linkLabelAddService_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowAddServices();
        }

        private void ShowAddServices()
        {
            if (Settings.Default.services_add_allow)
            {
                var f = new FormAddServices(_services);

                if (f.ShowDialog() == DialogResult.OK)
                {
                    _services.Add(f.ServicesToAdd);
                    UpdateServices();
                }
            }
        }
    }
}