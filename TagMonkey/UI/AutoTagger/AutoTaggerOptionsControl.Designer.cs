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
			this.getArtworkForCacheCheckBox = new System.Windows.Forms.CheckBox ();
			this.onlyMissingArtworkCheckBox = new System.Windows.Forms.CheckBox ();
			this.setArtworkFromCacheCheckBox = new System.Windows.Forms.CheckBox ();
			this.sortAlbumsByYearCheckBox = new System.Windows.Forms.CheckBox ();
			this.onlyMissingLyricsCheckBox = new System.Windows.Forms.CheckBox ();
			this.getLyricsCheckBox = new System.Windows.Forms.CheckBox ();
			this.formatNamesCheckBox = new System.Windows.Forms.CheckBox ();
			this.groupBox2 = new System.Windows.Forms.GroupBox ();
			this.groupBox3 = new System.Windows.Forms.GroupBox ();
			this.groupBox4 = new System.Windows.Forms.GroupBox ();
			this.onlyMissingGenresCheckBox = new System.Windows.Forms.CheckBox ();
			this.showFeedbackCheckbox = new System.Windows.Forms.CheckBox ();
			this.getGenresCheckBox = new System.Windows.Forms.CheckBox ();
			this.feedbackControl = new TagMonkey.UI.Feedback.FeedbackControl ();
			this.groupBox1.SuspendLayout ();
			this.groupBox2.SuspendLayout ();
			this.groupBox3.SuspendLayout ();
			this.groupBox4.SuspendLayout ();
			this.SuspendLayout ();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
				    | System.Windows.Forms.AnchorStyles.Left)));
			this.groupBox1.Controls.Add (this.viewArtworkCacheButton);
			this.groupBox1.Controls.Add (this.getArtworkForCacheCheckBox);
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
			// getArtworkForCacheCheckBox
			// 
			this.getArtworkForCacheCheckBox.AutoSize = true;
			this.getArtworkForCacheCheckBox.Location = new System.Drawing.Point (6, 19);
			this.getArtworkForCacheCheckBox.Name = "getArtworkForCacheCheckBox";
			this.getArtworkForCacheCheckBox.Size = new System.Drawing.Size (114, 17);
			this.getArtworkForCacheCheckBox.TabIndex = 6;
			this.getArtworkForCacheCheckBox.Text = "С&качать обложки";
			this.getArtworkForCacheCheckBox.UseVisualStyleBackColor = true;
			// 
			// onlyMissingArtworkCheckBox
			// 
			this.onlyMissingArtworkCheckBox.AutoSize = true;
			this.onlyMissingArtworkCheckBox.Enabled = false;
			this.onlyMissingArtworkCheckBox.Location = new System.Drawing.Point (15, 65);
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
			// getLyricsCheckBox
			// 
			this.getLyricsCheckBox.AutoSize = true;
			this.getLyricsCheckBox.Location = new System.Drawing.Point (6, 19);
			this.getLyricsCheckBox.Name = "getLyricsCheckBox";
			this.getLyricsCheckBox.Size = new System.Drawing.Size (102, 17);
			this.getLyricsCheckBox.TabIndex = 1;
			this.getLyricsCheckBox.Text = "&Искать тексты";
			this.getLyricsCheckBox.UseVisualStyleBackColor = true;
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
			this.groupBox3.Controls.Add (this.getLyricsCheckBox);
			this.groupBox3.Location = new System.Drawing.Point (3, 74);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size (286, 67);
			this.groupBox3.TabIndex = 9;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Поиск текстов";
			// 
			// groupBox4
			// 
			this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox4.Controls.Add (this.feedbackControl);
			this.groupBox4.Controls.Add (this.onlyMissingGenresCheckBox);
			this.groupBox4.Controls.Add (this.showFeedbackCheckbox);
			this.groupBox4.Controls.Add (this.getGenresCheckBox);
			this.groupBox4.Location = new System.Drawing.Point (522, 3);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size (311, 138);
			this.groupBox4.TabIndex = 10;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Дополнительно";
			// 
			// onlyMissingGenresCheckBox
			// 
			this.onlyMissingGenresCheckBox.AutoSize = true;
			this.onlyMissingGenresCheckBox.Location = new System.Drawing.Point (16, 42);
			this.onlyMissingGenresCheckBox.Name = "onlyMissingGenresCheckBox";
			this.onlyMissingGenresCheckBox.Size = new System.Drawing.Size (185, 17);
			this.onlyMissingGenresCheckBox.TabIndex = 9;
			this.onlyMissingGenresCheckBox.Text = "только для файлов без ж&анров";
			this.onlyMissingGenresCheckBox.UseVisualStyleBackColor = true;
			// 
			// showFeedbackCheckbox
			// 
			this.showFeedbackCheckbox.AutoSize = true;
			this.showFeedbackCheckbox.Font = new System.Drawing.Font ("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.showFeedbackCheckbox.Location = new System.Drawing.Point (6, 65);
			this.showFeedbackCheckbox.Name = "showFeedbackCheckbox";
			this.showFeedbackCheckbox.Size = new System.Drawing.Size (83, 17);
			this.showFeedbackCheckbox.TabIndex = 7;
			this.showFeedbackCheckbox.Text = "Есть ид&ея?";
			this.showFeedbackCheckbox.UseVisualStyleBackColor = true;
			this.showFeedbackCheckbox.CheckedChanged += new System.EventHandler (this.showFeedbackCheckbox_CheckedChanged);
			// 
			// getGenresCheckBox
			// 
			this.getGenresCheckBox.AutoSize = true;
			this.getGenresCheckBox.Location = new System.Drawing.Point (6, 19);
			this.getGenresCheckBox.Name = "getGenresCheckBox";
			this.getGenresCheckBox.Size = new System.Drawing.Size (122, 17);
			this.getGenresCheckBox.TabIndex = 7;
			this.getGenresCheckBox.Text = "Расставить &жанры";
			this.getGenresCheckBox.UseVisualStyleBackColor = true;
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
			// AutoTaggerOptionsControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add (this.groupBox4);
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
			this.groupBox4.ResumeLayout (false);
			this.groupBox4.PerformLayout ();
			this.ResumeLayout (false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox formatNamesCheckBox;
		private System.Windows.Forms.CheckBox getLyricsCheckBox;
		private System.Windows.Forms.CheckBox onlyMissingLyricsCheckBox;
		private System.Windows.Forms.CheckBox sortAlbumsByYearCheckBox;
		private System.Windows.Forms.CheckBox onlyMissingArtworkCheckBox;
		private System.Windows.Forms.CheckBox setArtworkFromCacheCheckBox;
		private System.Windows.Forms.CheckBox getArtworkForCacheCheckBox;
		private System.Windows.Forms.Button viewArtworkCacheButton;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.CheckBox getGenresCheckBox;
		private System.Windows.Forms.CheckBox showFeedbackCheckbox;
		private TagMonkey.UI.Feedback.FeedbackControl feedbackControl;
		private System.Windows.Forms.CheckBox onlyMissingGenresCheckBox;
	}
}
