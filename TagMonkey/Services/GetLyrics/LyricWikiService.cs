using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;

using TagMonkey.Services.GetLyrics;
using TagMonkey.Properties;

namespace TagMonkey.Services.GetLyrics {

	class LyricWikiService : IGetLyricsService {

		private static Dictionary<string, bool> artistExistsCache = new Dictionary<string, bool> ();
		private static LyricWikiSOAP.LyricWiki wikiService = new LyricWikiSOAP.LyricWiki ();

		private const string InstrumentalCategory = "Category:Instrumental";

		public string GetLyrics (string artist, string title)
		{
			try {
				if (!SongExists (artist, title))
					return null;

				LyricWikiSOAP.LyricsResult result = wikiService.getSong (artist, title);

				using (WebClient wc = new WebClient ()) {
					string url = result.url; // .Replace ("lyricwiki.org", "lyrics.wikia.com")
					string html = wc.DownloadString (url);
					if (string.IsNullOrEmpty (html))
						return null;

					Regex extractor = new Regex (Settings.Default.LyricWikiParserRegex);
					Match match = extractor.Match (html);
					if (match.Success) {
						string capturedLyrics = match.Groups ["LYRICS"].Value
							.Replace ("<br />", Environment.NewLine);
						if (!capturedLyrics.Contains (InstrumentalCategory))
							return capturedLyrics;
					}

					return null;
				}
			} catch (WebException wex) {
				if (wex.Status == WebExceptionStatus.ProtocolError && wex.Message.Contains ("404"))
					return null;

				throw new ServiceUnavailableException (wex);
			}
		}

		bool SongExists (string artist, string title)
		{
			if (artistExistsCache.ContainsKey (artist)) {
				if (!artistExistsCache [artist])
					//  artist not present in LyricsWiki
					return false;
			} else {
				string [] matches;
				matches = wikiService.searchArtists (artist);
				bool existsInWiki = (matches.Length > 0)
					&& (matches [0].Replace ('_', ' ').ToLowerInvariant ()
						== artist.ToLowerInvariant ());

				artistExistsCache.Add (artist, existsInWiki);

				if (!existsInWiki)
					return false;
			}

			return wikiService.checkSongExists (artist, title);
		}
	}
}
