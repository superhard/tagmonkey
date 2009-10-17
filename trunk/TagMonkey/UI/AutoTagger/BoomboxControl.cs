using System;
using System.ComponentModel;
using System.Windows.Forms;

using TagMonkey.UI.Common;

namespace TagMonkey.UI.AutoTagger {
	partial class BoomboxControl : UserControl, ICanProposeButtons {

		public event EventHandler Go;
		public event EventHandler Pause;
		public event EventHandler Resume;
		public event EventHandler Stop;

		public event EventHandler ProposedButtonsChanged;

		private bool go_mode = false;
		private bool paused = false;

		public BoomboxControl ()
		{
			InitializeComponent ();
		}

		void LaunchPanelControl_Load (object sender, EventArgs e)
		{
			RefreshButtonsState ();
		}

		void goButton_Click (object sender, EventArgs e)
		{
			Maek.Sure (!go_mode || paused, "Нельзя нажать Go дважды!");
			bool wasPaused = paused;
			go_mode = true;
			paused = false;
			RefreshButtonsState ();

			if (wasPaused && Resume != null)
				Resume (this, EventArgs.Empty);
			else if (!wasPaused && Go != null)
				Go (this, EventArgs.Empty);
		}

		void pauseButton_Click (object sender, EventArgs e)
		{
			Maek.Sure (go_mode, "Нельзя нажать Pause не в Go Mode.");
			Maek.Sure (!paused, "Нельзя дважды нажать Pause.");
			paused = true;
			RefreshButtonsState ();

			if (Pause != null)
				Pause (this, EventArgs.Empty);
		}

		void stopButton_Click (object sender, EventArgs e)
		{
			Maek.Sure (go_mode, "Нельзя нажать Stop не в Go Mode.");
			go_mode = false;
			paused = false;
			RefreshButtonsState ();

			if (Stop != null)
				Stop (this, EventArgs.Empty);
		}


		public void RefreshButtonsState ()
		{
			goButton.Enabled = !go_mode || paused;
			stopButton.Enabled = go_mode;
			pauseButton.Enabled = go_mode && !paused;

			if (ProposedButtonsChanged != null)
				ProposedButtonsChanged (this, EventArgs.Empty);
		}

		public void DoStop ()
		{
			Maek.Sure (go_mode, "Нельзя нажать Stop не в Go Mode.");
			go_mode = false;
			paused = false;
			RefreshButtonsState ();
		}

		public Button GetProposedAcceptButton ()
		{
			if (goButton.Enabled)
				return goButton;
			else if (pauseButton.Enabled)
				return pauseButton;

			return null; // not likely to ever happen
		}

		public Button GetProposedCancelButton ()
		{
			if (pauseButton.Enabled)
				return pauseButton;
			else if (stopButton.Enabled)
				return stopButton;

			return null;
		}

		public bool IsWorking {
			get { return go_mode; }
		}

		public bool IsPaused {
			get { return paused; }
		}
	}
}
