namespace TagMonkey.UI.AutoTagger {
	partial class AutoTaggerOptionsControl {
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
			this.viewArtworkCacheButton = new System.Windows.Forms.Button ();
			this.downloadArtworkCheckBox = new System.Windows.Forms.CheckBox ();
			this.onlyMissingArtworkCheckBox = new System.Windows.Forms.CheckBox ();
			this.setArtworkFromCacheCheckBox = new System.Windows.Forms.CheckBox ();
			this.sortAlbumsByYearCheckBox = new System.Windows.Forms.CheckBox ();
			this.onlyMissingLyricsCheckBox = new System.Windows.Forms.CheckBox ();
			this.searchForLyricsCheckBox = new System.Windows.Forms.CheckBox ();
			this.formatNamesCheckBox = new System.Windows.Forms.CheckBox ();
			this.groupBox2 = new System.Windows.Forms.GroupBox ();
			this.groupBox3 = new System.Windows.Forms.GroupBox ();
			this.nextVersionsGroupBox = new System.Windows.Forms.GroupBox ();
			this.feedbackControl = new TagMonkey.UI.Feedback.FeedbackControl ();
			this.showFeedbackCheckbox = new System.Windows.Forms.CheckBox ();
			this.checkBox2 = new System.Windows.Forms.CheckBox ();
			this.checkBox1 = new System.Windows.Forms.CheckBox ();
			this.groupBox1.SuspendLayout ();
			this.groupBox2.SuspendLayout ();
			this.groupBox3.SuspendLayout ();
			this.nextVersionsGroupBox.SuspendLayout ();
			this.SuspendLayout ();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
				    | System.Windows.Forms.AnchorStyles.Left)));
			this.groupBox1.Controls.Add (this.viewArtworkCacheButton);
			this.groupBox1.Controls.Add (this.downloadArtworkCheckBox);
			this.groupBox1.Controls.Add (this.onlyMissingArtworkCheckBox);
			this.groupBox1.Controls.Add (this.setArtworkFromCacheCheckBox);
			this.groupBox1.Location = new System.Drawing.Point (305, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size (211, 138);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Поиск обложек";
			// 
			// viewArtworkCacheButton
			// 
			this.viewArtworkCacheButton.Font = new System.Drawing.Font ("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.viewArtworkCacheButton.Image = global::TagMonkey.Properties.Resources.pictureIcon;
			this.viewArtworkCacheButton.Location = new System.Drawing.Point (19, 88);
			this.viewArtworkCacheButton.Name = "viewArtworkCacheButton";
			this.viewArtworkCacheButton.Size = new System.Drawing.Size (174, 40);
			this.viewArtworkCacheButton.TabIndex = 7;
			this.viewArtworkCacheButton.Text = "    &Кэш обложек...";
			this.viewArtworkCacheButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.viewArtworkCacheButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.viewArtworkCacheButton.UseVisualStyleBackColor = true;
			this.viewArtworkCacheButton.Click += new System.EventHandler (this.viewArtworkCacheButton_Click);
			// 
			// downloadArtworkCheckBox
			// 
			this.downloadArtworkCheckBox.AutoSize = true;
			this.downloadArtworkCheckBox.Location = new System.Drawing.Point (6, 19);
			this.downloadArtworkCheckBox.Name = "downloadArtworkCheckBox";
			this.downloadArtworkCheckBox.Size = new System.Drawing.Size (114, 17);
			this.downloadArtworkCheckBox.TabIndex = 6;
			this.downloadArtworkCheckBox.Text = "С&качать обложки";
			this.downloadArtworkCheckBox.UseVisualStyleBackColor = true;
			// 
			// onlyMissingArtworkCheckBox
			// 
			this.onlyMissingArtworkCheckBox.AutoSize = true;
			this.onlyMissingArtworkCheckBox.Enabled = false;
			this.onlyMissingArtworkCheckBox.Location = new System.Drawing.Point (13, 65);
			this.onlyMissingArtworkCheckBox.Name = "onlyMissingArtworkCheckBox";
			this.onlyMissingArtworkCheckBox.Size = new System.Drawing.Size (191, 17);
			this.onlyMissingArtworkCheckBox.TabIndex = 5;
			this.onlyMissingArtworkCheckBox.Text = "только для файлов без &обложек";
			this.onlyMissingArtworkCheckBox.UseVisualStyleBackColor = true;
			// 
			// setArtworkFromCacheCheckBox
			// 
			this.setArtworkFromCacheCheckBox.AutoSize = true;
			this.setArtworkFromCacheCheckBox.Location = new System.Drawing.Point (6, 42);
			this.setArtworkFromCacheCheckBox.Name = "setArtworkFromCacheCheckBox";
			this.setArtworkFromCacheCheckBox.Size = new System.Drawing.Size (155, 17);
			this.setArtworkFromCacheCheckBox.TabIndex = 4;
			this.setArtworkFromCacheCheckBox.Text = "&Записать обложки в теги";
			this.setArtworkFromCacheCheckBox.UseVisualStyleBackColor = true;
			// 
			// sortAlbumsByYearCheckBox
			// 
			this.sortAlbumsByYearCheckBox.AutoSize = true;
			this.sortAlbumsByYearCheckBox.Location = new System.Drawing.Point (6, 42);
			this.sortAlbumsByYearCheckBox.Name = "sortAlbumsByYearCheckBox";
			this.sortAlbumsByYearCheckBox.Size = new System.Drawing.Size (189, 17);
			this.sortAlbumsByYearCheckBox.TabIndex = 3;
			this.sortAlbumsByYearCheckBox.Text = "&Сортировать альбомы по годам";
			this.sortAlbumsByYearCheckBox.UseVisualStyleBackColor = true;
			// 
			// onlyMissingLyricsCheckBox
			// 
			this.onlyMissingLyricsCheckBox.AutoSize = true;
			this.onlyMissingLyricsCheckBox.Enabled = false;
			this.onlyMissingLyricsCheckBox.Location = new System.Drawing.Point (17, 42);
			this.onlyMissingLyricsCheckBox.Name = "onlyMissingLyricsCheckBox";
			this.onlyMissingLyricsCheckBox.Size = new System.Drawing.Size (187, 17);
			this.onlyMissingLyricsCheckBox.TabIndex = 2;
			this.onlyMissingLyricsCheckBox.Text = "только для файлов без &текстов";
			this.onlyMissingLyricsCheckBox.UseVisualStyleBackColor = true;
			// 
			// searchForLyricsCheckBox
			// 
			this.searchForLyricsCheckBox.AutoSize = true;
			this.searchForLyricsCheckBox.Location = new System.Drawing.Point (6, 19);
			this.searchForLyricsCheckBox.Name = "searchForLyricsCheckBox";
			this.searchForLyricsCheckBox.Size = new System.Drawing.Size (102, 17);
			this.searchForLyricsCheckBox.TabIndex = 1;
			this.searchForLyricsCheckBox.Text = "&Искать тексты";
			this.searchForLyricsCheckBox.UseVisualStyleBackColor = true;
			// 
			// formatNamesCheckBox
			// 
			this.formatNamesCheckBox.AutoSize = true;
			this.formatNamesCheckBox.Enabled = false;
			this.formatNamesCheckBox.Location = new System.Drawing.Point (6, 19);
			this.formatNamesCheckBox.Name = "formatNamesCheckBox";
			this.formatNamesCheckBox.Size = new System.Drawing.Size (272, 17);
			this.formatNamesCheckBox.TabIndex = 0;
			this.formatNamesCheckBox.Text = "От&форматировать названия песен по стандарту";
			this.formatNamesCheckBox.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add (this.formatNamesCheckBox);
			this.groupBox2.Controls.Add (this.sortAlbumsByYearCheckBox);
			this.groupBox2.Location = new System.Drawing.Point (3, 3);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size (286, 65);
			this.groupBox2.TabIndex = 8;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Основные операции";
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
				    | System.Windows.Forms.AnchorStyles.Left)));
			this.groupBox3.Controls.Add (this.onlyMissingLyricsCheckBox);
			this.groupBox3.Controls.Add (this.searchForLyricsCheckBox);
			this.groupBox3.Location = new System.Drawing.Point (3, 74);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size (286, 67);
			this.groupBox3.TabIndex = 9;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Поиск текстов";
			// 
			// nextVersionsGroupBox
			// 
			this.nextVersionsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.nextVersionsGroupBox.Controls.Add (this.feedbackControl);
			this.nextVersionsGroupBox.Controls.Add (this.showFeedbackCheckbox);
			this.nextVersionsGroupBox.Controls.Add (this.checkBox2);
			this.nextVersionsGroupBox.Controls.Add (this.checkBox1);
			this.nextVersionsGroupBox.Location = new System.Drawing.Point (522, 3);
			this.nextVersionsGroupBox.Name = "nextVersionsGroupBox";
			this.nextVersionsGroupBox.Size = new System.Drawing.Size (311, 138);
			this.nextVersionsGroupBox.TabIndex = 10;
			this.nextVersionsGroupBox.TabStop = false;
			this.nextVersionsGroupBox.Text = "В следующих версиях";
			// 
			// feedbackControl
			// 
			this.feedbackControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.feedbackControl.Location = new System.Drawing.Point (3, 16);
			this.feedbackControl.Name = "feedbackControl";
			this.feedbackControl.Size = new System.Drawing.Size (305, 119);
			this.feedbackControl.TabIndex = 8;
			this.feedbackControl.Visible = false;
			this.feedbackControl.HideRequested += new System.EventHandler (this.feedbackControl_IdeaSent);
			// 
			// showFeedbackCheckbox
			// 
			this.showFeedbackCheckbox.AutoSize = true;
			this.showFeedbackCheckbox.Font = new System.Drawing.Font ("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.showFeedbackCheckbox.Location = new System.Drawing.Point (6, 65);
			this.showFeedbackCheckbox.Name = "showFeedbackCheckbox";
			this.showFeedbackCheckbox.Size = new System.Drawing.Size (122, 17);
			this.showFeedbackCheckbox.TabIndex = 7;
			this.showFeedbackCheckbox.Text = "А что думаешь т&ы?";
			this.showFeedbackCheckbox.UseVisualStyleBackColor = true;
			this.showFeedbackCheckbox.CheckedChanged += new System.EventHandler (this.showFeedbackCheckbox_CheckedChanged);
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Enabled = false;
			this.checkBox2.Location = new System.Drawing.Point (6, 42);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size (260, 17);
			this.checkBox2.TabIndex = 7;
			this.checkBox2.Text = "&Проверить правильность нумерации дорожек";
			this.checkBox2.UseVisualStyleBackColor = true;
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Enabled = false;
			this.checkBox1.Location = new System.Drawing.Point (6, 19);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size (207, 17);
			this.checkBox1.TabIndex = 7;
			this.checkBox1.Text = "Расставить &жанры по тегам Last.fm";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// AutoTaggerOptionsControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add (this.nextVersionsGroupBox);
			this.Controls.Add (this.groupBox3);
			this.Controls.Add (this.groupBox2);
			this.Controls.Add (this.groupBox1);
			this.Name = "AutoTaggerOptionsControl";
			this.Size = new System.Drawing.Size (836, 141);
			this.groupBox1.ResumeLayout (false);
			this.groupBox1.PerformLayout ();
			this.groupBox2.ResumeLayout (false);
			this.groupBox2.PerformLayout ();
			this.groupBox3.ResumeLayout (false);
			this.groupBox3.PerformLayout ();
			this.nextVersionsGroupBox.ResumeLayout (false);
			this.nextVersionsGroupBox.PerformLayout ();
			this.ResumeLayout (false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox formatNamesCheckBox;
		private System.Windows.Forms.CheckBox searchForLyricsCheckBox;
		private System.Windows.Forms.CheckBox onlyMissingLyricsCheckBox;
		private System.Windows.Forms.CheckBox sortAlbumsByYearCheckBox;
		private System.Windows.Forms.CheckBox onlyMissingArtworkCheckBox;
		private System.Windows.Forms.CheckBox setArtworkFromCacheCheckBox;
		private System.Windows.Forms.CheckBox downloadArtworkCheckBox;
		private System.Windows.Forms.Button viewArtworkCacheButton;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox nextVersionsGroupBox;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.CheckBox showFeedbackCheckbox;
		private TagMonkey.UI.Feedback.FeedbackControl feedbackControl;
	}
}
