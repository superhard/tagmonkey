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
				return GetSongLyrics (artist, title);

			} catch (WebException wex) {
				if (wex.Status == WebExceptionStatus.ProtocolError && wex.Message.Contains ("404"))
					return null;

				throw new ServiceUnavailableException (wex);
			} catch (Exception ex) {
				throw new ServiceException ("Неизвестная ошибка: " + ex.Message, ex);
			}
		}

		string GetSongLyrics (string artist, string title)
		{
			string query = artist + " " + title;
			string pageName = null;
			using (XmlTextReader xml = new XmlTextReader (GetSearchUrl (artist + " " + title))) {
				do {
					pageName = null;
					if (!xml.ReadToFollowing ("p"))
						break;

					pageName = xml.GetAttribute ("title");
				} while (!pageName.Contains (":") || pageName.EndsWith (")"));
			}

			if (pageName == null || !EnsureCorrectPage (pageName, artist, title))
				return null;

			using (XmlTextReader xml = new XmlTextReader (GetContentUrl (pageName))) {
				if (xml.ReadToFollowing ("rev")) {
					string content = xml.ReadString ();
					int firstCloseBrace = content.IndexOf (">");
					int secondOpenBrace = content.IndexOf ("<", firstCloseBrace + 1);

					if (firstCloseBrace == -1 || secondOpenBrace == -1 || secondOpenBrace <= firstCloseBrace)
						return null;

					content = content.Substring (firstCloseBrace + 1, secondOpenBrace - firstCloseBrace - 1);

					if (content.Contains (Settings.Default.MediaWikiInstrumentalTemplate))
						return null;

					return content.Trim ();
				}
			}

			return null;
		}

		bool EnsureCorrectPage (string pageName, string artist, string title)
		{
			string [] arr = pageName.Split (':');
			if (arr.Length != 2)
				return false;

			string pageArtist = arr [0].ToLowerInvariant ();
			string pageTitle = arr [1].ToLowerInvariant ();

			artist = artist.Trim ().ToLowerInvariant ();
			if (artist.StartsWith ("the "))
				artist = artist.Substring (4);

			title = title.Trim ().ToLowerInvariant ();
			RemoveParens (ref title);

			return pageArtist.Contains (artist) && pageTitle.Contains (title); //TODO: enhance it
		}

		string GetSearchUrl (string query)
		{
			query = Uri.EscapeDataString (query);
			return string.Format (Settings.Default.MediaWikiApiSearchUrl, query);
		}

		string GetContentUrl (string title)
		{
			title = Uri.EscapeDataString (title);
			return string.Format (Settings.Default.MediaWikiApiGetLyricsUrl, title);
		}

		void RemoveParens (ref string s)
		{
			//TODO
		}
	}
}
