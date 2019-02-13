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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.backgroundWorkerRun = new System.ComponentModel.BackgroundWorker();
            this.loglabel = new System.Windows.Forms.Label();
            this.ShutdownTimer = new System.Windows.Forms.Timer(this.components);
            this.minimize_button = new System.Windows.Forms.PictureBox();
            this.close_button = new System.Windows.Forms.PictureBox();
            this.picturebox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.minimize_button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.close_button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox)).BeginInit();
            this.SuspendLayout();
            // 
            // loglabel
            // 
            this.loglabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loglabel.AutoEllipsis = true;
            this.loglabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.loglabel.ForeColor = System.Drawing.Color.White;
            this.loglabel.Location = new System.Drawing.Point(1, 145);
            this.loglabel.Name = "loglabel";
            this.loglabel.Size = new System.Drawing.Size(478, 64);
            this.loglabel.TabIndex = 3;
            this.loglabel.Text = "Initializing... Please Wait";
            this.loglabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.loglabel.UseCompatibleTextRendering = true;
            this.loglabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.loglabel_MouseDown);
            // 
            // ShutdownTimer
            // 
            this.ShutdownTimer.Interval = 3000;
            this.ShutdownTimer.Tick += new System.EventHandler(this.ShutdownTimer_Tick);
            // 
            // minimize_button
            // 
            this.minimize_button.Image = global::Launcher.Properties.Resources.minimize;
            this.minimize_button.Location = new System.Drawing.Point(422, 4);
            this.minimize_button.Name = "minimize_button";
            this.minimize_button.Size = new System.Drawing.Size(24, 24);
            this.minimize_button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.minimize_button.TabIndex = 6;
            this.minimize_button.TabStop = false;
            this.minimize_button.Click += new System.EventHandler(this.minimize_button_Click);
            // 
            // close_button
            // 
            this.close_button.Image = global::Launcher.Properties.Resources.close;
            this.close_button.Location = new System.Drawing.Point(452, 4);
            this.close_button.Name = "close_button";
            this.close_button.Size = new System.Drawing.Size(24, 24);
            this.close_button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.close_button.TabIndex = 5;
            this.close_button.TabStop = false;
            this.close_button.Click += new System.EventHandler(this.close_button_Click);
            // 
            // picturebox
            // 
            this.picturebox.Image = global::Launcher.Properties.Resources.loading;
            this.picturebox.Location = new System.Drawing.Point(197, 43);
            this.picturebox.Name = "picturebox";
            this.picturebox.Size = new System.Drawing.Size(86, 86);
            this.picturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picturebox.TabIndex = 4;
            this.picturebox.TabStop = false;
            this.picturebox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picturebox_MouseDown);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(52)))), ((int)(((byte)(63)))));
            this.ClientSize = new System.Drawing.Size(480, 240);
            this.Controls.Add(this.minimize_button);
            this.Controls.Add(this.close_button);
            this.Controls.Add(this.picturebox);
            this.Controls.Add(this.loglabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OpenKogama Launcher";
            ((System.ComponentModel.ISupportInitialize)(this.minimize_button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.close_button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox)).EndInit();
            this.ResumeLayout(false);

		}

		private global::System.ComponentModel.IContainer components;
		private global::System.ComponentModel.BackgroundWorker backgroundWorkerRun;
		private System.Windows.Forms.Label loglabel;
        private System.Windows.Forms.PictureBox picturebox;
        private System.Windows.Forms.Timer ShutdownTimer;
        private System.Windows.Forms.PictureBox close_button;
        private System.Windows.Forms.PictureBox minimize_button;
    }
}
