namespace TagMonkey.UI.CommonControls {
	partial class LoggerControl {
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
			this.components = new System.ComponentModel.Container ();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof (LoggerControl));
			this.statusIconsImageList = new System.Windows.Forms.ImageList (this.components);
			this.logListView = new TagMonkey.UI.ExtraControls.AutoSizeListView ();
			this.statusColumn = new System.Windows.Forms.ColumnHeader ();
			this.trackColumn = new System.Windows.Forms.ColumnHeader ();
			this.messageColumn = new System.Windows.Forms.ColumnHeader ();
			this.progressBar = new System.Windows.Forms.ProgressBar ();
			this.SuspendLayout ();
			// 
			// statusIconsImageList
			// 
			this.statusIconsImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer) (resources.GetObject ("statusIconsImageList.ImageStream")));
			this.statusIconsImageList.TransparentColor = System.Drawing.Color.Transparent;
			this.statusIconsImageList.Images.SetKeyName (0, "Information");
			this.statusIconsImageList.Images.SetKeyName (1, "Error");
			this.statusIconsImageList.Images.SetKeyName (2, "Warning");
			// 
			// logListView
			// 
			this.logListView.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
				    | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.logListView.Columns.AddRange (new System.Windows.Forms.ColumnHeader [] {
            this.statusColumn,
            this.trackColumn,
            this.messageColumn});
			this.logListView.FullRowSelect = true;
			this.logListView.GridLines = true;
			this.logListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.logListView.Location = new System.Drawing.Point (0, 0);
			this.logListView.MultiSelect = false;
			this.logListView.Name = "logListView";
			this.logListView.ShowGroups = false;
			this.logListView.Size = new System.Drawing.Size (616, 164);
			this.logListView.SmallImageList = this.statusIconsImageList;
			this.logListView.TabIndex = 0;
			this.logListView.UseCompatibleStateImageBehavior = false;
			this.logListView.View = System.Windows.Forms.View.Details;
			// 
			// statusColumn
			// 
			this.statusColumn.Text = "";
			this.statusColumn.Width = 30;
			// 
			// trackColumn
			// 
			this.trackColumn.Text = "";
			this.trackColumn.Width = 230;
			// 
			// messageColumn
			// 
			this.messageColumn.Text = "";
			this.messageColumn.Width = 352;
			// 
			// progressBar
			// 
			this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.progressBar.Location = new System.Drawing.Point (0, 169);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size (616, 23);
			this.progressBar.TabIndex = 1;
			// 
			// LoggerControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add (this.progressBar);
			this.Controls.Add (this.logListView);
			this.Name = "LoggerControl";
			this.Size = new System.Drawing.Size (619, 195);
			this.ResumeLayout (false);

		}

		#endregion

		private TagMonkey.UI.ExtraControls.AutoSizeListView logListView;
		private System.Windows.Forms.ColumnHeader statusColumn;
		private System.Windows.Forms.ColumnHeader trackColumn;
		private System.Windows.Forms.ColumnHeader messageColumn;
		private System.Windows.Forms.ImageList statusIconsImageList;
		private System.Windows.Forms.ProgressBar progressBar;

	}
}
