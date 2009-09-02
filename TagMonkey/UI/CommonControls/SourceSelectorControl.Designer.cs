namespace TagMonkey.UI.CommonControls {
	partial class SourceSelectorControl {
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
			this.sourcesComboBox = new System.Windows.Forms.ComboBox ();
			this.refreshButton = new System.Windows.Forms.Button ();
			this.SuspendLayout ();
			// 
			// sourcesComboBox
			// 
			this.sourcesComboBox.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.sourcesComboBox.DisplayMember = "Name";
			this.sourcesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.sourcesComboBox.FormattingEnabled = true;
			this.sourcesComboBox.Location = new System.Drawing.Point (45, 3);
			this.sourcesComboBox.Name = "sourcesComboBox";
			this.sourcesComboBox.Size = new System.Drawing.Size (170, 21);
			this.sourcesComboBox.TabIndex = 1;
			// 
			// refreshButton
			// 
			this.refreshButton.Image = global::TagMonkey.Properties.Resources.refreshIcon;
			this.refreshButton.Location = new System.Drawing.Point (4, 3);
			this.refreshButton.Name = "refreshButton";
			this.refreshButton.Size = new System.Drawing.Size (35, 23);
			this.refreshButton.TabIndex = 0;
			this.refreshButton.UseVisualStyleBackColor = true;
			// 
			// SourceSelectorControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add (this.refreshButton);
			this.Controls.Add (this.sourcesComboBox);
			this.Name = "SourceSelectorControl";
			this.Size = new System.Drawing.Size (218, 27);
			this.Load += new System.EventHandler (this.SourceSelectorControl_Load);
			this.ResumeLayout (false);

		}

		#endregion

		private System.Windows.Forms.Button refreshButton;
		private System.Windows.Forms.ComboBox sourcesComboBox;
	}
}
