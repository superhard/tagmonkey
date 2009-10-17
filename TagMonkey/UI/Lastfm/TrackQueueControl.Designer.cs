namespace TagMonkey.UI.Lastfm {
	partial class TrackQueueControl {
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
			this.tracksListView = new TagMonkey.UI.Extra.AutoSizeListView ();
			this.artistColumn = new System.Windows.Forms.ColumnHeader ();
			this.songColumn = new System.Windows.Forms.ColumnHeader ();
			this.playCountColumn = new System.Windows.Forms.ColumnHeader ();
			this.dateColumn = new System.Windows.Forms.ColumnHeader ();
			this.SuspendLayout ();
			// 
			// tracksListView
			// 
			this.tracksListView.CheckBoxes = true;
			this.tracksListView.Columns.AddRange (new System.Windows.Forms.ColumnHeader [] {
            this.artistColumn,
            this.songColumn,
            this.playCountColumn,
            this.dateColumn});
			this.tracksListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tracksListView.FullRowSelect = true;
			this.tracksListView.Location = new System.Drawing.Point (0, 0);
			this.tracksListView.Name = "tracksListView";
			this.tracksListView.Size = new System.Drawing.Size (572, 235);
			this.tracksListView.TabIndex = 0;
			this.tracksListView.UseCompatibleStateImageBehavior = false;
			this.tracksListView.View = System.Windows.Forms.View.Details;
			this.tracksListView.KeyDown += new System.Windows.Forms.KeyEventHandler (this.tracksListView_KeyDown);
			// 
			// artistColumn
			// 
			this.artistColumn.Text = "Исполнитель";
			this.artistColumn.Width = 180;
			// 
			// songColumn
			// 
			this.songColumn.Text = "Название";
			this.songColumn.Width = 160;
			// 
			// playCountColumn
			// 
			this.playCountColumn.Text = "Исполнено";
			this.playCountColumn.Width = 71;
			// 
			// dateColumn
			// 
			this.dateColumn.Text = "Когда";
			this.dateColumn.Width = 157;
			// 
			// TrackListControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add (this.tracksListView);
			this.Name = "TrackListControl";
			this.Size = new System.Drawing.Size (572, 235);
			this.ResumeLayout (false);

		}

		#endregion

		private TagMonkey.UI.Extra.AutoSizeListView tracksListView;
		private System.Windows.Forms.ColumnHeader artistColumn;
		private System.Windows.Forms.ColumnHeader songColumn;
		private System.Windows.Forms.ColumnHeader playCountColumn;
		private System.Windows.Forms.ColumnHeader dateColumn;
	}
}
