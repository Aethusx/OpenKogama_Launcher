namespace Launcher
{
	public partial class FormMain : global::System.Windows.Forms.Form
	{
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
			this.listBoxLog = new System.Windows.Forms.ListBox();
			this.backgroundWorkerRun = new System.ComponentModel.BackgroundWorker();
			this.titlePanel = new System.Windows.Forms.Panel();
			this.minimizeBox = new System.Windows.Forms.PictureBox();
			this.exitBox = new System.Windows.Forms.PictureBox();
			this.titleLabel = new System.Windows.Forms.Label();
			this.statusLabel = new System.Windows.Forms.Label();
			this.separatorPanel = new System.Windows.Forms.Panel();
			this.progressPanel = new System.Windows.Forms.Panel();
			this.listBoxLogPanel = new System.Windows.Forms.Panel();
			this.titlePanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.minimizeBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.exitBox)).BeginInit();
			this.listBoxLogPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// listBoxLog
			// 
			this.listBoxLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(57)))), ((int)(((byte)(69)))));
			this.listBoxLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listBoxLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(218)))), ((int)(((byte)(227)))));
			this.listBoxLog.FormattingEnabled = true;
			this.listBoxLog.Location = new System.Drawing.Point(3, 3);
			this.listBoxLog.Name = "listBoxLog";
			this.listBoxLog.Size = new System.Drawing.Size(480, 156);
			this.listBoxLog.TabIndex = 1;
			// 
			// titlePanel
			// 
			this.titlePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(52)))), ((int)(((byte)(63)))));
			this.titlePanel.Controls.Add(this.minimizeBox);
			this.titlePanel.Controls.Add(this.exitBox);
			this.titlePanel.Controls.Add(this.titleLabel);
			this.titlePanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.titlePanel.Location = new System.Drawing.Point(0, 0);
			this.titlePanel.Name = "titlePanel";
			this.titlePanel.Size = new System.Drawing.Size(510, 21);
			this.titlePanel.TabIndex = 4;
			this.titlePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titlePanel_MouseDown);
			// 
			// minimizeBox
			// 
			this.minimizeBox.Image = global::Launcher_Dark.Properties.Resources.icon_2;
			this.minimizeBox.Location = new System.Drawing.Point(471, 13);
			this.minimizeBox.Name = "minimizeBox";
			this.minimizeBox.Size = new System.Drawing.Size(7, 2);
			this.minimizeBox.TabIndex = 6;
			this.minimizeBox.TabStop = false;
			this.minimizeBox.Click += new System.EventHandler(this.minimizeBox_Click);
			// 
			// exitBox
			// 
			this.exitBox.Image = global::Launcher_Dark.Properties.Resources.icon_1;
			this.exitBox.Location = new System.Drawing.Point(488, 5);
			this.exitBox.Name = "exitBox";
			this.exitBox.Size = new System.Drawing.Size(10, 10);
			this.exitBox.TabIndex = 6;
			this.exitBox.TabStop = false;
			this.exitBox.Click += new System.EventHandler(this.exitBox_Click);
			// 
			// titleLabel
			// 
			this.titleLabel.AutoSize = true;
			this.titleLabel.BackColor = System.Drawing.Color.Transparent;
			this.titleLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.titleLabel.Location = new System.Drawing.Point(167, 2);
			this.titleLabel.Name = "titleLabel";
			this.titleLabel.Size = new System.Drawing.Size(158, 16);
			this.titleLabel.TabIndex = 5;
			this.titleLabel.Text = "OpenKogama Launcher";
			// 
			// statusLabel
			// 
			this.statusLabel.AutoSize = true;
			this.statusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(148)))), ((int)(((byte)(226)))));
			this.statusLabel.Location = new System.Drawing.Point(456, 3);
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(19, 13);
			this.statusLabel.TabIndex = 6;
			this.statusLabel.Text = "✓";
			this.statusLabel.Visible = false;
			// 
			// separatorPanel
			// 
			this.separatorPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(41)))), ((int)(((byte)(50)))));
			this.separatorPanel.Location = new System.Drawing.Point(0, 21);
			this.separatorPanel.Name = "separatorPanel";
			this.separatorPanel.Size = new System.Drawing.Size(510, 1);
			this.separatorPanel.TabIndex = 5;
			// 
			// progressPanel
			// 
			this.progressPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(148)))), ((int)(((byte)(226)))));
			this.progressPanel.Location = new System.Drawing.Point(12, 202);
			this.progressPanel.Name = "progressPanel";
			this.progressPanel.Size = new System.Drawing.Size(0, 19);
			this.progressPanel.TabIndex = 7;
			this.progressPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.progressPanel_Paint);
			// 
			// listBoxLogPanel
			// 
			this.listBoxLogPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(57)))), ((int)(((byte)(69)))));
			this.listBoxLogPanel.Controls.Add(this.statusLabel);
			this.listBoxLogPanel.Controls.Add(this.listBoxLog);
			this.listBoxLogPanel.Location = new System.Drawing.Point(12, 36);
			this.listBoxLogPanel.Name = "listBoxLogPanel";
			this.listBoxLogPanel.Size = new System.Drawing.Size(486, 160);
			this.listBoxLogPanel.TabIndex = 8;
			this.listBoxLogPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(82)))));
			this.ClientSize = new System.Drawing.Size(510, 233);
			this.Controls.Add(this.listBoxLogPanel);
			this.Controls.Add(this.progressPanel);
			this.Controls.Add(this.separatorPanel);
			this.Controls.Add(this.titlePanel);
			this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(218)))), ((int)(((byte)(227)))));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "FormMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "OpenKogama Launcher";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
			this.titlePanel.ResumeLayout(false);
			this.titlePanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.minimizeBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.exitBox)).EndInit();
			this.listBoxLogPanel.ResumeLayout(false);
			this.listBoxLogPanel.PerformLayout();
			this.ResumeLayout(false);

		}

		private global::System.ComponentModel.IContainer components;
		private global::System.Windows.Forms.ListBox listBoxLog;
		//private global::System.Windows.Forms.ProgressBar progressBarMain;
		private global::System.ComponentModel.BackgroundWorker backgroundWorkerRun;
		private System.Windows.Forms.Panel titlePanel;
		private System.Windows.Forms.Label titleLabel;
		private System.Windows.Forms.Panel separatorPanel;
		private System.Windows.Forms.PictureBox exitBox;
		private System.Windows.Forms.PictureBox minimizeBox;
		private System.Windows.Forms.Label statusLabel;
		private System.Windows.Forms.Panel progressPanel;
		private System.Windows.Forms.Panel listBoxLogPanel;
	}
}
