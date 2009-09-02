namespace TagMonkey.UI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof (MainForm));
		this.scrobblerPage = new System.Windows.Forms.TabPage ();
		this.lastfmScrobblerFrame1 = new TagMonkey.UI.Lastfm.LastfmFrame ();
		this.taggerPage = new System.Windows.Forms.TabPage ();
		this.tagFiller = new TagMonkey.UI.AutoTagger.AutoTaggerFrame ();
		this.tabControl = new System.Windows.Forms.TabControl ();
		this.artworkCacheTab = new System.Windows.Forms.TabPage ();
		this.artworkCacheFrame = new TagMonkey.UI.ArtworkCacheViewer.ArtworkCacheFrame ();
		this.scrobblerPage.SuspendLayout ();
		this.taggerPage.SuspendLayout ();
		this.tabControl.SuspendLayout ();
		this.artworkCacheTab.SuspendLayout ();
		this.SuspendLayout ();
		// 
		// scrobblerPage
		// 
		this.scrobblerPage.Controls.Add (this.lastfmScrobblerFrame1);
		this.scrobblerPage.Location = new System.Drawing.Point (4, 22);
		this.scrobblerPage.Name = "scrobblerPage";
		this.scrobblerPage.Padding = new System.Windows.Forms.Padding (3);
		this.scrobblerPage.Size = new System.Drawing.Size (868, 521);
		this.scrobblerPage.TabIndex = 1;
		this.scrobblerPage.Text = "Скробблинг Last.fm";
		this.scrobblerPage.UseVisualStyleBackColor = true;
		// 
		// lastfmScrobblerFrame1
		// 
		this.lastfmScrobblerFrame1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.lastfmScrobblerFrame1.Location = new System.Drawing.Point (3, 3);
		this.lastfmScrobblerFrame1.MinimumSize = new System.Drawing.Size (471, 0);
		this.lastfmScrobblerFrame1.Name = "lastfmScrobblerFrame1";
		this.lastfmScrobblerFrame1.Size = new System.Drawing.Size (862, 515);
		this.lastfmScrobblerFrame1.TabIndex = 0;
		// 
		// taggerPage
		// 
		this.taggerPage.Controls.Add (this.tagFiller);
		this.taggerPage.Location = new System.Drawing.Point (4, 22);
		this.taggerPage.Name = "taggerPage";
		this.taggerPage.Padding = new System.Windows.Forms.Padding (3);
		this.taggerPage.Size = new System.Drawing.Size (868, 521);
		this.taggerPage.TabIndex = 0;
		this.taggerPage.Text = "Автозаполнение тегов";
		this.taggerPage.UseVisualStyleBackColor = true;
		// 
		// tagFiller
		// 
		this.tagFiller.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tagFiller.Location = new System.Drawing.Point (3, 3);
		this.tagFiller.Name = "tagFiller";
		this.tagFiller.Size = new System.Drawing.Size (862, 515);
		this.tagFiller.TabIndex = 0;
		// 
		// tabControl
		// 
		this.tabControl.Controls.Add (this.taggerPage);
		this.tabControl.Controls.Add (this.artworkCacheTab);
		this.tabControl.Controls.Add (this.scrobblerPage);
		this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tabControl.Location = new System.Drawing.Point (8, 8);
		this.tabControl.Name = "tabControl";
		this.tabControl.SelectedIndex = 0;
		this.tabControl.Size = new System.Drawing.Size (876, 547);
		this.tabControl.TabIndex = 0;
		// 
		// artworkCacheTab
		// 
		this.artworkCacheTab.Controls.Add (this.artworkCacheFrame);
		this.artworkCacheTab.Location = new System.Drawing.Point (4, 22);
		this.artworkCacheTab.Name = "artworkCacheTab";
		this.artworkCacheTab.Padding = new System.Windows.Forms.Padding (3);
		this.artworkCacheTab.Size = new System.Drawing.Size (868, 521);
		this.artworkCacheTab.TabIndex = 2;
		this.artworkCacheTab.Text = "Скачанные обложки";
		this.artworkCacheTab.UseVisualStyleBackColor = true;
		// 
		// artworkCacheFrame
		// 
		this.artworkCacheFrame.Dock = System.Windows.Forms.DockStyle.Fill;
		this.artworkCacheFrame.Location = new System.Drawing.Point (3, 3);
		this.artworkCacheFrame.Name = "artworkCacheFrame";
		this.artworkCacheFrame.Size = new System.Drawing.Size (862, 515);
		this.artworkCacheFrame.TabIndex = 0;
		// 
		// MainForm
		// 
		this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.ClientSize = new System.Drawing.Size (892, 563);
		this.Controls.Add (this.tabControl);
		this.DoubleBuffered = true;
		this.Icon = ((System.Drawing.Icon) (resources.GetObject ("$this.Icon")));
		this.KeyPreview = true;
		this.MinimumSize = new System.Drawing.Size (896, 597);
		this.Name = "MainForm";
		this.Padding = new System.Windows.Forms.Padding (8);
		this.Load += new System.EventHandler (this.MainForm_Load);
		this.KeyDown += new System.Windows.Forms.KeyEventHandler (this.MainForm_KeyDown);
		this.scrobblerPage.ResumeLayout (false);
		this.taggerPage.ResumeLayout (false);
		this.tabControl.ResumeLayout (false);
		this.artworkCacheTab.ResumeLayout (false);
		this.ResumeLayout (false);

        }

        #endregion

	private System.Windows.Forms.TabPage scrobblerPage;
	private TagMonkey.UI.Lastfm.LastfmFrame lastfmScrobblerFrame1;
	private System.Windows.Forms.TabPage taggerPage;
	private System.Windows.Forms.TabControl tabControl;
	private TagMonkey.UI.AutoTagger.AutoTaggerFrame tagFiller;
	private System.Windows.Forms.TabPage artworkCacheTab;
	private TagMonkey.UI.ArtworkCacheViewer.ArtworkCacheFrame artworkCacheFrame;


    }
}

