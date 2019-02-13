using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Launcher.Properties;
using LauncherCore.Controls;
using LauncherCore.Helpers;
using LauncherCore.Main;

namespace Launcher
{
    public partial class FormMain : Form
    {
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private LauncherArgs launcherArgs = new LauncherArgs();
        private delegate void m_WriteLogMsg(string msg);
        private delegate void m_ShowLoadingIcon(bool visible);
        private delegate void m_SetProgress(int value);

        public FormMain()
        {
            this.InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.LogMsg("Initializing...please wait...");
            if (!this.launcherArgs.UnpackLauncherArgs())
            {
                this.LogMsg("Launcher called with incorrect arguments.");
                this.picturebox.Image = Resources.error;
                ShutdownTimer.Enabled = true;
                return;
            }
            this.backgroundWorkerRun.DoWork += this.backgroundWorkerRun_DoWork;
            this.backgroundWorkerRun.RunWorkerCompleted += this.backgroundWorkerRun_RunWorkerCompleted;
            this.backgroundWorkerRun.RunWorkerAsync();
        }

        private void backgroundWorkerRun_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LauncherResult result = (LauncherResult)e.Result;
            if (!result.success)
            {
                this.LogMsg(result.errorMsg);
                this.picturebox.Image = Resources.error;
                ShutdownTimer.Enabled = true;
                return;
            }

            if (result.errorMsg.Length > 0)
            {
                this.LogMsg(result.errorMsg);
                this.picturebox.Image = Resources.error;
            }
            else
            {
                ShutdownTimer.Interval = 500;
                ShutdownTimer.Enabled = true;
            }
        }

        private void backgroundWorkerRun_DoWork(object sender, DoWorkEventArgs e)
        {
            LauncherResult result = LauncherMain.Run(
                this.launcherArgs.registryRootKeyName,
                this.launcherArgs.regionURL,
                this.launcherArgs.standaloneRelativePath,
                this.launcherArgs.standaloneExecutableName,
                this.launcherArgs.standaloneAPIURL,
                this.launcherArgs.bootStrapperExecutableName,
                this.launcherArgs.sentryURL,
                this.launcherArgs.isFirstTimeInstall,
                this.launcherArgs.callingArgs,
                new Action<string>(this.LogMsg),
                new Action<bool>(this.ShowLoadingIcon) /* nothing for now */);
            e.Result = result;
        }

        /* nothing for now */
        private void ShowLoadingIcon(bool visible)
        {
            return;
        }

        private void LogMsg(string msg)
        {
            this.DoLogMsg(msg);
        }

        private void DoLogMsg(string msg)
        {
            this.loglabel.Text = msg;
        }

        private void ShutdownTimer_Tick(object sender, EventArgs e)
        {
            base.Close();
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }

        private void picturebox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, 0xA1, 0x2, 0);
            }
        }

        private void loglabel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, 0xA1, 0x2, 0);
            }
        }

        private void close_button_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void minimize_button_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

    }
}
