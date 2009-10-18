using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using TagMonkey.Properties;

namespace TagMonkey.UI.Common {
	partial class ProcessButton : UserControl, ICanProposeButtons {

		private Image buttonImage = null;
		private string buttonText = string.Empty;
		private string cancelText = "&Остановить";

		public event EventHandler<BeforeWorkEventArgs> BeforeWork;
		public event DoWorkEventHandler DoWork;
		public event RunWorkerCompletedEventHandler AfterWork;
		public event EventHandler ProposedButtonsChanged;

		public ProcessButton ()
		{
			InitializeComponent ();

			if (ParentForm != null)
				ParentForm.FormClosing += delegate { worker.CancelAsync (); };
		}

		void ProcessButton_Load (object sender, EventArgs e)
		{
			RefreshButtonState ();
		}

		void button_Click (object sender, EventArgs e)
		{
			Maek.Sure (BeforeWork != null, "Событие BeforeWork не мониторится.");

			if (worker.IsBusy) {
				worker.CancelAsync ();
			}  else {
				BeforeWorkEventArgs args = new BeforeWorkEventArgs ();
				BeforeWork (this, args);

				if (args.CanProceed)
					worker.RunWorkerAsync (args.Argument);
			}

			RefreshButtonState ();
		}

		void worker_DoWork (object sender, DoWorkEventArgs e)
		{
			Maek.Sure (DoWork != null, "Событие DoWork не мониторится.");
			DoWork (this, e);

			if (worker.CancellationPending)
				e.Cancel = true;
		}

		void worker_RunWorkerCompleted (object sender, RunWorkerCompletedEventArgs e)
		{
			if (AfterWork != null)
				AfterWork (this, e);

			RefreshButtonState ();
		}


		void RefreshButtonState ()
		{
			button.Enabled = !worker.CancellationPending; // make a databinding?

			if (worker.IsBusy) {
				button.Text = cancelText;
				button.Image = Resources.cancelIcon;
			} else {
				button.Text = buttonText;
				button.Image = buttonImage;
			}

			if (ProposedButtonsChanged != null)
				ProposedButtonsChanged (this, EventArgs.Empty);
		}

		public Button GetProposedAcceptButton ()
		{
			if (button.Enabled && !IsBusy)
				return button;
			
			return null;
		}

		public Button GetProposedCancelButton ()
		{
			if (button.Enabled && IsBusy)
				return button;
		
			return null;
		}

		public Image ButtonImage {
			get { return buttonImage; }
			set {
				buttonImage = value;
				RefreshButtonState ();
			}
		}

		public string ButtonText {
			get { return buttonText; }
			set {
				buttonText = value;
				RefreshButtonState ();
			}
		}

		public string CancelText {
			get { return cancelText; }
			set
			{
				cancelText = value;
				RefreshButtonState ();
			}
		}

		public bool CancellationPending {
			get { return worker.CancellationPending; }
		}

		public bool IsBusy {
			get { return worker.IsBusy; }
		}
	}
}
