using System;
using System.Collections.Generic;
using System.Text;

using TagMonkey.Local;
using TagMonkey.UI.CommonControls;

namespace TagMonkey.Taggers {
	class ArtworkTagger : Tagger {

		private string artworkFile = null;
		private List<string> reportedMissingAlbums = new List<string> (); //TODO:write Set<T>

		public ArtworkTagger (ILogger logger)
			: base (logger) { }

		protected override bool GatherRequiredInfo ()
		{
			string artist = (CurrentTrack.Compilation) ? string.Empty : CurrentTrack.Artist;
			ArtworkCacheEntry? entry = ArtworkCache.FindEntry (artist, CurrentTrack.Album);
			if (!entry.HasValue) {
				string albumKey = Albumz.GetUniqueKey (CurrentTrack);
				if (reportedMissingAlbums.Contains (albumKey))
					return false;

				Log (string.Format ("{0} — {1} (альбом)", artist, CurrentTrack.Album), LogEntryKind.Warning,
					"Среди скачанных обложек не нашлось подходящей");

				reportedMissingAlbums.Add (albumKey);
				return false;
			}

			this.artworkFile = System.IO.Path.GetFullPath (entry.Value.ArtworkPath);
			return true;
		}

		protected override void ClearInfo ()
		{
			artworkFile = null;
		}

		protected override void WriteChangesToFile ()
		{
			if (CurrentTrack.Artwork.Count > 0)
				CurrentTrack.Artwork [1].SetArtworkFromFile (artworkFile);
			else
				CurrentTrack.AddArtworkFromFile (artworkFile);

			Log (LogEntryKind.Information, "Обложка записана в файл");
		}


		public override bool RequiresWebConnection {
			get { return false; }
		}

		public override string FriendlyName {
			get { return "Запись обложек в теги"; }
		}
	}
}
