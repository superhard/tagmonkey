using System;

using TagMonkey.UI.CommonControls;

namespace TagMonkey.Taggers {
	class AlbumSorter : Tagger {

		private string newSortAlbum = null;

		public AlbumSorter (ILogger logger)
			: base (logger) { }

		protected override bool GatherRequiredInfo ()
		{
			if (string.IsNullOrEmpty (CurrentTrack.SortAlbum))
				CurrentTrack.UpdateInfoFromFile (); //FIXME:slow but helps to fix some mistakes

			int year = CurrentTrack.Year;
			string album = Stringz.NotNull (CurrentTrack.Album);
			string sortAlbum = Stringz.NotNull (CurrentTrack.SortAlbum);

			if (string.IsNullOrEmpty (sortAlbum)) {
				if (year == 0) {
					Log (LogEntryKind.Warning, "Пропущен: не указан год для сортировки");
					return false;
				}

				newSortAlbum = string.Format ("{0} {1}", year, album);	
			} else { // sortAlbum != null
				if (year != 0) {
					// yr = 2003, sortalbum = "2003 Give Up"
					if (sortAlbum.StartsWith (year.ToString ()))
						return false;

					newSortAlbum = string.Format ("{0} {1}", year, sortAlbum);
				} else if (!StartsWithAYear (CurrentTrack.SortAlbum)) { // yr = 0, sortalbum = "Eraser"
					Log (LogEntryKind.Warning, "Пропущен: не указан год для сортировки");
					return false;
				}
			}

			return (newSortAlbum != null);
		}

		protected override void ClearInfo ()
		{
			newSortAlbum = null;
		}

		public override bool RequiresWebConnection {
			get { return false; }
		}

		public override string FriendlyName {
			get { return "Сортировщик альбомов"; }
		}


		bool StartsWithAYear (string s)
		{
			return s.StartsWith ("19") || s.StartsWith ("20");
		}

		protected override void WriteChangesToFile ()
		{
			CurrentTrack.SortAlbum = newSortAlbum;
			if (string.IsNullOrEmpty (CurrentTrack.SortAlbum))
				CurrentTrack.UpdateInfoFromFile ();

			Log (LogEntryKind.Information, "Теперь сортируется по " + newSortAlbum.Substring (0, 4) + " году");
		}
	}
}
