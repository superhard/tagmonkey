using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using iTunesLib;

namespace TagMonkey.UI.Common {
	partial class SourceSelectorControl : UserControl, ICanProposeButtons {

		public class SelectionSourceItem {
			public SelectionSourceItem () { }

			public string Name {
				get { return "Выбранные треки"; }
			}
		}

		public event EventHandler SelectedSourceChanged;
		public event EventHandler ProposedButtonsChanged; //unused

		private bool ipods_only = false;
		private bool include_selection = false;

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

			if (include_selection)
				sourcesComboBox.Items.Add (new SelectionSourceItem ());

			if (sourcesComboBox.Items.Count > 0) {
				int defaultIndex = (include_selection) ? sourcesComboBox.Items.Count - 1 : 0;

				Controlz.Enable (sourcesComboBox);
				if (sourcesComboBox.SelectedIndex == defaultIndex)
					RaiseEvent (); // just raise it

				else sourcesComboBox.SelectedIndex = defaultIndex; // it'll be raised
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

		public object SelectedItem {
			get { return sourcesComboBox.SelectedItem; }
		}

		public IITSource SelectedSource {
			get {
				Maek.Sure (sourcesComboBox.SelectedItem is IITSource, "Выбранный вариант  — не IITSource.");
				return (IITSource) sourcesComboBox.SelectedItem;
			}
		}

		public IITIPodSource SelectedIPod {
			get {
				Maek.Sure (SelectedSource is IITIPodSource, "Выбранный вариант — не IITIPodSource.");
				return (IITIPodSource) SelectedSource;
			}
		}

		[DefaultValue (false)]
		public bool IPodsOnly {
			get { return ipods_only; }
			set { ipods_only = value; }
		}

		[DefaultValue (false)]
		public bool IncludeSelection
		{
			get { return include_selection; }
			set { include_selection = value; }
		}
	}
}
