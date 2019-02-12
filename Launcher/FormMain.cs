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
				MessageBox.Show("OpenKogama Launcher call with incorrect arguments. Exiting.");
				base.Close();
				return;
			}
			this.backgroundWorkerRun.DoWork += this.backgroundWorkerRun_DoWork;
			this.backgroundWorkerRun.RunWorkerCompleted += this.backgroundWorkerRun_RunWorkerCompleted;
			this.backgroundWorkerRun.RunWorkerAsync();
		}

		private void backgroundWorkerRun_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.SetProgress(100);
			LauncherResult result = (LauncherResult)e.Result;
			if (!result.success)
			{
				MessageBox.Show(this, result.errorMsg);
				base.Close();
				return;
			}

            if (result.errorMsg.Length > 0)
                MessageBox.Show(this, result.errorMsg);
            else
                Thread.Sleep(10); /* Original delay was 1000ms */

			base.Close();
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
                new Action<bool>(this.ShowLoadingIcon) /* nothing for now */, 
                new Action<int>(this.SetProgress));
			e.Result = result;
		}

        /* nothing for now */
        private void ShowLoadingIcon(bool visible)
        {
            return;
        }

		private void LogMsg(string msg)
		{
			if (this.listBoxLog.InvokeRequired)
			{
				FormMain.m_WriteLogMsg logMsg = new FormMain.m_WriteLogMsg(this.DoLogMsg);
				base.Invoke(logMsg, new object[]
				{
					msg
				});
				return;
			}
			this.DoLogMsg(msg);
		}

		private void DoLogMsg(string msg)
		{
			this.listBoxLog.Items.Add(msg);
		}

		private void SetProgress(int value)
		{
			if (this.progressBarMain.InvokeRequired)
			{
				FormMain.m_SetProgress sp = new FormMain.m_SetProgress(this.DoSetProgress);
				base.Invoke(sp, new object[]
				{
					value
				});
				return;
			}
			this.DoSetProgress(value);
		}

		private void DoSetProgress(int value)
		{
			if (value > 100)
				value = 100;
			if (value < 0)
				value = 0;
			this.progressBarMain.Value = value;
		}
        
		private void buttonExit_Click(object sender, EventArgs e)
		{
			base.Close();
		}
    }
}
