using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Sockets;

using TagMonkey.Net;

using Gapi.Search;

namespace TagMonkey.Services.GetArtwork {
	class GoogleImagesGetArtworkService : IGetArtworkService {

		private const double MinRatio = 0.99;
		private const double MaxRatio = 1.05;
		
		private const int MinSize = 150;
		private const int NiceSize = 500;
		private const int SizeDelta = 50;

		private const int BestResults = 6;
		private const int DownloadImageTimeout = 10000;

		public Image GetArtwork (string artist, string album, int year)
		{
			IEnumerable<ImageSearchResult> matches = GetMatches (artist, album, year);

			Image img = null;
			int size = NiceSize + SizeDelta;

			while (img == null && size > MinSize) {
				size -= SizeDelta;
				img = TrySelectImage (matches, size);
			}
			
			return img; // null if none is found
		}

		public IEnumerable<Uri> GetAllMatches (string artist, string album, int year)
		{
			foreach (ImageSearchResult img in GetMatches (artist, album, year))
				yield return new Uri (img.Url);
		}


		IEnumerable<ImageSearchResult> GetMatches (string artist, string album, int year)
		{
			string q = string.Format ("\"{0} - {1}\"", artist, album);
			if (artist == album && year != 0) // e.g. "The Beatles - The Beatles" needs year as a context
				q += " " + year.ToString ();

			SearchResults found;
			try {
				found = Searcher.Search (new ImageSearchOptions (), q);
			} catch (WebException wex) {
				throw new ServiceUnavailableException (wex);
			}

			List<ImageSearchResult> matches = new List<ImageSearchResult> ();
			for (int i = 0; i < Math.Min (BestResults, found.Items.Length); i++) {
				ImageSearchResult result = (ImageSearchResult) found.Items [i];

				if (result.Width < MinSize || result.Height < MinSize)
					continue;

				if (IsBannedSource (result.Url))
					continue;

				double ratio = (double) result.Width / (double) result.Height;
				if (ratio < MinRatio || ratio > MaxRatio)
					continue;

				if (result.Content.Contains ("<b>"))
					matches.Add (result);
			}

			return matches;
		}

		Image TrySelectImage (IEnumerable<ImageSearchResult> matches, int requiredSize)
		{
			foreach (ImageSearchResult match in matches) {
				if (match.Width < requiredSize)
					continue;

				Bitmap img = TryGetImage (match.Url);
				if (img != null) {
					string extension = TryGetSupportedExtension (img.RawFormat);
					if (extension == null) {
						img.Dispose ();
						continue;
					}

					img.Tag = extension;
					return img;
				}
			}

			return null;
		}

		string TryGetSupportedExtension (ImageFormat format)
		{
			Guid f = format.Guid;
			if (f == ImageFormat.Jpeg.Guid)
				return ".jpg";
			else if (f == ImageFormat.Png.Guid)
				return ".png";
			else if (f == ImageFormat.Bmp.Guid)
				return ".bmp";
			else
				return null;
		}

		bool IsBannedSource (string url)
		{
			if (url.Contains ("crocmusic.com")) // large images of low quality
				return true;

			return false;
		}

		Bitmap TryGetImage (string url)
		{
			// http://stackoverflow.com/questions/104797/wcf-service-for-receiving-image
			try {
				using (WebClientEx wc = new WebClientEx (DownloadImageTimeout)) {
					return new Bitmap (wc.OpenRead (url));
				}
			} catch (ArgumentException) {
				return null;
			} catch (WebException) {
				return null;
			} catch (IOException) {
				return null;
			} catch (SocketException) {
				return null;
			}
		}
	}
}
