namespace TagMonkey.UI.Lastfm {
	partial class LastfmFrame {
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose (bool disposing)
		{
			if (disposing && (components != null)) {
				components.Dispose ();
			}
			base.Dispose (disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent ()
		{
			this.pictureBox1 = new System.Windows.Forms.PictureBox ();
			this.splitContainer = new System.Windows.Forms.SplitContainer ();
			this.trackQueue = new TagMonkey.UI.Lastfm.DeviceScannerControl ();
			this.loggerControl = new TagMonkey.UI.Common.LoggerControl ();
			this.scrobbleButton = new TagMonkey.UI.Common.ProcessButton ();
			this.loginControl = new TagMonkey.UI.Lastfm.LastfmLoginControl ();
			((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).BeginInit ();
			this.splitContainer.Panel1.SuspendLayout ();
			this.splitContainer.Panel2.SuspendLayout ();
			this.splitContainer.SuspendLayout ();
			this.SuspendLayout ();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.pictureBox1.Image = global::TagMonkey.Properties.Resources.audioscrobbler;
			this.pictureBox1.Location = new System.Drawing.Point (3, 399);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size (208, 50);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pictureBox1.TabIndex = 3;
			this.pictureBox1.TabStop = false;
			// 
			// splitContainer
			// 
			this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
				    | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer.Location = new System.Drawing.Point (3, 108);
			this.splitContainer.Name = "splitContainer";
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.Controls.Add (this.trackQueue);
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add (this.loggerControl);
			this.splitContainer.Size = new System.Drawing.Size (845, 285);
			this.splitContainer.SplitterDistance = 504;
			this.splitContainer.TabIndex = 4;
			// 
			// trackQueue
			// 
			this.trackQueue.Dock = System.Windows.Forms.DockStyle.Fill;
			this.trackQueue.Location = new System.Drawing.Point (0, 0);
			this.trackQueue.Margin = new System.Windows.Forms.Padding (0);
			this.trackQueue.Name = "trackQueue";
			this.trackQueue.Size = new System.Drawing.Size (504, 285);
			this.trackQueue.TabIndex = 0;
			// 
			// loggerControl
			// 
			this.loggerControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.loggerControl.Location = new System.Drawing.Point (0, 0);
			this.loggerControl.Name = "loggerControl";
			this.loggerControl.Size = new System.Drawing.Size (337, 285);
			this.loggerControl.TabIndex = 0;
			// 
			// scrobbleButton
			// 
			this.scrobbleButton.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.scrobbleButton.ButtonImage = global::TagMonkey.Properties.Resources.lastfmIcon;
			this.scrobbleButton.ButtonText = "Скро&бблить";
			this.scrobbleButton.CancelText = "&Остановить";
			this.scrobbleButton.Font = new System.Drawing.Font ("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.scrobbleButton.Location = new System.Drawing.Point (660, 399);
			this.scrobbleButton.Name = "scrobbleButton";
			this.scrobbleButton.Size = new System.Drawing.Size (188, 47);
			this.scrobbleButton.TabIndex = 1;
			this.scrobbleButton.DoWork += new System.ComponentModel.DoWorkEventHandler (this.scrobbleButton_DoWork);
			this.scrobbleButton.AfterWork += new System.ComponentModel.RunWorkerCompletedEventHandler (this.scrobbleButton_AfterWork);
			this.scrobbleButton.BeforeWork += new System.EventHandler<TagMonkey.UI.Common.BeforeWorkEventArgs> (this.scrobbleButton_BeforeWork);
			// 
			// loginControl
			// 
			this.loginControl.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.loginControl.Location = new System.Drawing.Point (0, 3);
			this.loginControl.Name = "loginControl";
			this.loginControl.Size = new System.Drawing.Size (848, 99);
			this.loginControl.TabIndex = 0;
			// 
			// LastfmFrame
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add (this.scrobbleButton);
			this.Controls.Add (this.splitContainer);
			this.Controls.Add (this.pictureBox1);
			this.Controls.Add (this.loginControl);
			this.MinimumSize = new System.Drawing.Size (477, 275);
			this.Name = "LastfmFrame";
			this.Size = new System.Drawing.Size (851, 450);
			this.Load += new System.EventHandler (this.LastfmScrobblerFrame_Load);
			((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).EndInit ();
			this.splitContainer.Panel1.ResumeLayout (false);
			this.splitContainer.Panel2.ResumeLayout (false);
			this.splitContainer.ResumeLayout (false);
			this.ResumeLayout (false);

		}

		#endregion

		private TagMonkey.UI.Lastfm.LastfmLoginControl loginControl;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.SplitContainer splitContainer;
		private DeviceScannerControl trackQueue;
		private TagMonkey.UI.Common.LoggerControl loggerControl;
		private TagMonkey.UI.Common.ProcessButton scrobbleButton;


	}
}
