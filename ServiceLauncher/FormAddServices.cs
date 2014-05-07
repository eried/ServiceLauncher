using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceProcess;
using ServiceLauncher.Properties;

namespace ServiceLauncher
{
    public partial class FormAddServices : Form
    {
        private string _lastSearch = "", _currentSearch = "";
        private List<ServiceController> _foundServices;
        private readonly RelatedServicesManager _services;

        public FormAddServices(RelatedServicesManager services)
        {
            _services = services;

            InitializeComponent();
        }

        private void textBoxKeyword_TextChanged(object sender, EventArgs e)
        {
            timerSearch.Stop();
            timerSearch.Start();
        }

        private void timerSearch_Tick(object sender, EventArgs e)
        {
            timerSearch.Stop();
            _currentSearch = textBoxKeyword.Text.Trim();

            if (_lastSearch.CompareTo(_currentSearch) == 0) return;

            _lastSearch = _currentSearch;
            listBoxResults.Items.Clear();

            _foundServices = _services.GetRelatedServices(_currentSearch);

            foreach (var s in _foundServices)
                listBoxResults.Items.Add(String.Format("{0} ({1})", s.DisplayName, s.ServiceName));
        }

        private void FormAddServices_Load(object sender, EventArgs e)
        {
            Text = Settings.Default.services_add_title;
            textBoxKeyword.Focus();
        }

        internal List<ServiceController> ServicesToAdd
        {
            get
            {
                return _foundServices;
            }
        }
    }
}
