using AutoClose.Win32;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;
using System.Reflection;

namespace AutoClose
{
    public partial class frmMain : Form
    {

        #region private objects

        private IntPtr cIPrNotificationHandle = IntPtr.Zero;
        private bool? cBlnPreviousMonitorState = null;
        private Boolean cBlnUpdateSettings = false;
        private Boolean cBlnActivated = false;

        #endregion

        #region constructor / destructor

        public frmMain()
        {
            InitializeComponent();

            UpdateSettings();

            ApplySettings();

            ninSysTray.Icon = Properties.Resources.window_screen_white;
            ninSysTray.Visible = true;

            RegisterForPowerNotifications();
        }

        #endregion

        #region private methods

        public static String GetAssemblyFullPath()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            return(path.Replace('/', '\\'));
        }

        private void ApplySettings()
        {
            Program.StartLogging();

            RegistryKey pRKyBase = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default);
            RegistryKey pRKyCurrentUserRun = pRKyBase.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            if(pRKyCurrentUserRun != null)
            {
                String pStrAutoClose = (String)pRKyCurrentUserRun.GetValue("AutoClose");
                if(Properties.Settings.Default.StartWithWindows)
                {
                    if (String.IsNullOrEmpty(pStrAutoClose))
                    {
                        pRKyCurrentUserRun.SetValue("AutoClose", GetAssemblyFullPath());
                    }
                }
                else
                {
                    if (!String.IsNullOrEmpty(pStrAutoClose))
                    {
                        pRKyCurrentUserRun.DeleteValue("AutoClose");
                    }
                }

            }
        }

        private void UpdateSettings()
        {
            chkEnabled.Checked = Properties.Settings.Default.Enable;
            chkMuteAllDevices.Checked = Properties.Settings.Default.MuteAllDevices;
            chkMinimise.Checked = Properties.Settings.Default.MinimiseAllWindows;
            chkPrivacyShields.Checked = Properties.Settings.Default.DisplayPrivacyShield;
            chkStartHidden.Checked= Properties.Settings.Default.StartHidden;
            chkStartWindows.Checked = Properties.Settings.Default.StartWithWindows;
            chkLog.Checked = Properties.Settings.Default.Log;
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.Enable = grpOptions.Enabled;
            Properties.Settings.Default.MuteAllDevices = chkMuteAllDevices.Checked;
            Properties.Settings.Default.MinimiseAllWindows = chkMinimise.Checked;
            Properties.Settings.Default.DisplayPrivacyShield = chkPrivacyShields.Checked;
            Properties.Settings.Default.StartHidden = chkStartHidden.Checked;
            Properties.Settings.Default.StartWithWindows = chkStartWindows.Checked;
            Properties.Settings.Default.Log = chkLog.Checked;
            Properties.Settings.Default.Save();
        }

        public void SetVolume(Int32 iLevel)
        {
            Program.Logger.WriteLine(Debugging.BasicTextLogger.MessageType.info, "Attempting tomute the volume of all connected audio devices.");
            try
            {
                NAudio.CoreAudioApi.MMDeviceEnumerator pMDEEnum = new NAudio.CoreAudioApi.MMDeviceEnumerator();
                NAudio.CoreAudioApi.MMDeviceCollection pMDCDevices = pMDEEnum.EnumerateAudioEndPoints(NAudio.CoreAudioApi.DataFlow.All, NAudio.CoreAudioApi.DeviceState.All);
                foreach (NAudio.CoreAudioApi.MMDevice curDevice in pMDCDevices)
                {
                    try
                    {
                        if (curDevice.State == NAudio.CoreAudioApi.DeviceState.Active)
                        {
                            float pFltNewVolume = (float)Math.Max(Math.Min(iLevel, 100), 0) / (float)100;

                            curDevice.AudioEndpointVolume.MasterVolumeLevelScalar = pFltNewVolume;
                            curDevice.AudioEndpointVolume.Mute = (iLevel == 0);

                            Program.Logger.WriteLine(Debugging.BasicTextLogger.MessageType.info, "Volume of {0} is {1}.", curDevice.FriendlyName, curDevice.AudioEndpointVolume.MasterVolumeLevelScalar.ToString());
                        }
                        else
                        {
                            Program.Logger.WriteLine(Debugging.BasicTextLogger.MessageType.debug, "Ignoring device {0} with state {1}.", curDevice.FriendlyName, curDevice.State);
                        }
                    }
                    catch (Exception ex)
                    {
                        Program.Logger.WriteLine(Debugging.BasicTextLogger.MessageType.error, "{0} could not be muted.", curDevice.FriendlyName);
                        Program.Logger.WriteException(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                Program.Logger.WriteLine(Debugging.BasicTextLogger.MessageType.error, "Unable to enumerate audio devices.");
                Program.Logger.WriteException(ex);
            }
        }


        private void RegisterForPowerNotifications()
        {
            cIPrNotificationHandle = NativeMethods.RegisterPowerSettingNotification(Handle,
                 ref NativeMethods.GUID_MONITOR_POWER_ON,
                 NativeMethods.DEVICE_NOTIFY_WINDOW_HANDLE);
        }

        private void MinimiseAllWindows()
        {
            Program.Logger.WriteLine(Debugging.BasicTextLogger.MessageType.info, "Minimising all windows.");
            Windows.WindowsUtility.MinimiseAll();
        }

        private void DisplayPrivacyShields()
        {
            foreach (Screen curScreen in Screen.AllScreens)
            {
                Program.Logger.WriteLine(Debugging.BasicTextLogger.MessageType.info, "Display a privacy shield for the device '{0}'.", curScreen.DeviceName);

                frmPrivacyShield pFrmPrivacyShield = new frmPrivacyShield();
                pFrmPrivacyShield.Location = curScreen.Bounds.Location;
                pFrmPrivacyShield.Size = curScreen.Bounds.Size;
                pFrmPrivacyShield.Show();
            }
        }

        private void OnPowerBroadcast(IntPtr wParam, IntPtr lParam)
        {
            if ((int)wParam == NativeMethods.PBT_POWERSETTINGCHANGE)
            {
                NativeMethods.POWERBROADCAST_SETTING pPBSSettings = (NativeMethods.POWERBROADCAST_SETTING)Marshal.PtrToStructure(lParam, typeof(NativeMethods.POWERBROADCAST_SETTING));
                IntPtr pIPrData = (IntPtr)((int)lParam + Marshal.SizeOf(pPBSSettings));
                Int32 pIntData = (Int32)Marshal.PtrToStructure(pIPrData, typeof(Int32));
                switch(pPBSSettings.PowerSetting.ToString())
                {
                    case NativeMethods.GUID_MONITOR_POWER_ON_STRING:
                        {
                            bool pBlnIsMonitorOn = pPBSSettings.Data == 1;

                            if(cBlnPreviousMonitorState != null)
                            {
                                if (pBlnIsMonitorOn != cBlnPreviousMonitorState)
                                {
                                    if (!pBlnIsMonitorOn)
                                    {
                                        Program.Logger.WriteLine(Debugging.BasicTextLogger.MessageType.info, "The power for the primary monitor appears to have been turned off.");

                                        if(chkMuteAllDevices.Checked)
                                            SetVolume(0);
                                        if (chkMinimise.Checked)
                                            MinimiseAllWindows();
                                        if(chkPrivacyShields.Checked)
                                            DisplayPrivacyShields();
                                        Visible = false;
                                    }
                                    else
                                    {
                                        Program.Logger.WriteLine(Debugging.BasicTextLogger.MessageType.info, "The power for the primary monitor appears to have been turned on.");

                                        //Let's minimise all windows again, just incase some appeared after
                                        //we done it the last time
                                        if (chkMinimise.Checked)
                                            MinimiseAllWindows();
                                    }
                                }
                            }

                            cBlnPreviousMonitorState = pBlnIsMonitorOn;
                            break;
                        }

                }
            }
        }

        #endregion

        #region base class overrides

        protected override void WndProc(ref Message m)
        {
            if (chkEnabled.Checked)
            {
                switch (m.Msg)
                {
                    case NativeMethods.WM_POWERBROADCAST:
                        {
                            OnPowerBroadcast(m.WParam, m.LParam);
                            break;
                        }
                }
            }
            base.WndProc(ref m);
        }

        #endregion

        #region base class events

        private void frmMain_Activated(object sender, EventArgs e)
        {
            if(cBlnUpdateSettings)
                UpdateSettings();

            if (Properties.Settings.Default.StartHidden && !Program.FirstRun && !cBlnActivated)
                Visible = false;

            cBlnActivated = true;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!Program.AllowClose)
            {
                switch(e.CloseReason)
                {
                    case CloseReason.UserClosing:
                        {
                            e.Cancel = true;
                            Visible = false;
                            break;
                        }
                }
            }

            if (!e.Cancel)
                ninSysTray.Visible = false;
        }

        #endregion

        #region object events

        private void chkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            grpOptions.Enabled = chkEnabled.Checked;             
        }

        private void ninSysTray_DoubleClick(object sender, EventArgs e)
        {
            Visible = !Visible;
            BringToFront();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.AllowClose = true;
            Close();
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to close AutoClose?  You will not be protected while AutoClose is not running.", 
                "Close AutoClose", 
                MessageBoxButtons.OKCancel, 
                MessageBoxIcon.Warning, 
                MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                Program.AllowClose = true;
                Close();
            }
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            SaveSettings();
            ApplySettings();
            Visible = false;
            cBlnUpdateSettings = true;
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Visible = true;
            BringToFront();
        }

        private void chkLog_CheckedChanged(object sender, EventArgs e)
        {
            lnkOpenLog.Enabled = chkLog.Checked;
        }

        private void lnkOpenLog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(Program.LogFile);
        }

        #endregion

    }
}
