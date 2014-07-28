namespace ServiceLauncher
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.progressBarStart = new System.Windows.Forms.ProgressBar();
            this.labelStatus = new System.Windows.Forms.Label();
            this.notifyIconTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.hideIconToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerStartup = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorkerStart = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerWait = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerStop = new System.ComponentModel.BackgroundWorker();
            this.timerCheckStart = new System.Windows.Forms.Timer(this.components);
            this.timerCheckStop = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStripTray.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBarStart
            // 
            this.progressBarStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarStart.Location = new System.Drawing.Point(12, 8);
            this.progressBarStart.Name = "progressBarStart";
            this.progressBarStart.Size = new System.Drawing.Size(312, 23);
            this.progressBarStart.TabIndex = 0;
            // 
            // labelStatus
            // 
            this.labelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelStatus.Location = new System.Drawing.Point(9, 34);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(325, 18);
            this.labelStatus.TabIndex = 1;
            this.labelStatus.Text = "Demo";
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // notifyIconTray
            // 
            this.notifyIconTray.ContextMenuStrip = this.contextMenuStripTray;
            this.notifyIconTray.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconTray.Icon")));
            this.notifyIconTray.Text = "notifyIcon1";
            this.notifyIconTray.Visible = true;
            this.notifyIconTray.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconTray_MouseDoubleClick);
            // 
            // contextMenuStripTray
            // 
            this.contextMenuStripTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configurationToolStripMenuItem,
            this.toolStripMenuItem2,
            this.hideIconToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStripTray.Name = "contextMenuStripTray";
            this.contextMenuStripTray.Size = new System.Drawing.Size(151, 76);
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.configurationToolStripMenuItem.Text = "Configuration";
            this.configurationToolStripMenuItem.Click += new System.EventHandler(this.configurationToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(147, 6);
            // 
            // hideIconToolStripMenuItem
            // 
            this.hideIconToolStripMenuItem.Name = "hideIconToolStripMenuItem";
            this.hideIconToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.hideIconToolStripMenuItem.Text = "Hide icon";
            this.hideIconToolStripMenuItem.Click += new System.EventHandler(this.hideIconToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // timerStartup
            // 
            this.timerStartup.Interval = 10;
            this.timerStartup.Tick += new System.EventHandler(this.timerStartup_Tick);
            // 
            // backgroundWorkerStart
            // 
            this.backgroundWorkerStart.WorkerReportsProgress = true;
            this.backgroundWorkerStart.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerStart_DoWork);
            this.backgroundWorkerStart.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerStart_ProgressChanged);
            this.backgroundWorkerStart.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerStart_RunWorkerCompleted);
            // 
            // backgroundWorkerWait
            // 
            this.backgroundWorkerWait.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerWait_DoWork);
            this.backgroundWorkerWait.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerWait_RunWorkerCompleted);
            // 
            // backgroundWorkerStop
            // 
            this.backgroundWorkerStop.WorkerReportsProgress = true;
            this.backgroundWorkerStop.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerStop_DoWork);
            this.backgroundWorkerStop.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerStop_ProgressChanged);
            this.backgroundWorkerStop.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerStop_RunWorkerCompleted);
            // 
            // timerCheckStart
            // 
            this.timerCheckStart.Interval = 1000;
            this.timerCheckStart.Tick += new System.EventHandler(this.timerCheckStart_Tick);
            // 
            // timerCheckStop
            // 
            this.timerCheckStop.Interval = 1500;
            this.timerCheckStop.Tick += new System.EventHandler(this.timerCheckStop_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 61);
            this.ControlBox = false;
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.progressBarStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Launcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.contextMenuStripTray.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBarStart;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.NotifyIcon notifyIconTray;
        private System.Windows.Forms.Timer timerStartup;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTray;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorkerStart;
        private System.ComponentModel.BackgroundWorker backgroundWorkerWait;
        private System.ComponentModel.BackgroundWorker backgroundWorkerStop;
        private System.Windows.Forms.Timer timerCheckStart;
        private System.Windows.Forms.Timer timerCheckStop;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem hideIconToolStripMenuItem;
    }
}

