using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

using TagMonkey.UI.Common;

using iTunesLib;

namespace TagMonkey.UI {
	partial class MainForm : Form {
		public enum MainFormTab {
			AutoTagger = 0,
			ArtworkCache = 1,
			Lastfm = 2
		}


		public MainForm ()
		{
			InitializeComponent ();

			AssemblyName name = Assembly.GetExecutingAssembly ().GetName ();
			this.Text = string.Format ("{0} {1}.{2}.{3}", name.Name,
				name.Version.Major, name.Version.Minor, name.Version.Build);
		}

		void MainForm_Load (object sender, EventArgs e)
		{
			Trace.WriteLine ("");
			Trace.WriteLine ("");
			Trace.WriteLine (string.Format ("Application launched {0}", DateTime.Now));
			Trace.Indent ();

			// disable all controls till itunes is launched
			Controlz.Disable (this);
			
			SubscribeToProposedButtonsChangedEvents (tabControl);
			SetProposedButtons ();
			tabControl.SelectedIndexChanged += (s, a) =>
				SetProposedButtons ();

			ITunez.Launched += (s, a) =>
				Controlz.Enable (this);
			ITunez.Go ();
		}

		void MainForm_KeyDown (object sender, KeyEventArgs e)
		{
			if (e.Control) {
				if (e.KeyCode == Keys.Left)
					SelectTabFromLeft ();
				else if (e.KeyCode == Keys.Right)
					SelectTabFromRight ();

				if (e.Alt && e.KeyCode == Keys.B) {
					while (MessageBox.Show ("А любишь ли ты Бориску так, как люблю её я?", "Люблю-люблю-люблю!", MessageBoxButtons.YesNoCancel,
						MessageBoxIcon.Question) != DialogResult.Yes)
						;
				}
			}
		}

		void SelectTabFromLeft ()
		{
			if (tabControl.SelectedIndex > 0)
				tabControl.SelectedIndex --;
		}

		void SelectTabFromRight ()
		{
			if (tabControl.SelectedIndex < tabControl.TabCount - 1)
				tabControl.SelectedIndex ++;
		}

		void SubscribeToProposedButtonsChangedEvents (Control c)
		{
			ICanProposeButtons ic = c as ICanProposeButtons;
			if (ic != null)
				ic.ProposedButtonsChanged += delegate { SetProposedButtons (); };

			foreach (Control ch in c.Controls) {
				SubscribeToProposedButtonsChangedEvents (ch);
			}
		}

		void SetProposedButtons ()
		{
			TabPage current = tabControl.SelectedTab;
			if (current.Controls.Count == 0)
				return;

			ICanProposeButtons root = current.Controls [0] as ICanProposeButtons;
			
			if (root != null) {
				base.AcceptButton = root.GetProposedAcceptButton ();
				base.CancelButton = root.GetProposedCancelButton ();
				Button ok = base.AcceptButton as Button;
				if (ok != null)
					ok.Select ();
			}
		}

		public void JumpToTab (MainFormTab tab)
		{
			tabControl.SelectTab ((int) tab);
		}
	}
}
