namespace TagMonkey.UI.Lastfm {
	partial class LastfmLoginControl {
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
			this.loginButton = new TagMonkey.UI.CommonControls.LoginButton ();
			this.statusLabel = new System.Windows.Forms.Label ();
			this.passwordTextBox = new TagMonkey.UI.ExtraControls.AutoSelectTextBox ();
			this.label2 = new System.Windows.Forms.Label ();
			this.loginTextBox = new TagMonkey.UI.ExtraControls.AutoSelectTextBox ();
			this.label1 = new System.Windows.Forms.Label ();
			this.groupBox1.SuspendLayout ();
			this.SuspendLayout ();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add (this.loginButton);
			this.groupBox1.Controls.Add (this.statusLabel);
			this.groupBox1.Controls.Add (this.passwordTextBox);
			this.groupBox1.Controls.Add (this.label2);
			this.groupBox1.Controls.Add (this.loginTextBox);
			this.groupBox1.Controls.Add (this.label1);
			this.groupBox1.Location = new System.Drawing.Point (3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size (473, 91);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Данные &аккаунта";
			// 
			// loginButton
			// 
			this.loginButton.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.loginButton.AskConfirmationOnLogout = true;
			this.loginButton.Font = new System.Drawing.Font ("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.loginButton.Location = new System.Drawing.Point (305, 16);
			this.loginButton.Margin = new System.Windows.Forms.Padding (4, 5, 4, 5);
			this.loginButton.Name = "loginButton";
			this.loginButton.Size = new System.Drawing.Size (162, 69);
			this.loginButton.TabIndex = 2;
			// 
			// statusLabel
			// 
			this.statusLabel.AutoSize = true;
			this.statusLabel.ForeColor = System.Drawing.Color.DimGray;
			this.statusLabel.Location = new System.Drawing.Point (6, 16);
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size (281, 13);
			this.statusLabel.TabIndex = 0;
			this.statusLabel.Text = "Введите свои логин и пароль для доступа к профилю:";
			// 
			// passwordTextBox
			// 
			this.passwordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.passwordTextBox.Location = new System.Drawing.Point (61, 61);
			this.passwordTextBox.Name = "passwordTextBox";
			this.passwordTextBox.Size = new System.Drawing.Size (235, 20);
			this.passwordTextBox.TabIndex = 1;
			this.passwordTextBox.UseSystemPasswordChar = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point (7, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size (48, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "&Пароль:";
			// 
			// loginTextBox
			// 
			this.loginTextBox.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.loginTextBox.Location = new System.Drawing.Point (61, 35);
			this.loginTextBox.Name = "loginTextBox";
			this.loginTextBox.Size = new System.Drawing.Size (235, 20);
			this.loginTextBox.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point (6, 38);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size (41, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "&Логин:";
			// 
			// LastfmLoginControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add (this.groupBox1);
			this.Name = "LastfmLoginControl";
			this.Size = new System.Drawing.Size (479, 103);
			this.Load += new System.EventHandler (this.LastfmLoginControl_Load);
			this.groupBox1.ResumeLayout (false);
			this.groupBox1.PerformLayout ();
			this.ResumeLayout (false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private TagMonkey.UI.ExtraControls.AutoSelectTextBox passwordTextBox;
		private System.Windows.Forms.Label label2;
		private TagMonkey.UI.ExtraControls.AutoSelectTextBox loginTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label statusLabel;
		private TagMonkey.UI.CommonControls.LoginButton loginButton;
	}
}
