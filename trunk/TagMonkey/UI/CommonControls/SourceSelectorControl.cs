using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using iTunesLib;

namespace TagMonkey.UI.CommonControls {
	partial class SourceSelectorControl : UserControl, ICanProposeButtons {
		public event EventHandler SelectedSourceChanged;
		public event EventHandler ProposedButtonsChanged; //unused

		private bool ipods_only = false;

		public SourceSelectorControl ()
		{
			InitializeComponent ();

			refreshButton.Click += (s, e)
				=> ITunez.CrashSafe (() => ScanSources ());

			sourcesComboBox.SelectedIndexChanged += (s, e)
				=> RaiseEvent ();
		}

		void SourceSelectorControl_Load (object sender, EventArgs e)
		{
			// scan or queue scanning
			if (ITunez.Instance != null)
				ScanSources ();
			else ITunez.Launched += (s, a) =>
				ScanSources ();
		}

		void ScanSources ()
		{
			Maek.Sure (ITunez.Instance != null, "iTunes не запущен.");
			iTunesApp app = ITunez.Instance;

			sourcesComboBox.Items.Clear ();
		
			List<ITSourceKind> look_for = new List<ITSourceKind> ();
			look_for.Add (ITSourceKind.ITSourceKindIPod);
			look_for.Add (ITSourceKind.ITSourceKindLibrary);
			look_for.Add (ITSourceKind.ITSourceKindSharedLibrary);

			foreach (IITSource src in app.Sources) {
				if (ipods_only && src.Kind != ITSourceKind.ITSourceKindIPod)
						continue;

				if (look_for.Contains (src.Kind))
					sourcesComboBox.Items.Add (src);
			}

			if (sourcesComboBox.Items.Count > 0) {
				Controlz.Enable (sourcesComboBox);
				if (sourcesComboBox.SelectedIndex == 0)
					RaiseEvent (); // just raise it

				else sourcesComboBox.SelectedIndex = 0; // it'll be raised
			}
		}

		void RaiseEvent ()
		{
			if (SelectedSourceChanged != null)
				SelectedSourceChanged (this, EventArgs.Empty);
		}

		public Button GetProposedAcceptButton ()
		{
			return refreshButton;
		}

		public Button GetProposedCancelButton ()
		{
			return null;
		}

		public IITSource SelectedSource {
			get { return (IITSource) sourcesComboBox.SelectedItem; }
		}

		public IITIPodSource SelectedIPod {
			get {
				Maek.Sure (SelectedSource is IITIPodSource, "Выбранное устройство — не айпод.");
				return (IITIPodSource) sourcesComboBox.SelectedItem;
			}
		}

		[DefaultValue (false)]
		public bool IPodsOnly {
			get { return ipods_only; }
			set { ipods_only = value; }
		}
	}
}
