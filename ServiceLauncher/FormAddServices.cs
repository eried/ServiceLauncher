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
        private string lastSearch = "", currentSearch = "";
        private List<ServiceController> _foundServices;
        private RelatedServicesManager _services;

        public FormAddServices(RelatedServicesManager _services)
        {
            this._services = _services;

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
            currentSearch = this.textBoxKeyword.Text.Trim();

            if (lastSearch.CompareTo(currentSearch) != 0)
            {
                lastSearch = currentSearch;
                listBoxResults.Items.Clear();

                _foundServices = _services.GetRelatedServices(currentSearch);

                foreach (ServiceController s in _foundServices)
                    listBoxResults.Items.Add(String.Format("{0} ({1})", s.DisplayName, s.ServiceName));
            }
        }

        private void FormAddServices_Load(object sender, EventArgs e)
        {
            this.Text = Settings.Default.services_add_title;
            this.textBoxKeyword.Focus();
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
