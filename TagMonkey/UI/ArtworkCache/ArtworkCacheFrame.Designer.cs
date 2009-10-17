namespace TagMonkey.UI.ArtworkCacheViewer {
	partial class ArtworkCacheFrame {
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
			this.coverImageList = new System.Windows.Forms.ImageList (this.components);
			this.itemMenu = new System.Windows.Forms.ContextMenuStrip (this.components);
			this.removeArtworkMenuItem = new System.Windows.Forms.ToolStripMenuItem ();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator ();
			this.clearCacheMenuItem = new System.Windows.Forms.ToolStripMenuItem ();
			this.emptyCacheLabel = new System.Windows.Forms.Label ();
			this.coverListView = new TagMonkey.UI.Extra.NoFlickeringListView ();
			this.itemMenu.SuspendLayout ();
			this.SuspendLayout ();
			// 
			// coverImageList
			// 
			this.coverImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
			this.coverImageList.ImageSize = new System.Drawing.Size (165, 165);
			this.coverImageList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// itemMenu
			// 
			this.itemMenu.Items.AddRange (new System.Windows.Forms.ToolStripItem [] {
            this.removeArtworkMenuItem,
            this.toolStripSeparator1,
            this.clearCacheMenuItem});
			this.itemMenu.Name = "itemMenu";
			this.itemMenu.Size = new System.Drawing.Size (197, 54);
			this.itemMenu.Opening += new System.ComponentModel.CancelEventHandler (this.itemMenu_Opening);
			// 
			// removeArtworkMenuItem
			// 
			this.removeArtworkMenuItem.Image = global::TagMonkey.Properties.Resources.removeIcon;
			this.removeArtworkMenuItem.Name = "removeArtworkMenuItem";
			this.removeArtworkMenuItem.Size = new System.Drawing.Size (196, 22);
			this.removeArtworkMenuItem.Text = "&Удалить эту обложку";
			this.removeArtworkMenuItem.Click += new System.EventHandler (this.removeArtworkMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size (193, 6);
			// 
			// clearCacheMenuItem
			// 
			this.clearCacheMenuItem.Image = global::TagMonkey.Properties.Resources.clearIcon;
			this.clearCacheMenuItem.Name = "clearCacheMenuItem";
			this.clearCacheMenuItem.Size = new System.Drawing.Size (196, 22);
			this.clearCacheMenuItem.Text = "&Очистить кэш...";
			this.clearCacheMenuItem.Click += new System.EventHandler (this.clearCacheMenuItem_Click);
			// 
			// emptyCacheLabel
			// 
			this.emptyCacheLabel.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
				    | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.emptyCacheLabel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.emptyCacheLabel.Font = new System.Drawing.Font ("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.emptyCacheLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
			this.emptyCacheLabel.Location = new System.Drawing.Point (230, 159);
			this.emptyCacheLabel.Name = "emptyCacheLabel";
			this.emptyCacheLabel.Size = new System.Drawing.Size (231, 36);
			this.emptyCacheLabel.TabIndex = 0;
			this.emptyCacheLabel.Text = "Кэш обложек пуст.";
			this.emptyCacheLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.emptyCacheLabel.Visible = false;
			// 
			// coverListView
			// 
			this.coverListView.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
			this.coverListView.ContextMenuStrip = this.itemMenu;
			this.coverListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.coverListView.LargeImageList = this.coverImageList;
			this.coverListView.Location = new System.Drawing.Point (0, 0);
			this.coverListView.MultiSelect = false;
			this.coverListView.Name = "coverListView";
			this.coverListView.Size = new System.Drawing.Size (691, 445);
			this.coverListView.TabIndex = 0;
			this.coverListView.UseCompatibleStateImageBehavior = false;
			// 
			// ArtworkCacheFrame
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add (this.emptyCacheLabel);
			this.Controls.Add (this.coverListView);
			this.Name = "ArtworkCacheFrame";
			this.Size = new System.Drawing.Size (691, 445);
			this.Load += new System.EventHandler (this.ArtworkCacheFrame_Load);
			this.itemMenu.ResumeLayout (false);
			this.ResumeLayout (false);

		}

		#endregion

		private System.Windows.Forms.ImageList coverImageList;
		private TagMonkey.UI.Extra.NoFlickeringListView coverListView;
		private System.Windows.Forms.ContextMenuStrip itemMenu;
		private System.Windows.Forms.ToolStripMenuItem removeArtworkMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem clearCacheMenuItem;
		private System.Windows.Forms.Label emptyCacheLabel;
	}
}
