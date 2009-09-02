using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;

using iTunesLib;

namespace TagMonkey.UI.Lastfm {
	partial class TrackQueueControl : UserControl {
		class TrackListViewItemSorter : IComparer {
			public int Compare (object x, object y)
			{
				ListViewItem a = (ListViewItem) x;
				ListViewItem b = (ListViewItem) y;
				return ((DateTime) a.SubItems [3].Tag).CompareTo (b.SubItems [3].Tag);
			}
		}

		public event EventHandler SelectedTracksChanged;

		public TrackQueueControl ()
		{
			InitializeComponent ();
			tracksListView.ListViewItemSorter = new TrackListViewItemSorter ();
			tracksListView.ItemChecked += delegate {
				if (SelectedTracksChanged != null)
					SelectedTracksChanged (this, EventArgs.Empty);
			};
		}

		void tracksListView_KeyDown (object sender, KeyEventArgs e)
		{
			// select-all
			if (e.Control && e.KeyCode == Keys.A && tracksListView.Items.Count > 0) {
				tracksListView.Focus ();
				SendKeys.Send ("{HOME}");
				SendKeys.Send ("+{END}");
			}
		}

		public void AddTrack (IITFileOrCDTrack track)
		{
			DateTime playedDate = DateTime.MinValue;
			string [] cells = null;
			ITunez.CrashSafe (() => {
				playedDate = track.PlayedDate;
				cells =  new string [] { track.Artist,
							  track.Name,
							  track.PlayedCount.ToString (),
							  playedDate.ToShortDateString () };

			});
	
			ListViewItem item = new ListViewItem (cells);
			item.SubItems [3].Tag = playedDate;
			item.Tag = track;
			item.Checked = true;

			tracksListView.Items.Add (item);
			tracksListView.Update ();
		}

		public void Clear ()
		{
			tracksListView.Items.Clear ();
		}

		public int SelectedItemsCount {
			get { return tracksListView.CheckedItems.Count; }
		}

		public ReadOnlyCollection<IITFileOrCDTrack> GetSelectedTracks ()
		{
			List<IITFileOrCDTrack> tx = new List<IITFileOrCDTrack> (tracksListView.CheckedItems.Count);

			foreach (ListViewItem li in tracksListView.CheckedItems)
				tx.Add ((IITFileOrCDTrack) li.Tag);

			return tx.AsReadOnly ();
		}

		public void RemoveUncheckedItems ()
		{
			foreach (ListViewItem li in tracksListView.Items)
				if (!li.Checked)
					tracksListView.Items.Remove (li);
		}

		public void RemoveItemByTrack (IITFileOrCDTrack track)
		{
			for (int i = 0; i < tracksListView.Items.Count; i++)
				if (tracksListView.Items [i].Tag == track)
					tracksListView.Items.RemoveAt (i);
		}

		public bool ShowCheckboxes {
			set { tracksListView.CheckBoxes = value; }
		}
	}
}
