namespace TagMonkey.UI.AutoTagger {
	partial class PlaylistSelectorControl {
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
			this.playlistComboBox = new System.Windows.Forms.ComboBox ();
			this.sourceSelector = new TagMonkey.UI.Common.SourceSelectorControl ();
			this.groupBox1.SuspendLayout ();
			this.SuspendLayout ();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add (this.sourceSelector);
			this.groupBox1.Controls.Add (this.playlistComboBox);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point (0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size (450, 45);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "В&ыберите источник:";
			// 
			// playlistComboBox
			// 
			this.playlistComboBox.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.playlistComboBox.DisplayMember = "Name";
			this.playlistComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.playlistComboBox.FormattingEnabled = true;
			this.playlistComboBox.Location = new System.Drawing.Point (223, 18);
			this.playlistComboBox.Name = "playlistComboBox";
			this.playlistComboBox.Size = new System.Drawing.Size (221, 21);
			this.playlistComboBox.TabIndex = 1;
			// 
			// sourceSelector
			// 
			this.sourceSelector.Location = new System.Drawing.Point (6, 15);
			this.sourceSelector.Name = "sourceSelector";
			this.sourceSelector.Size = new System.Drawing.Size (211, 27);
			this.sourceSelector.TabIndex = 0;
			// 
			// PlaylistSelectorControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add (this.groupBox1);
			this.Name = "PlaylistSelectorControl";
			this.Size = new System.Drawing.Size (450, 45);
			this.groupBox1.ResumeLayout (false);
			this.ResumeLayout (false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox playlistComboBox;
		private TagMonkey.UI.Common.SourceSelectorControl sourceSelector;

	}
}
