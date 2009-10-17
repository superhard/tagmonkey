using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Forms;

using iTunesLib;
using TagMonkey.UI.Common;
using TagMonkey.Properties;

namespace TagMonkey.UI.Lastfm {
	public partial class DeviceScannerControl : UserControl, ICanProposeButtons {

		public event EventHandler TracksToScrobbleChanged;
		public event EventHandler ScanningStarted;
		public event EventHandler ProposedButtonsChanged;

		private const string DynamicPlaylistName = "Last.fm Queue";
		private const string StaticPlaylistName = "Last.fm Temporary Queue";
		
		public DeviceScannerControl ()
		{
			InitializeComponent ();

			Controlz.Disable (scanButton);

			trackList.SelectedTracksChanged += delegate {
				if (TracksToScrobbleChanged != null)
					TracksToScrobbleChanged (this, EventArgs.Empty);
			};

			deviceSelector.IPodsOnly = true;
			deviceSelector.SelectedSourceChanged += delegate {
				scanButton.Enabled = (deviceSelector.SelectedSource != null);
			};			
		}

		void scanButton_BeforeWork (object sender, BeforeWorkEventArgs e)
		{
			e.CanProceed = false;
			trackList.Clear ();

			IITIPodSource src = deviceSelector.SelectedIPod;

			if (src == null)
				return;

			IITUserPlaylist dynQueue = ITunez.CrashSafe (() =>
				src.Playlists.get_ItemByName (DynamicPlaylistName) as IITUserPlaylist);

			if (dynQueue == null) {
				ShowCreateQueueMessage ();
				return;
			}

			Controlz.Disable (trackList);
			e.Argument = dynQueue;
			e.CanProceed = true;
		}

		void scanButton_DoWork (object sender, DoWorkEventArgs e)
		{
			IITUserPlaylist dynQueue = (IITUserPlaylist) e.Argument;
			IITSource device = ITunez.CrashSafe (() => dynQueue.Source);
			IITUserPlaylist stQueue = CreateStaticPlaylist (device);

			int i, n = ITunez.CrashSafe (() => dynQueue.Tracks.Count);
			for (i = 1; i <= n; i++) {
				ITunez.CrashSafe (() => {
					IITFileOrCDTrack track = (IITFileOrCDTrack) dynQueue.Tracks [i];
					if (track.VideoKind == ITVideoKind.ITVideoKindNone) { //  // filter out movies
						object objT = track;
						stQueue.AddTrack (ref objT);
					}
				});
			}

			n = i;
			for (i = 1; i < n; i++) {
				IITFileOrCDTrack track = (IITFileOrCDTrack) ITunez.CrashSafe (() => stQueue.Tracks [i]);
				if (scanButton.CancellationPending) {
					e.Cancel = true;
					return;
				}

				if (track != null && IsScrobblable(track))
					Controlz.ThreadSafe (() => trackList.AddTrack (track));
			}
		}

		void scanButton_AfterWork (object sender, RunWorkerCompletedEventArgs e)
		{
			if (e.Cancelled)
				trackList.Clear ();

			Controlz.Enable (trackList);

			if (ScanningStarted != null)
				ScanningStarted (this, EventArgs.Empty);
		}


		bool IsScrobblable (IITFileOrCDTrack t)
		{
			return ITunez.CrashSafe (() => 
				t.PlayedCount > 0
				&& !string.IsNullOrEmpty (t.Artist)
				&& !string.IsNullOrEmpty (t.Name)
				&& !t.Podcast);
		}

		IITUserPlaylist CreateStaticPlaylist (IITSource device)
		{
			DeleteStaticPlaylist (device);

			object objDevice = device;
			return (IITUserPlaylist) ITunez.CrashSafe (() => ITunez.Instance
				.CreatePlaylistInSource (StaticPlaylistName, ref objDevice));
		}

		void DeleteStaticPlaylist (IITSource ipod)
		{
			IITUserPlaylist pl = ITunez.CrashSafe (() =>
				ipod.Playlists.get_ItemByName (StaticPlaylistName)) as IITUserPlaylist;
			
			if (pl != null)
				ITunez.CrashSafe (() => pl.Delete ());
		}

		void ShowCreateQueueMessage ()
		{
			string message = "Для того, чтобы скробблинг работал, создайте на своём "
				+ "iPod'е смарт-плейлист с названием \"" + DynamicPlaylistName + "\" "
				+ "и укажите следующие параметры: Количество исполнений > 0.";

			MessageBox.Show (message, "Необходимо создать плейлист", MessageBoxButtons.OK,
				MessageBoxIcon.Information);
		}

		public ReadOnlyCollection<IITFileOrCDTrack> GetTracksToScrobble ()
		{
			return trackList.GetSelectedTracks ();
		}

		public void Clear ()
		{
			Maek.Sure (!scanButton.IsBusy, "Идёт сканирование.");
			trackList.Clear ();
		}

		public void RemoveUnselectedRows ()
		{
			trackList.RemoveUncheckedItems ();
		}

		public void RemoveRow (IITFileOrCDTrack track)
		{
			trackList.RemoveItemByTrack (track);
		}

		public Button GetProposedAcceptButton ()
		{
			return scanButton.GetProposedAcceptButton ()
				?? deviceSelector.GetProposedAcceptButton ();
		}

		public Button GetProposedCancelButton ()
		{
			return scanButton.GetProposedCancelButton ()
				?? deviceSelector.GetProposedCancelButton ();
		}


		public bool RowsSelectable {
			set { trackList.ShowCheckboxes = value; }
		}

		public bool HasTracksToScrobble {
			get { return trackList.SelectedItemsCount > 0; }
		}

		public bool IsBusy {
			get { return scanButton.IsBusy; }
		}
	}
}
