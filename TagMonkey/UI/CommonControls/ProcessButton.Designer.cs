namespace TagMonkey.UI.CommonControls {
	partial class ProcessButton {
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
			this.worker = new System.ComponentModel.BackgroundWorker ();
			this.SuspendLayout ();
			// 
			// button
			// 
			this.button.Dock = System.Windows.Forms.DockStyle.Fill;
			this.button.Location = new System.Drawing.Point (0, 0);
			this.button.Margin = new System.Windows.Forms.Padding (0);
			this.button.Name = "button";
			this.button.Size = new System.Drawing.Size (154, 82);
			this.button.TabIndex = 0;
			this.button.Text = "button1";
			this.button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.button.UseVisualStyleBackColor = true;
			this.button.Click += new System.EventHandler (this.button_Click);
			// 
			// worker
			// 
			this.worker.WorkerSupportsCancellation = true;
			this.worker.DoWork += new System.ComponentModel.DoWorkEventHandler (this.worker_DoWork);
			this.worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler (this.worker_RunWorkerCompleted);
			// 
			// ProcessButton
			// 
			this.Controls.Add (this.button);
			this.Name = "ProcessButton";
			this.Size = new System.Drawing.Size (154, 82);
			this.Load += new System.EventHandler (this.ProcessButton_Load);
			this.ResumeLayout (false);

		}

		#endregion

		private System.Windows.Forms.Button button;
		private System.ComponentModel.BackgroundWorker worker;
	}
}
