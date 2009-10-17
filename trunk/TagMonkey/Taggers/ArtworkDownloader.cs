using System;
using System.Collections.Generic;
using System.Drawing;

using iTunesLib;
using TagMonkey.Local;
using TagMonkey.Services;
using TagMonkey.Services.GetArtwork;
using TagMonkey.UI.Common;

namespace TagMonkey.Taggers {
	class ArtworkDownloader : Tagger {

		private Dictionary<string, bool> requestCache = new Dictionary<string, bool> ();

		public ArtworkDownloader (ILogger logger)
			: base (logger) { }

		protected override bool GatherRequiredInfo ()
		{
			string album = Stringz.NotNull (CurrentTrack.Album);
			string artist = (CurrentTrack.Compilation) ? string.Empty : Stringz.NotNull (CurrentTrack.Artist);
			string albumKey = Albumz.GetUniqueKey (CurrentTrack);

			// check cache
			if (IsServiceResponseCached (albumKey) || ArtworkCache.FindEntry (artist, album).HasValue)
				return false;

			// download artwork
			IGetArtworkService getArtwork = ServiceFactory.GetService<IGetArtworkService> ();
			Image img = getArtwork.GetArtwork (artist, album, CurrentTrack.Year);
			if (img == null) {
				LogAlbum (LogEntryKind.Warning, "Не удалось найти обложку");
			} else {
				using (img) ArtworkCache.Store (artist, album, img);
				LogAlbum (LogEntryKind.Information, "Обложка загружена из интернета");
			}

			CacheServiceResponse (albumKey, img != null);

			return false;
		}

		protected override void ClearInfo ()
		{
		}

		protected override void WriteChangesToFile ()
		{
			throw new NotImplementedException ();
		}

		public override bool RequiresWebConnection
		{
			get { return true; }
		}

		public override string FriendlyName {
			get { return "Поиск обложек в интернете"; }
		}


		bool IsServiceResponseCached (string albumKey)
		{
			return requestCache.ContainsKey (albumKey);
		}

		void CacheServiceResponse (string albumKey, bool success)
		{
			if (requestCache.ContainsKey (albumKey))
				requestCache [albumKey] = success;
			else
				requestCache.Add (albumKey, success);
		}
	}
}
