namespace TagMonkey.UI.AutoTagger {
	partial class AutoTaggerFrame {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof (AutoTaggerFrame));
			this.taggerWorker = new System.ComponentModel.BackgroundWorker ();
			this.clearLogButton = new System.Windows.Forms.Button ();
			this.unsafeLogger = new TagMonkey.UI.Common.LoggerControl ();
			this.boombox = new TagMonkey.UI.AutoTagger.BoomboxControl ();
			this.taggerOptions = new TagMonkey.UI.AutoTagger.AutoTaggerOptionsControl ();
			this.playlistSelector = new TagMonkey.UI.AutoTagger.PlaylistSelectorControl ();
			this.SuspendLayout ();
			// 
			// taggerWorker
			// 
			this.taggerWorker.WorkerReportsProgress = true;
			this.taggerWorker.WorkerSupportsCancellation = true;
			this.taggerWorker.DoWork += new System.ComponentModel.DoWorkEventHandler (this.worker_DoWork);
			this.taggerWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler (this.worker_RunWorkerCompleted);
			this.taggerWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler (this.worker_ProgressChanged);
			// 
			// clearLogButton
			// 
			this.clearLogButton.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.clearLogButton.Enabled = false;
			this.clearLogButton.Font = new System.Drawing.Font ("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.clearLogButton.Image = ((System.Drawing.Image) (resources.GetObject ("clearLogButton.Image")));
			this.clearLogButton.Location = new System.Drawing.Point (535, 212);
			this.clearLogButton.Name = "clearLogButton";
			this.clearLogButton.Size = new System.Drawing.Size (56, 50);
			this.clearLogButton.TabIndex = 3;
			this.clearLogButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.clearLogButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.clearLogButton.UseVisualStyleBackColor = true;
			this.clearLogButton.Click += new System.EventHandler (this.clearLogButton_Click);
			// 
			// unsafeLogger
			// 
			this.unsafeLogger.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
				    | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.unsafeLogger.Location = new System.Drawing.Point (3, 268);
			this.unsafeLogger.Name = "unsafeLogger";
			this.unsafeLogger.Size = new System.Drawing.Size (591, 136);
			this.unsafeLogger.TabIndex = 4;
			// 
			// boombox
			// 
			this.boombox.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.boombox.BackColor = System.Drawing.SystemColors.Control;
			this.boombox.Location = new System.Drawing.Point (0, 212);
			this.boombox.Name = "boombox";
			this.boombox.Size = new System.Drawing.Size (529, 50);
			this.boombox.TabIndex = 2;
			this.boombox.Go += new System.EventHandler (this.boombox_Go);
			this.boombox.Stop += new System.EventHandler (this.boombox_Stop);
			// 
			// taggerOptions
			// 
			this.taggerOptions.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.taggerOptions.Location = new System.Drawing.Point (3, 62);
			this.taggerOptions.Name = "taggerOptions";
			this.taggerOptions.Size = new System.Drawing.Size (591, 144);
			this.taggerOptions.TabIndex = 1;
			// 
			// playlistSelector
			// 
			this.playlistSelector.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.playlistSelector.Location = new System.Drawing.Point (3, 3);
			this.playlistSelector.Name = "playlistSelector";
			this.playlistSelector.Size = new System.Drawing.Size (591, 53);
			this.playlistSelector.TabIndex = 0;
			// 
			// AutoTaggerFrame
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add (this.unsafeLogger);
			this.Controls.Add (this.clearLogButton);
			this.Controls.Add (this.boombox);
			this.Controls.Add (this.taggerOptions);
			this.Controls.Add (this.playlistSelector);
			this.Name = "AutoTaggerFrame";
			this.Size = new System.Drawing.Size (597, 407);
			this.Load += new System.EventHandler (this.TagFillerFrame_Load);
			this.ResumeLayout (false);

		}

		#endregion

		private TagMonkey.UI.AutoTagger.BoomboxControl boombox;
		private System.ComponentModel.BackgroundWorker taggerWorker;
		private AutoTaggerOptionsControl taggerOptions;
		private PlaylistSelectorControl playlistSelector;
		private System.Windows.Forms.Button clearLogButton;
		private TagMonkey.UI.Common.LoggerControl unsafeLogger;
	}
}
