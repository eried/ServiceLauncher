namespace ServiceLauncher
{
    partial class FormOptions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOptions));
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabelDetectServices = new System.Windows.Forms.LinkLabel();
            this.linkLabelAddService = new System.Windows.Forms.LinkLabel();
            this.linkLabelDeleteService = new System.Windows.Forms.LinkLabel();
            this.radioButtonAutomaticFull = new System.Windows.Forms.RadioButton();
            this.groupBoxStartMode = new System.Windows.Forms.GroupBox();
            this.linkLabelAllAutomatic = new System.Windows.Forms.LinkLabel();
            this.comboBoxSystemDefault = new System.Windows.Forms.ComboBox();
            this.radioButtonSystemDefault = new System.Windows.Forms.RadioButton();
            this.radioButtonAutomaticStart = new System.Windows.Forms.RadioButton();
            this.tabControlOptions = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.labelPath = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.comboBoxServices = new System.Windows.Forms.ComboBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.openFileDialogApplication = new System.Windows.Forms.OpenFileDialog();
            this.toolTipInfo = new System.Windows.Forms.ToolTip(this.components);
            this.groupBoxProgressDialog = new System.Windows.Forms.GroupBox();
            this.radioButtonProgressNever = new System.Windows.Forms.RadioButton();
            this.radioButtonProgressAlways = new System.Windows.Forms.RadioButton();
            this.radioButtonProgressNormal = new System.Windows.Forms.RadioButton();
            this.checkBoxLimitedLaunch = new System.Windows.Forms.CheckBox();
            this.textBoxApplication = new System.Windows.Forms.TextBox();
            this.groupBoxStartMode.SuspendLayout();
            this.tabControlOptions.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBoxProgressDialog.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "&Related services:";
            // 
            // linkLabelDetectServices
            // 
            this.linkLabelDetectServices.AutoSize = true;
            this.linkLabelDetectServices.Location = new System.Drawing.Point(13, 50);
            this.linkLabelDetectServices.Name = "linkLabelDetectServices";
            this.linkLabelDetectServices.Size = new System.Drawing.Size(145, 13);
            this.linkLabelDetectServices.TabIndex = 1;
            this.linkLabelDetectServices.TabStop = true;
            this.linkLabelDetectServices.Text = "Detect related services again";
            this.linkLabelDetectServices.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelDetectServices_LinkClicked);
            // 
            // linkLabelAddService
            // 
            this.linkLabelAddService.AutoSize = true;
            this.linkLabelAddService.Location = new System.Drawing.Point(13, 248);
            this.linkLabelAddService.Name = "linkLabelAddService";
            this.linkLabelAddService.Size = new System.Drawing.Size(121, 13);
            this.linkLabelAddService.TabIndex = 3;
            this.linkLabelAddService.TabStop = true;
            this.linkLabelAddService.Text = "Add services manually...";
            this.linkLabelAddService.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelAddService_LinkClicked);
            // 
            // linkLabelDeleteService
            // 
            this.linkLabelDeleteService.AutoSize = true;
            this.linkLabelDeleteService.Location = new System.Drawing.Point(13, 233);
            this.linkLabelDeleteService.Name = "linkLabelDeleteService";
            this.linkLabelDeleteService.Size = new System.Drawing.Size(153, 13);
            this.linkLabelDeleteService.TabIndex = 2;
            this.linkLabelDeleteService.TabStop = true;
            this.linkLabelDeleteService.Text = "Ignore current selected service";
            this.linkLabelDeleteService.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelDeleteService_LinkClicked);
            // 
            // radioButtonAutomaticFull
            // 
            this.radioButtonAutomaticFull.AutoSize = true;
            this.radioButtonAutomaticFull.Checked = true;
            this.radioButtonAutomaticFull.Location = new System.Drawing.Point(21, 26);
            this.radioButtonAutomaticFull.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonAutomaticFull.Name = "radioButtonAutomaticFull";
            this.radioButtonAutomaticFull.Size = new System.Drawing.Size(200, 17);
            this.radioButtonAutomaticFull.TabIndex = 0;
            this.radioButtonAutomaticFull.TabStop = true;
            this.radioButtonAutomaticFull.Text = "&Automatic Start/Stop (recommended)";
            this.toolTipInfo.SetToolTip(this.radioButtonAutomaticFull, "Service will be started at application launch and stopped automatically");
            this.radioButtonAutomaticFull.UseVisualStyleBackColor = true;
            this.radioButtonAutomaticFull.CheckedChanged += new System.EventHandler(this.radioButtonAutomaticFull_CheckedChanged);
            // 
            // groupBoxStartMode
            // 
            this.groupBoxStartMode.Controls.Add(this.linkLabelAllAutomatic);
            this.groupBoxStartMode.Controls.Add(this.comboBoxSystemDefault);
            this.groupBoxStartMode.Controls.Add(this.radioButtonSystemDefault);
            this.groupBoxStartMode.Controls.Add(this.radioButtonAutomaticStart);
            this.groupBoxStartMode.Controls.Add(this.radioButtonAutomaticFull);
            this.groupBoxStartMode.Enabled = false;
            this.groupBoxStartMode.Location = new System.Drawing.Point(15, 72);
            this.groupBoxStartMode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxStartMode.Name = "groupBoxStartMode";
            this.groupBoxStartMode.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxStartMode.Size = new System.Drawing.Size(298, 152);
            this.groupBoxStartMode.TabIndex = 6;
            this.groupBoxStartMode.TabStop = false;
            this.groupBoxStartMode.Text = "&Start mode";
            // 
            // linkLabelAllAutomatic
            // 
            this.linkLabelAllAutomatic.AutoSize = true;
            this.linkLabelAllAutomatic.Location = new System.Drawing.Point(42, 45);
            this.linkLabelAllAutomatic.Name = "linkLabelAllAutomatic";
            this.linkLabelAllAutomatic.Size = new System.Drawing.Size(183, 13);
            this.linkLabelAllAutomatic.TabIndex = 1;
            this.linkLabelAllAutomatic.TabStop = true;
            this.linkLabelAllAutomatic.Text = "Apply this configuration to all services";
            this.linkLabelAllAutomatic.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelAllAutomatic_LinkClicked);
            // 
            // comboBoxSystemDefault
            // 
            this.comboBoxSystemDefault.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSystemDefault.FormattingEnabled = true;
            this.comboBoxSystemDefault.Items.AddRange(new object[] {
            "Automatic",
            "Automatic (delayed)",
            "Manual",
            "Disabled"});
            this.comboBoxSystemDefault.Location = new System.Drawing.Point(45, 117);
            this.comboBoxSystemDefault.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxSystemDefault.Name = "comboBoxSystemDefault";
            this.comboBoxSystemDefault.Size = new System.Drawing.Size(175, 21);
            this.comboBoxSystemDefault.TabIndex = 4;
            this.comboBoxSystemDefault.SelectedIndexChanged += new System.EventHandler(this.comboBoxSystemDefault_SelectedIndexChanged);
            // 
            // radioButtonSystemDefault
            // 
            this.radioButtonSystemDefault.AutoSize = true;
            this.radioButtonSystemDefault.Location = new System.Drawing.Point(21, 96);
            this.radioButtonSystemDefault.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonSystemDefault.Name = "radioButtonSystemDefault";
            this.radioButtonSystemDefault.Size = new System.Drawing.Size(97, 17);
            this.radioButtonSystemDefault.TabIndex = 3;
            this.radioButtonSystemDefault.Text = "System &default:";
            this.toolTipInfo.SetToolTip(this.radioButtonSystemDefault, "Service will use a system default start mode");
            this.radioButtonSystemDefault.UseVisualStyleBackColor = true;
            this.radioButtonSystemDefault.CheckedChanged += new System.EventHandler(this.radioButtonSystemDefault_CheckedChanged);
            // 
            // radioButtonAutomaticStart
            // 
            this.radioButtonAutomaticStart.AutoSize = true;
            this.radioButtonAutomaticStart.Location = new System.Drawing.Point(21, 67);
            this.radioButtonAutomaticStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonAutomaticStart.Name = "radioButtonAutomaticStart";
            this.radioButtonAutomaticStart.Size = new System.Drawing.Size(97, 17);
            this.radioButtonAutomaticStart.TabIndex = 2;
            this.radioButtonAutomaticStart.Text = "Automatic &Start";
            this.toolTipInfo.SetToolTip(this.radioButtonAutomaticStart, "Service will be started at application launch, but not stopped");
            this.radioButtonAutomaticStart.UseVisualStyleBackColor = true;
            this.radioButtonAutomaticStart.CheckedChanged += new System.EventHandler(this.radioButtonAutomatic_CheckedChanged);
            // 
            // tabControlOptions
            // 
            this.tabControlOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlOptions.Controls.Add(this.tabPage1);
            this.tabControlOptions.Controls.Add(this.tabPage2);
            this.tabControlOptions.Location = new System.Drawing.Point(10, 9);
            this.tabControlOptions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControlOptions.Name = "tabControlOptions";
            this.tabControlOptions.SelectedIndex = 0;
            this.tabControlOptions.Size = new System.Drawing.Size(338, 430);
            this.tabControlOptions.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBoxProgressDialog);
            this.tabPage1.Controls.Add(this.checkBoxLimitedLaunch);
            this.tabPage1.Controls.Add(this.textBoxApplication);
            this.tabPage1.Controls.Add(this.buttonBrowse);
            this.tabPage1.Controls.Add(this.labelPath);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(330, 404);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(254, 25);
            this.buttonBrowse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(64, 24);
            this.buttonBrowse.TabIndex = 0;
            this.buttonBrowse.Text = "&Browse...";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.Location = new System.Drawing.Point(13, 13);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(109, 13);
            this.labelPath.TabIndex = 1;
            this.labelPath.Text = "&Application to launch:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.comboBoxServices);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.linkLabelDetectServices);
            this.tabPage2.Controls.Add(this.groupBoxStartMode);
            this.tabPage2.Controls.Add(this.linkLabelAddService);
            this.tabPage2.Controls.Add(this.linkLabelDeleteService);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(330, 404);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Services";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // comboBoxServices
            // 
            this.comboBoxServices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxServices.FormattingEnabled = true;
            this.comboBoxServices.Items.AddRange(new object[] {
            "Automatic",
            "Automatic (delayed)",
            "Manual",
            "Disabled"});
            this.comboBoxServices.Location = new System.Drawing.Point(15, 29);
            this.comboBoxServices.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxServices.Name = "comboBoxServices";
            this.comboBoxServices.Size = new System.Drawing.Size(298, 21);
            this.comboBoxServices.TabIndex = 0;
            this.comboBoxServices.SelectedIndexChanged += new System.EventHandler(this.comboBoxServices_SelectedIndexChanged);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(284, 443);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(64, 24);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSave.Location = new System.Drawing.Point(214, 443);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(64, 24);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "&Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // groupBoxProgressDialog
            // 
            this.groupBoxProgressDialog.Controls.Add(this.radioButtonProgressNever);
            this.groupBoxProgressDialog.Controls.Add(this.radioButtonProgressAlways);
            this.groupBoxProgressDialog.Controls.Add(this.radioButtonProgressNormal);
            this.groupBoxProgressDialog.Location = new System.Drawing.Point(16, 83);
            this.groupBoxProgressDialog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxProgressDialog.Name = "groupBoxProgressDialog";
            this.groupBoxProgressDialog.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxProgressDialog.Size = new System.Drawing.Size(298, 101);
            this.groupBoxProgressDialog.TabIndex = 7;
            this.groupBoxProgressDialog.TabStop = false;
            this.groupBoxProgressDialog.Text = "Show the &progress dialog when";
            // 
            // radioButtonProgressNever
            // 
            this.radioButtonProgressNever.AutoSize = true;
            this.radioButtonProgressNever.Location = new System.Drawing.Point(21, 68);
            this.radioButtonProgressNever.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonProgressNever.Name = "radioButtonProgressNever";
            this.radioButtonProgressNever.Size = new System.Drawing.Size(143, 17);
            this.radioButtonProgressNever.TabIndex = 3;
            this.radioButtonProgressNever.Text = "Never show the progress";
            this.toolTipInfo.SetToolTip(this.radioButtonProgressNever, "Service will use a system default start mode");
            this.radioButtonProgressNever.UseVisualStyleBackColor = true;
            // 
            // radioButtonProgressAlways
            // 
            this.radioButtonProgressAlways.AutoSize = true;
            this.radioButtonProgressAlways.Location = new System.Drawing.Point(21, 47);
            this.radioButtonProgressAlways.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonProgressAlways.Name = "radioButtonProgressAlways";
            this.radioButtonProgressAlways.Size = new System.Drawing.Size(147, 17);
            this.radioButtonProgressAlways.TabIndex = 2;
            this.radioButtonProgressAlways.Text = "Always show the progress";
            this.toolTipInfo.SetToolTip(this.radioButtonProgressAlways, "Service will be started at application launch, but not stopped");
            this.radioButtonProgressAlways.UseVisualStyleBackColor = true;
            // 
            // radioButtonProgressNormal
            // 
            this.radioButtonProgressNormal.AutoSize = true;
            this.radioButtonProgressNormal.Checked = true;
            this.radioButtonProgressNormal.Location = new System.Drawing.Point(21, 26);
            this.radioButtonProgressNormal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonProgressNormal.Name = "radioButtonProgressNormal";
            this.radioButtonProgressNormal.Size = new System.Drawing.Size(218, 17);
            this.radioButtonProgressNormal.TabIndex = 0;
            this.radioButtonProgressNormal.TabStop = true;
            this.radioButtonProgressNormal.Text = "&Application/services are taking too much";
            this.toolTipInfo.SetToolTip(this.radioButtonProgressNormal, "Service will be started at application launch and stopped automatically");
            this.radioButtonProgressNormal.UseVisualStyleBackColor = true;
            // 
            // checkBoxLimitedLaunch
            // 
            this.checkBoxLimitedLaunch.AutoSize = true;
            this.checkBoxLimitedLaunch.Checked = global::ServiceLauncher.Properties.Settings.Default.launch_limited;
            this.checkBoxLimitedLaunch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxLimitedLaunch.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ServiceLauncher.Properties.Settings.Default, "launch_limited", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxLimitedLaunch.Location = new System.Drawing.Point(16, 52);
            this.checkBoxLimitedLaunch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxLimitedLaunch.Name = "checkBoxLimitedLaunch";
            this.checkBoxLimitedLaunch.Size = new System.Drawing.Size(194, 17);
            this.checkBoxLimitedLaunch.TabIndex = 1;
            this.checkBoxLimitedLaunch.Text = "&Launch application as a limited user";
            this.checkBoxLimitedLaunch.UseVisualStyleBackColor = true;
            // 
            // textBoxApplication
            // 
            this.textBoxApplication.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ServiceLauncher.Properties.Settings.Default, "application_path", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxApplication.Location = new System.Drawing.Point(16, 28);
            this.textBoxApplication.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxApplication.Name = "textBoxApplication";
            this.textBoxApplication.ReadOnly = true;
            this.textBoxApplication.Size = new System.Drawing.Size(232, 20);
            this.textBoxApplication.TabIndex = 3;
            this.textBoxApplication.Text = global::ServiceLauncher.Properties.Settings.Default.application_path;
            // 
            // FormOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 478);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.tabControlOptions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormOptions";
            this.Text = "Configuration";
            this.Load += new System.EventHandler(this.FormOptions_Load);
            this.groupBoxStartMode.ResumeLayout(false);
            this.groupBoxStartMode.PerformLayout();
            this.tabControlOptions.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBoxProgressDialog.ResumeLayout(false);
            this.groupBoxProgressDialog.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabelDetectServices;
        private System.Windows.Forms.LinkLabel linkLabelAddService;
        private System.Windows.Forms.LinkLabel linkLabelDeleteService;
        private System.Windows.Forms.RadioButton radioButtonAutomaticFull;
        private System.Windows.Forms.GroupBox groupBoxStartMode;
        private System.Windows.Forms.ComboBox comboBoxSystemDefault;
        private System.Windows.Forms.RadioButton radioButtonSystemDefault;
        private System.Windows.Forms.RadioButton radioButtonAutomaticStart;
        private System.Windows.Forms.TabControl tabControlOptions;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox textBoxApplication;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox comboBoxServices;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.OpenFileDialog openFileDialogApplication;
        private System.Windows.Forms.LinkLabel linkLabelAllAutomatic;
        private System.Windows.Forms.ToolTip toolTipInfo;
        private System.Windows.Forms.CheckBox checkBoxLimitedLaunch;
        private System.Windows.Forms.GroupBox groupBoxProgressDialog;
        private System.Windows.Forms.RadioButton radioButtonProgressNever;
        private System.Windows.Forms.RadioButton radioButtonProgressAlways;
        private System.Windows.Forms.RadioButton radioButtonProgressNormal;
    }
}