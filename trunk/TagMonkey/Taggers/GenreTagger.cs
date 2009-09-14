using System;
using System.Collections.Generic;

using TagMonkey.Services;
using TagMonkey.Services.GetGenres;
using TagMonkey.UI.CommonControls;

namespace TagMonkey.Taggers {
	class GenreTagger : Tagger {
		private Dictionary<string, string> genreCache = new Dictionary<string, string> ();

		private const int ConcatGenresCount = 2;

		public GenreTagger (ILogger logger)
			: base (logger) { }

		protected override bool GatherRequiredInfo ()
		{
			string albumKey = Albumz.GetUniqueKey (CurrentTrack);
			if (genreCache.ContainsKey (albumKey))
				return genreCache [albumKey] != null;

			string artist = (CurrentTrack.Compilation) ? string.Empty : Stringz.NotNull (CurrentTrack.Artist);

			IGetGenresService getGenres = ServiceFactory.GetService<IGetGenresService> ();
			List<string> genres = getGenres.GetGenres (artist, CurrentTrack.Album);
			if (genres == null) {
				LogAlbum (LogEntryKind.Warning, "Не удалось найти жанр альбома");
				genreCache.Add (albumKey, null);
				return false;
			}

			string genre = genres [0];

			if (genres.Count > 1)
				for (int i = 1; i < Math.Min (ConcatGenresCount, genres.Count); i++)
					genre += ", " + genres [i];

			genreCache.Add (albumKey, genre);
			return true;
		}

		protected override void WriteChangesToFile ()
		{
			string genre = genreCache [Albumz.GetUniqueKey (CurrentTrack)];
			CurrentTrack.Genre = "";
			CurrentTrack.Genre = genre;
			Log (LogEntryKind.Information, string.Format ("Жанр \"{0}\" записан в теги файла", genre));
		}

		protected override void ClearInfo ()
		{
		}

		public override bool RequiresWebConnection {
			get { return true; }
		}

		public override string FriendlyName {
			get { return "Расстановка жанров"; }
		}
	}
}
