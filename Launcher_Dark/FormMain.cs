using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
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
		private Color BorderColor = Color.FromArgb(37,41,50);

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
				Environment.Exit(0);
				return;
			}

			if (result.errorMsg.Length > 0)
				MessageBox.Show(this, result.errorMsg);

			Environment.Exit(0);
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
				new Action<bool>(this.ShowLoadingIcon),
				new Action<int>(this.SetProgress));
			e.Result = result;
		}

		private void ShowLoadingIcon(bool visible)
		{
			statusLabel.Visible = true;
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
			if (this.progressPanel.InvokeRequired)
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
			progressPanel.Size = new Size((int)(value * 4.86 /* yes */), progressPanel.Size.Height);
		}

		private void exitBox_Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		private void minimizeBox_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
		}

		[System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
		[System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
		public static extern bool ReleaseCapture();

		private void titlePanel_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ReleaseCapture();
				SendMessage(Handle, 0xA1, 0x2, 0);
			}
		}

		private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			//fixes window staying in process
			Environment.Exit(0);
		}

		private void progressPanel_Paint(object sender, PaintEventArgs e)
		{
			ControlPaint.DrawBorder(e.Graphics, this.progressPanel.ClientRectangle, BorderColor, ButtonBorderStyle.Solid);
		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{
			ControlPaint.DrawBorder(e.Graphics, this.listBoxLogPanel.ClientRectangle, BorderColor, ButtonBorderStyle.Solid);
		}
	}
}
