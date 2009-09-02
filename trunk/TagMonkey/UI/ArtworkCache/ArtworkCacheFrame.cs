using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using TagMonkey.Local;

namespace TagMonkey.UI.ArtworkCacheViewer {
	public partial class ArtworkCacheFrame : UserControl {
		
		public event EventHandler ProposedButtonsChanged;

		private BackgroundWorker imageLoader;
		private Dictionary<string, ListViewItem> albumItems = new Dictionary<string, ListViewItem> ();

		public ArtworkCacheFrame ()
		{
			InitializeComponent ();
		}

		void ArtworkCacheFrame_Load (object sender, EventArgs e)
		{
			imageLoader = new BackgroundWorker ();
			imageLoader.DoWork += delegate {
				foreach (ArtworkCacheEntry entry in ArtworkCache.GetAllEntries ()) {
					Controlz.ThreadSafe (() => {
						AddEntryToList (entry);
					});
				}
			};
			imageLoader.RunWorkerCompleted += delegate {
				if (coverListView.Items.Count == 0)
					emptyCacheLabel.Visible = true;
			};
			imageLoader.RunWorkerAsync ();
			

			ArtworkCache.EntryAdded += (s, a) =>
				Controlz.ThreadSafe (() =>  AddEntryToList (a.AddedEntry));
			ArtworkCache.EntryDeleted += (s, a) =>
				RemoveEntryFromList (a.DeletedAlbumKey);
		}

		void removeArtworkMenuItem_Click (object sender, EventArgs e)
		{
			Maek.Sure (coverListView.SelectedItems.Count == 1, "SelectedCount должен быть 1.");
			ListViewItem selected = coverListView.SelectedItems [0];
			ArtworkCacheEntry entry = (ArtworkCacheEntry) selected.Tag;
			ArtworkCache.DeleteEntry (entry);
		}

		void clearCacheMenuItem_Click (object sender, EventArgs e)
		{
			if (ConfirmClear ()) {
				ClearControls ();
				albumItems.Clear ();
				ArtworkCache.Clear ();

				emptyCacheLabel.Visible = true;
			}
		}

		void itemMenu_Opening (object sender, System.ComponentModel.CancelEventArgs e)
		{
			bool isLoading = imageLoader.IsBusy;
			removeArtworkMenuItem.Enabled = !isLoading && (coverListView.SelectedIndices.Count > 0);
			clearCacheMenuItem.Enabled = !isLoading && (coverListView.Items.Count > 0);
		}


		void AddEntryToList (ArtworkCacheEntry entry)
		{
			Image artwork = new Bitmap (entry.ArtworkPath);

			string key = Albumz.GetUniqueKey (entry);
			coverImageList.Images.Add (key, artwork);

			ListViewItem item = new ListViewItem (
				string.Format ("{0} - {1}", entry.Artist, entry.Album));
			item.Tag = entry;
			item.ImageKey = key;

			coverListView.Items.Add (item);
			albumItems.Add (key, item);
			emptyCacheLabel.Visible = false;
		}

		void RemoveEntryFromList (string albumKey)
		{
			Image img = coverImageList.Images [albumKey];
			coverImageList.Images.RemoveByKey (albumKey);
			img.Dispose ();
			img = null;

			coverListView.Items.Remove (albumItems [albumKey]);
			albumItems.Remove (albumKey);

			emptyCacheLabel.Visible = (coverListView.Items.Count == 0);
		}

		bool ConfirmClear ()
		{
			return MessageBox.Show ("Точно очистить?", "Удалить скачанные обложки",
				MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)

				== DialogResult.Yes;
		}

		void ClearControls ()
		{
			coverListView.Items.Clear ();

			foreach (Image img in coverImageList.Images) {
				img.Dispose ();
			}

			coverImageList.Images.Clear ();

			GC.Collect ();
			emptyCacheLabel.Visible = true;
		}
	}
}
