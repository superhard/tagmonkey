using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Xml;
using TagMonkey.Properties;

namespace TagMonkey.Services.GetLyrics {
	class LyricMediaWikiService : IGetLyricsService {

		public string GetLyrics (string artist, string title)
		{
			try {
				XmlTextReader xml = new XmlTextReader (GetApiUrl (artist, title).ToString ());
				if (xml.ReadToFollowing ("url")) {
					string url = xml.ReadString ();
					if (!url.Contains ("action=edit")) // no such page
						return ParsePage (url);
				}

				return null;

			} catch (WebException wex) {
				if (wex.Status == WebExceptionStatus.ProtocolError && wex.Message.Contains ("404"))
					return null;

				throw new ServiceUnavailableException (wex);
			} catch (Exception ex) {
				throw new ServiceException ("Неизвестная ошибка.", ex);
			}
		}

		string ParsePage (string url)
		{
			using (WebClient wc = new WebClient ()) {
				string html = wc.DownloadString (url);
				if (string.IsNullOrEmpty (html))
					return null;

				Regex extractor = new Regex (Settings.Default.LyricWikiParserRegex);
				Match match = extractor.Match (html);
				if (match.Success) {
					string capturedLyrics = match.Groups ["LYRICS"].Value
						.Replace ("<br />", Environment.NewLine);
					if (!capturedLyrics.Contains (Settings.Default.MediaWikiInstrumentalCategory))
						return capturedLyrics;
				}

				return null;
			}
		}

		Uri GetApiUrl (string artist, string title)
		{
			return new Uri (
				new Uri (Settings.Default.MediaWikiApiBaseUrl), string.Format (
					"api.php?action=lyrics&artist={0}&song={1}&fmt=xml&func=getSong",
					artist, title));
		}
	}
}
