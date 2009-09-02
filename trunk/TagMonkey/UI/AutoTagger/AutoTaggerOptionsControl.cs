using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using TagMonkey.Taggers;
using TagMonkey.UI;
using TagMonkey.UI.CommonControls;
using TagMonkey.UI.Feedback;

namespace TagMonkey.UI.AutoTagger {
	partial class AutoTaggerOptionsControl : UserControl, ICanProposeButtons {

		public event EventHandler OptionsChanged;
		public event EventHandler ProposedButtonsChanged;

		public AutoTaggerOptionsControl ()
		{
			InitializeComponent ();
			
			EventHandler optionsChanged = new EventHandler (delegate {
				if (OptionsChanged != null)
					OptionsChanged (this, EventArgs.Empty);
			});

			formatNamesCheckBox.CheckedChanged += optionsChanged;
			searchForLyricsCheckBox.CheckedChanged += optionsChanged;
			onlyMissingLyricsCheckBox.CheckedChanged += optionsChanged;
			sortAlbumsByYearCheckBox.CheckedChanged += optionsChanged;
			downloadArtworkCheckBox.CheckedChanged += optionsChanged;
			setArtworkFromCacheCheckBox.CheckedChanged += optionsChanged;
			onlyMissingArtworkCheckBox.CheckedChanged += optionsChanged;
			this.Load += optionsChanged;

			searchForLyricsCheckBox.CheckedChanged += delegate {
				onlyMissingLyricsCheckBox.Enabled = searchForLyricsCheckBox.Checked;
			};

			downloadArtworkCheckBox.CheckedChanged += delegate {
				onlyMissingArtworkCheckBox.Enabled =
					setArtworkFromCacheCheckBox.Checked || downloadArtworkCheckBox.Checked; 
			};
			setArtworkFromCacheCheckBox.CheckedChanged += delegate {
				onlyMissingArtworkCheckBox.Enabled =
					setArtworkFromCacheCheckBox.Checked || downloadArtworkCheckBox.Checked;
			};
		}


		void viewArtworkCacheButton_Click (object sender, EventArgs e)
		{
			UI.Forms.MainForm.JumpToTab (MainForm.MainFormTab.ArtworkCache);
		}

		void showFeedbackCheckbox_CheckedChanged (object sender, EventArgs e)
		{
			feedbackControl.Visible = true;
			ProposedButtonsChanged (this, EventArgs.Empty);
			feedbackControl.Select ();
		}

		void feedbackControl_IdeaSent (object sender, EventArgs e)
		{
			showFeedbackCheckbox.Checked = false;
			feedbackControl.Visible = false;
			ProposedButtonsChanged (this, EventArgs.Empty);
		}

		public void SetBoldFeature (TaggerKind feature, bool value)
		{
			switch (feature) {
			case TaggerKind.NamesFormatter:
				SetBold (formatNamesCheckBox, value);
				break;
			case TaggerKind.LyricsTagger:
				SetBold (searchForLyricsCheckBox, value);
				break;
			case TaggerKind.AlbumsSorter:
				SetBold (sortAlbumsByYearCheckBox, value);
				break;
			case TaggerKind.ArtworkDownloader:
				SetBold (downloadArtworkCheckBox, value);
				break;
			case TaggerKind.ArtworkTagger:
				SetBold (setArtworkFromCacheCheckBox, value);
				break;
			default:
				throw new NotImplementedException ();
			}
		}

		void SetBold (CheckBox cb, bool value)
		{
			cb.Font = new Font (cb.Font, value ? FontStyle.Bold : FontStyle.Regular);
		}

		public AutoTaggerOptions Options {
			get {
				List<TaggerKind> taggers = new List<TaggerKind> ();
				if (formatNamesCheckBox.Checked)
					taggers.Add (TaggerKind.NamesFormatter);
				if (sortAlbumsByYearCheckBox.Checked)
					taggers.Add (TaggerKind.AlbumsSorter);
				if (searchForLyricsCheckBox.Checked)
					taggers.Add (TaggerKind.LyricsTagger);
				if (downloadArtworkCheckBox.Checked)
					taggers.Add (TaggerKind.ArtworkDownloader);
				if (setArtworkFromCacheCheckBox.Checked)
					taggers.Add (TaggerKind.ArtworkTagger);
			
				return new AutoTaggerOptions (taggers.AsReadOnly (),
					onlyMissingLyricsCheckBox.Checked,
					onlyMissingArtworkCheckBox.Checked);
			}
		}

		public Button GetProposedAcceptButton ()
		{
			return (feedbackControl.HasText && feedbackControl.Visible)
				? feedbackControl.GetProposedAcceptButton ()
				: viewArtworkCacheButton;
		}

		public Button GetProposedCancelButton ()
		{
			return null;
		}
	}
}
