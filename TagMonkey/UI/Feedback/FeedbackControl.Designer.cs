namespace TagMonkey.UI.Feedback {
	partial class FeedbackControl {
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
			this.sendIdeaButton = new System.Windows.Forms.Button ();
			this.hideButton = new System.Windows.Forms.Button ();
			this.ideaTextBox = new TagMonkey.UI.Extra.SelectOnCtrlATextBox ();
			this.SuspendLayout ();
			// 
			// sendIdeaButton
			// 
			this.sendIdeaButton.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.sendIdeaButton.Font = new System.Drawing.Font ("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.sendIdeaButton.Image = global::TagMonkey.Properties.Resources.ideaIcon;
			this.sendIdeaButton.Location = new System.Drawing.Point (49, 158);
			this.sendIdeaButton.Name = "sendIdeaButton";
			this.sendIdeaButton.Size = new System.Drawing.Size (305, 40);
			this.sendIdeaButton.TabIndex = 1;
			this.sendIdeaButton.Text = "&Шепнуть разработчику на ухо";
			this.sendIdeaButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.sendIdeaButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.sendIdeaButton.UseVisualStyleBackColor = true;
			this.sendIdeaButton.Click += new System.EventHandler (this.sendIdeaButton_Click);
			// 
			// hideButton
			// 
			this.hideButton.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.hideButton.Location = new System.Drawing.Point (3, 158);
			this.hideButton.Name = "hideButton";
			this.hideButton.Size = new System.Drawing.Size (40, 40);
			this.hideButton.TabIndex = 2;
			this.hideButton.Text = "<<";
			this.hideButton.UseVisualStyleBackColor = true;
			this.hideButton.Click += new System.EventHandler (this.hideButton_Click);
			// 
			// ideaTextBox
			// 
			this.ideaTextBox.AcceptsReturn = true;
			this.ideaTextBox.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
				    | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.ideaTextBox.Font = new System.Drawing.Font ("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.ideaTextBox.Location = new System.Drawing.Point (3, 3);
			this.ideaTextBox.Multiline = true;
			this.ideaTextBox.Name = "ideaTextBox";
			this.ideaTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.ideaTextBox.Size = new System.Drawing.Size (351, 149);
			this.ideaTextBox.TabIndex = 0;
			this.ideaTextBox.TextChanged += new System.EventHandler (this.ideaTextBox_TextChanged);
			// 
			// FeedbackControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add (this.hideButton);
			this.Controls.Add (this.sendIdeaButton);
			this.Controls.Add (this.ideaTextBox);
			this.Name = "FeedbackControl";
			this.Size = new System.Drawing.Size (357, 201);
			this.Load += new System.EventHandler (this.FeedbackControl_Load);
			this.Enter += new System.EventHandler (this.FeedbackControl_Enter);
			this.ResumeLayout (false);
			this.PerformLayout ();

		}

		#endregion

		private TagMonkey.UI.Extra.SelectOnCtrlATextBox ideaTextBox;
		private System.Windows.Forms.Button sendIdeaButton;
		private System.Windows.Forms.Button hideButton;
	}
}
