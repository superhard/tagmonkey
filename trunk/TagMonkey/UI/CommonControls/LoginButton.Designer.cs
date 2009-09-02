namespace TagMonkey.UI.CommonControls {
	partial class LoginButton {
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
			this.button = new System.Windows.Forms.Button ();
			this.SuspendLayout ();
			// 
			// button
			// 
			this.button.Dock = System.Windows.Forms.DockStyle.Fill;
			this.button.Location = new System.Drawing.Point (0, 0);
			this.button.Margin = new System.Windows.Forms.Padding (0);
			this.button.Name = "button";
			this.button.Size = new System.Drawing.Size (121, 46);
			this.button.TabIndex = 0;
			this.button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.button.UseVisualStyleBackColor = true;
			this.button.Click += new System.EventHandler (this.button_Click);
			// 
			// LoginButton
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF (9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add (this.button);
			this.Font = new System.Drawing.Font ("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.Margin = new System.Windows.Forms.Padding (4, 5, 4, 5);
			this.Name = "LoginButton";
			this.Size = new System.Drawing.Size (121, 46);
			this.Load += new System.EventHandler (this.LoginButton_Load);
			this.ResumeLayout (false);

		}

		#endregion

		private System.Windows.Forms.Button button;
	}
}
