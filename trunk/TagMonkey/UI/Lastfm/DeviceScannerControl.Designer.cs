namespace TagMonkey.UI.Lastfm {
	partial class DeviceScannerControl {
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
			this.groupBox1 = new System.Windows.Forms.GroupBox ();
			this.scanButton = new TagMonkey.UI.CommonControls.ProcessButton ();
			this.deviceSelector = new TagMonkey.UI.CommonControls.SourceSelectorControl ();
			this.trackList = new TagMonkey.UI.Lastfm.TrackQueueControl ();
			this.groupBox1.SuspendLayout ();
			this.SuspendLayout ();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add (this.scanButton);
			this.groupBox1.Controls.Add (this.deviceSelector);
			this.groupBox1.Controls.Add (this.trackList);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point (0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size (487, 247);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Выберите устройство для скробблинга:";
			// 
			// scanButton
			// 
			this.scanButton.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.scanButton.ButtonImage = global::TagMonkey.Properties.Resources.scanIcon;
			this.scanButton.ButtonText = " &Сканировать";
			this.scanButton.CancelText = "&Остановить";
			this.scanButton.Location = new System.Drawing.Point (296, 19);
			this.scanButton.Name = "scanButton";
			this.scanButton.Size = new System.Drawing.Size (185, 27);
			this.scanButton.TabIndex = 1;
			this.scanButton.DoWork += new System.ComponentModel.DoWorkEventHandler (this.scanButton_DoWork);
			this.scanButton.AfterWork += new System.ComponentModel.RunWorkerCompletedEventHandler (this.scanButton_AfterWork);
			this.scanButton.BeforeWork += new System.EventHandler<TagMonkey.UI.CommonControls.BeforeWorkEventArgs> (this.scanButton_BeforeWork);
			// 
			// deviceSelector
			// 
			this.deviceSelector.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.deviceSelector.Location = new System.Drawing.Point (6, 19);
			this.deviceSelector.Name = "deviceSelector";
			this.deviceSelector.Size = new System.Drawing.Size (284, 27);
			this.deviceSelector.TabIndex = 0;
			// 
			// trackList
			// 
			this.trackList.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
				    | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.trackList.Location = new System.Drawing.Point (6, 52);
			this.trackList.Name = "trackList";
			this.trackList.Size = new System.Drawing.Size (475, 192);
			this.trackList.TabIndex = 2;
			// 
			// DeviceScannerControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add (this.groupBox1);
			this.Name = "DeviceScannerControl";
			this.Size = new System.Drawing.Size (487, 247);
			this.groupBox1.ResumeLayout (false);
			this.ResumeLayout (false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private TrackQueueControl trackList;
		private TagMonkey.UI.CommonControls.SourceSelectorControl deviceSelector;
		private TagMonkey.UI.CommonControls.ProcessButton scanButton;

	}
}
