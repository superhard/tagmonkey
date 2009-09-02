namespace TagMonkey.UI.AutoTagger {
	partial class BoomboxControl {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof (BoomboxControl));
			this.pauseButton = new System.Windows.Forms.Button ();
			this.stopButton = new System.Windows.Forms.Button ();
			this.goButton = new System.Windows.Forms.Button ();
			this.SuspendLayout ();
			// 
			// pauseButton
			// 
			this.pauseButton.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
				    | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.pauseButton.Enabled = false;
			this.pauseButton.Font = new System.Drawing.Font ("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.pauseButton.Image = global::TagMonkey.Properties.Resources.pauseIcon;
			this.pauseButton.Location = new System.Drawing.Point (157, 4);
			this.pauseButton.Name = "pauseButton";
			this.pauseButton.Size = new System.Drawing.Size (90, 44);
			this.pauseButton.TabIndex = 1;
			this.pauseButton.Text = "&Пауза";
			this.pauseButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.pauseButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.pauseButton.UseVisualStyleBackColor = true;
			this.pauseButton.Click += new System.EventHandler (this.pauseButton_Click);
			// 
			// stopButton
			// 
			this.stopButton.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.stopButton.Enabled = false;
			this.stopButton.Font = new System.Drawing.Font ("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.stopButton.Image = global::TagMonkey.Properties.Resources.stopIcon;
			this.stopButton.Location = new System.Drawing.Point (253, 4);
			this.stopButton.Name = "stopButton";
			this.stopButton.Size = new System.Drawing.Size (129, 44);
			this.stopButton.TabIndex = 2;
			this.stopButton.Text = "&Остановить";
			this.stopButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.stopButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.stopButton.UseVisualStyleBackColor = true;
			this.stopButton.Click += new System.EventHandler (this.stopButton_Click);
			// 
			// goButton
			// 
			this.goButton.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
				    | System.Windows.Forms.AnchorStyles.Left)));
			this.goButton.Font = new System.Drawing.Font ("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.goButton.Image = ((System.Drawing.Image) (resources.GetObject ("goButton.Image")));
			this.goButton.Location = new System.Drawing.Point (3, 4);
			this.goButton.Name = "goButton";
			this.goButton.Size = new System.Drawing.Size (148, 44);
			this.goButton.TabIndex = 0;
			this.goButton.Text = "По&ехали!";
			this.goButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.goButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.goButton.UseVisualStyleBackColor = true;
			this.goButton.Click += new System.EventHandler (this.goButton_Click);
			// 
			// LaunchPanelControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add (this.pauseButton);
			this.Controls.Add (this.stopButton);
			this.Controls.Add (this.goButton);
			this.Name = "LaunchPanelControl";
			this.Size = new System.Drawing.Size (385, 53);
			this.Load += new System.EventHandler (this.LaunchPanelControl_Load);
			this.ResumeLayout (false);

		}

		#endregion

		private System.Windows.Forms.Button goButton;
		private System.Windows.Forms.Button stopButton;
		private System.Windows.Forms.Button pauseButton;
	}
}
