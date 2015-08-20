namespace AutoClose
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.grpOptions = new System.Windows.Forms.GroupBox();
            this.chkPrivacyShields = new System.Windows.Forms.CheckBox();
            this.chkMinimise = new System.Windows.Forms.CheckBox();
            this.chkMuteAllDevices = new System.Windows.Forms.CheckBox();
            this.panButtons = new System.Windows.Forms.Panel();
            this.butOK = new System.Windows.Forms.Button();
            this.butClose = new System.Windows.Forms.Button();
            this.ninSysTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsSysTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chkStartHidden = new System.Windows.Forms.CheckBox();
            this.chkStartWindows = new System.Windows.Forms.CheckBox();
            this.chkLog = new System.Windows.Forms.CheckBox();
            this.lnkOpenLog = new System.Windows.Forms.LinkLabel();
            this.grpOptions.SuspendLayout();
            this.panButtons.SuspendLayout();
            this.cmsSysTray.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Checked = true;
            this.chkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnabled.Location = new System.Drawing.Point(12, 12);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(311, 24);
            this.chkEnabled.TabIndex = 0;
            this.chkEnabled.Text = "Enable AutoClose to protect my privacy";
            this.chkEnabled.UseVisualStyleBackColor = true;
            this.chkEnabled.CheckedChanged += new System.EventHandler(this.chkEnabled_CheckedChanged);
            // 
            // grpOptions
            // 
            this.grpOptions.Controls.Add(this.chkPrivacyShields);
            this.grpOptions.Controls.Add(this.chkMinimise);
            this.grpOptions.Controls.Add(this.chkMuteAllDevices);
            this.grpOptions.Location = new System.Drawing.Point(12, 42);
            this.grpOptions.Name = "grpOptions";
            this.grpOptions.Size = new System.Drawing.Size(441, 169);
            this.grpOptions.TabIndex = 1;
            this.grpOptions.TabStop = false;
            this.grpOptions.Text = "Options";
            // 
            // chkPrivacyShields
            // 
            this.chkPrivacyShields.AutoSize = true;
            this.chkPrivacyShields.Checked = true;
            this.chkPrivacyShields.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPrivacyShields.Location = new System.Drawing.Point(17, 121);
            this.chkPrivacyShields.Name = "chkPrivacyShields";
            this.chkPrivacyShields.Size = new System.Drawing.Size(311, 24);
            this.chkPrivacyShields.TabIndex = 3;
            this.chkPrivacyShields.Text = "Display a privacy shield on every screen";
            this.chkPrivacyShields.UseVisualStyleBackColor = true;
            // 
            // chkMinimise
            // 
            this.chkMinimise.AutoSize = true;
            this.chkMinimise.Checked = true;
            this.chkMinimise.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMinimise.Location = new System.Drawing.Point(17, 80);
            this.chkMinimise.Name = "chkMinimise";
            this.chkMinimise.Size = new System.Drawing.Size(179, 24);
            this.chkMinimise.TabIndex = 2;
            this.chkMinimise.Text = "Minimise all windows";
            this.chkMinimise.UseVisualStyleBackColor = true;
            // 
            // chkMuteAllDevices
            // 
            this.chkMuteAllDevices.AutoSize = true;
            this.chkMuteAllDevices.Checked = true;
            this.chkMuteAllDevices.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMuteAllDevices.Location = new System.Drawing.Point(17, 40);
            this.chkMuteAllDevices.Name = "chkMuteAllDevices";
            this.chkMuteAllDevices.Size = new System.Drawing.Size(190, 24);
            this.chkMuteAllDevices.TabIndex = 1;
            this.chkMuteAllDevices.Text = "Mute all audio devices";
            this.chkMuteAllDevices.UseVisualStyleBackColor = true;
            // 
            // panButtons
            // 
            this.panButtons.Controls.Add(this.butOK);
            this.panButtons.Controls.Add(this.butClose);
            this.panButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panButtons.Location = new System.Drawing.Point(0, 417);
            this.panButtons.Name = "panButtons";
            this.panButtons.Size = new System.Drawing.Size(465, 79);
            this.panButtons.TabIndex = 2;
            // 
            // butOK
            // 
            this.butOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butOK.Image = global::AutoClose.Properties.Resources.Task_02_16;
            this.butOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOK.Location = new System.Drawing.Point(171, 13);
            this.butOK.Name = "butOK";
            this.butOK.Padding = new System.Windows.Forms.Padding(16, 0, 16, 0);
            this.butOK.Size = new System.Drawing.Size(138, 50);
            this.butOK.TabIndex = 1;
            this.butOK.Text = "OK";
            this.butOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butOK.UseVisualStyleBackColor = true;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // butClose
            // 
            this.butClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butClose.Image = global::AutoClose.Properties.Resources.Logout_16;
            this.butClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butClose.Location = new System.Drawing.Point(315, 13);
            this.butClose.Name = "butClose";
            this.butClose.Padding = new System.Windows.Forms.Padding(16, 0, 16, 0);
            this.butClose.Size = new System.Drawing.Size(138, 50);
            this.butClose.TabIndex = 0;
            this.butClose.Text = "Close";
            this.butClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butClose.UseVisualStyleBackColor = true;
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            // 
            // ninSysTray
            // 
            this.ninSysTray.ContextMenuStrip = this.cmsSysTray;
            this.ninSysTray.Text = "AutoClose";
            this.ninSysTray.Visible = true;
            this.ninSysTray.DoubleClick += new System.EventHandler(this.ninSysTray_DoubleClick);
            // 
            // cmsSysTray
            // 
            this.cmsSysTray.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsSysTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.cmsSysTray.Name = "cmsSysTray";
            this.cmsSysTray.Size = new System.Drawing.Size(162, 70);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(161, 30);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(158, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::AutoClose.Properties.Resources.Logout_16;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(161, 30);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // chkStartHidden
            // 
            this.chkStartHidden.AutoSize = true;
            this.chkStartHidden.Checked = true;
            this.chkStartHidden.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStartHidden.Location = new System.Drawing.Point(12, 226);
            this.chkStartHidden.Name = "chkStartHidden";
            this.chkStartHidden.Size = new System.Drawing.Size(370, 24);
            this.chkStartHidden.TabIndex = 3;
            this.chkStartHidden.Text = "Start AutoClose hidden in the System Tray area";
            this.chkStartHidden.UseVisualStyleBackColor = true;
            // 
            // chkStartWindows
            // 
            this.chkStartWindows.AutoSize = true;
            this.chkStartWindows.Checked = true;
            this.chkStartWindows.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStartWindows.Location = new System.Drawing.Point(12, 266);
            this.chkStartWindows.Name = "chkStartWindows";
            this.chkStartWindows.Size = new System.Drawing.Size(320, 24);
            this.chkStartWindows.TabIndex = 4;
            this.chkStartWindows.Text = "Start automatically when Windows starts";
            this.chkStartWindows.UseVisualStyleBackColor = true;
            // 
            // chkLog
            // 
            this.chkLog.AutoSize = true;
            this.chkLog.Checked = true;
            this.chkLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLog.Location = new System.Drawing.Point(12, 302);
            this.chkLog.Name = "chkLog";
            this.chkLog.Size = new System.Drawing.Size(146, 24);
            this.chkLog.TabIndex = 5;
            this.chkLog.Text = "Enable Logging";
            this.chkLog.UseVisualStyleBackColor = true;
            this.chkLog.CheckedChanged += new System.EventHandler(this.chkLog_CheckedChanged);
            // 
            // lnkOpenLog
            // 
            this.lnkOpenLog.AutoSize = true;
            this.lnkOpenLog.Location = new System.Drawing.Point(345, 303);
            this.lnkOpenLog.Name = "lnkOpenLog";
            this.lnkOpenLog.Size = new System.Drawing.Size(108, 20);
            this.lnkOpenLog.TabIndex = 6;
            this.lnkOpenLog.TabStop = true;
            this.lnkOpenLog.Text = "Open Log File";
            this.lnkOpenLog.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkOpenLog_LinkClicked);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 496);
            this.Controls.Add(this.lnkOpenLog);
            this.Controls.Add(this.chkLog);
            this.Controls.Add(this.chkStartWindows);
            this.Controls.Add(this.chkStartHidden);
            this.Controls.Add(this.panButtons);
            this.Controls.Add(this.grpOptions);
            this.Controls.Add(this.chkEnabled);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.Text = "AutoClose";
            this.Activated += new System.EventHandler(this.frmMain_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.grpOptions.ResumeLayout(false);
            this.grpOptions.PerformLayout();
            this.panButtons.ResumeLayout(false);
            this.cmsSysTray.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.GroupBox grpOptions;
        private System.Windows.Forms.Panel panButtons;
        private System.Windows.Forms.Button butOK;
        private System.Windows.Forms.Button butClose;
        private System.Windows.Forms.CheckBox chkMinimise;
        private System.Windows.Forms.CheckBox chkMuteAllDevices;
        private System.Windows.Forms.CheckBox chkPrivacyShields;
        private System.Windows.Forms.NotifyIcon ninSysTray;
        private System.Windows.Forms.ContextMenuStrip cmsSysTray;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkStartHidden;
        private System.Windows.Forms.CheckBox chkStartWindows;
        private System.Windows.Forms.CheckBox chkLog;
        private System.Windows.Forms.LinkLabel lnkOpenLog;
    }
}

