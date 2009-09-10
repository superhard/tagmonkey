using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;
using System.Xml;

namespace TagMonkey.Services.GetGenres {
	class DiscogsGetGenresService : IGetGenresService {
		private const string ApiKey = "8a8469ed72";

		public List<string> GetGenres (string artist, string album)
		{
			string url = string.Format ("http://www.discogs.com/search?type=all&q={0}+{1}&f=xml&api_key={2}",
				Uri.EscapeDataString (artist), Uri.EscapeDataString (album), ApiKey);

			WebClient wc = new WebClient ();
			wc.Headers.Add (HttpRequestHeader.AcceptEncoding, "gzip");
			wc.Proxy = null;

			string releaseUrl = null;
			try {
				using (GZipStream stream = new GZipStream (
					wc.OpenRead (url), CompressionMode.Decompress, false)) {
					using (XmlTextReader reader = new XmlTextReader (stream)) {
						try {
							do {
								reader.ReadToFollowing ("result");
							} while (reader.GetAttribute ("type") != "release");

							reader.ReadToFollowing ("uri");
							reader.Read ();
							releaseUrl = reader.Value;
						} catch (XmlException) {
							return null;
						}

					}
				}
			} catch (XmlException) {
				return null;
			} catch (WebException) {
				throw new ServiceUnavailableException ();
			} catch (InvalidDataException) {
				return null;
			}

			if (releaseUrl == null)
				return null;

			releaseUrl = releaseUrl.Substring (releaseUrl.IndexOf ("/release"));
			releaseUrl = string.Format ("http://www.discogs.com{0}?f=xml&api_key={1}", releaseUrl, ApiKey);

			List<string> styles = new List<string> ();
			using (GZipStream stream = new GZipStream (
			   wc.OpenRead (releaseUrl), CompressionMode.Decompress, false)) {
				using (XmlTextReader reader = new XmlTextReader (stream)) {
					try {
						reader.ReadToFollowing ("styles");
						reader.Read ();
						while (reader.Name == "style") {
							reader.Read ();
							styles.Add (reader.Value);
							reader.Read (); // to </style>
							reader.Read (); // to next <style>
						}
					} catch (XmlException) {
						return null;
					}
				}
			}

			if (styles.Count == 0)
				return null;

			return styles;
		}
	}
}
