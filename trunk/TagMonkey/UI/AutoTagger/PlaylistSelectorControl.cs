using System;
using System.Collections.Generic;
using System.Windows.Forms;

using TagMonkey.UI.CommonControls;

using iTunesLib;

namespace TagMonkey.UI.AutoTagger {
	partial class PlaylistSelectorControl : UserControl, ICanProposeButtons {

		public event EventHandler SelectedPlaylistChanged;
		public event EventHandler ProposedButtonsChanged;

		public PlaylistSelectorControl ()
		{
			InitializeComponent ();
			playlistComboBox.Enabled = false; // disable till device is selected
	
			deviceSelector.IPodsOnly = false;
			deviceSelector.SelectedSourceChanged += delegate {
				ITunez.CrashSafe (() => ScanDeviceForPlaylists ());
			};

			playlistComboBox.SelectedValueChanged += delegate {
				RaiseSelectedPlaylistChangedEvent ();
			};
		}
		
		void FillPlaylists (IITSource device)
		{
			Maek.Sure (device != null, "Не было выбрано устройство.");
			playlistComboBox.Items.Clear ();

			foreach (IITUserPlaylist playlist in GetUserPlaylists (device))
				playlistComboBox.Items.Add (playlist);

			bool hasPlaylists = (playlistComboBox.Items.Count > 0);
			playlistComboBox.Enabled = hasPlaylists;

			if (hasPlaylists) {
				if (playlistComboBox.SelectedIndex == 0)
					RaiseSelectedPlaylistChangedEvent (); // fire it anyways

				else playlistComboBox.SelectedIndex = 0;
			}
		}

		IEnumerable<IITUserPlaylist> GetUserPlaylists (IITSource dev)
		{
			foreach (IITPlaylist playlist in dev.Playlists) {
				IITUserPlaylist pl = playlist as IITUserPlaylist;

				if (pl == null || pl.Tracks.Count == 0)
					continue;

				if (pl.SpecialKind == ITUserPlaylistSpecialKind.ITUserPlaylistSpecialKindMusic)
					yield return pl;

				else if (pl.SpecialKind == ITUserPlaylistSpecialKind.ITUserPlaylistSpecialKindNone
					&& !IsSpecialPlaylist (pl))
					yield return pl;
			}
		}

		bool IsSpecialPlaylist (IITUserPlaylist pl)
		{
			Maek.Sure (pl.Tracks.Count > 0, "Пустой плейлист!");
			if (pl.Smart || pl.Shuffle)
				return true;

			// on iPod's, Podcasts folder has no special marks
			// so we have to check the contents
			IITFileOrCDTrack tr = pl.Tracks.get_ItemByPlayOrder (1) as IITFileOrCDTrack;
			if (tr.Podcast)
				return true;

			return false;
		}

		void RaiseSelectedPlaylistChangedEvent ()
		{
			if (SelectedPlaylistChanged != null)
				SelectedPlaylistChanged (this, EventArgs.Empty);
		}

		void ScanDeviceForPlaylists ()
		{
			IITSource device = deviceSelector.SelectedSource;
			if (device != null)
				FillPlaylists (device);
			else
				playlistComboBox.Enabled = false;
		}

		public IITUserPlaylist SelectedPlaylist {
			get { return playlistComboBox.SelectedItem as IITUserPlaylist; }
		}

		public Button GetProposedAcceptButton ()
		{
			return deviceSelector.GetProposedAcceptButton ();
		}

		public Button GetProposedCancelButton ()
		{
			return deviceSelector.GetProposedCancelButton ();
		}
	}
}
