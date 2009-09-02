using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Xml;

namespace TagMonkey.Local {
	static class ArtworkCache {
		private const string CacheDir = "Artwork Cache";
		private const string CacheFile = CacheDir + "\\ArtworkCache.xml";
		private const string EmptyXml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><artwork-cache></artwork-cache>";

		private static XmlDocument cache = null;

		public static event EventHandler CachedCleared;
		public static event EventHandler<EntryAddedEventArgs> EntryAdded;
		public static event EventHandler<EntryDeletedEventArgs> EntryDeleted;

		public static IEnumerable<ArtworkCacheEntry> GetAllEntries ()
		{
			if (cache == null)
				LoadCache ();

			foreach (XmlNode xmlNode in cache.SelectNodes ("/artwork-cache/artist/entry")) {
				XmlElement xmlEntry = (XmlElement) xmlNode;
				KillIfOrphan (ref xmlEntry); // kinda cruel

				if (xmlEntry != null)
					yield return ReadIntoCacheEntry (xmlEntry);
			}
		}

		public static ArtworkCacheEntry? FindEntry (string artist, string album)
		{
			if (cache == null)
				LoadCache ();

			XmlElement xmlEntry = FindXmlEntry (artist, album);
			if (xmlEntry != null)
				KillIfOrphan (ref xmlEntry);
	
			if (xmlEntry == null)
				return null;

			return ReadIntoCacheEntry (xmlEntry);
		}

		public static void Store (string artist, string album, Image artwork)
		{
			artist = FormatStringForCache (artist);
			album = FormatStringForCache (album);

			if (cache == null)
				LoadCache ();
			
			XmlElement xmlEntry = FindXmlEntry (artist, album);
			if (xmlEntry != null)
				KillEntry (xmlEntry, true);

			string newPath = SaveImage (artist, album, artwork);
			xmlEntry = CreateXmlEntry (artist, album, Path.GetFileName (newPath));
			
			Flush ();

			EntryAddedEventArgs args = new EntryAddedEventArgs (ReadIntoCacheEntry (xmlEntry));
			if (EntryAdded != null)
				EntryAdded (null, args);
		}

		public static void Clear ()
		{
			cache = null;
			File.Delete (CacheFile);
			foreach (string file in Directory.GetFiles (CacheDir)) {
				try {
					File.Delete (file);
				} catch (IOException) {
					// file busy, leave it
				}
			}

			if (CachedCleared != null)
				CachedCleared (null, EventArgs.Empty);
		}

		public static void DeleteEntry (ArtworkCacheEntry entry)
		{
			XmlElement xmlEntry = FindXmlEntry (entry.Artist, entry.Album);
			if (xmlEntry != null)
				KillEntry (xmlEntry, true);
		}


		static string SaveImage (string artist, string album, Image artwork)
		{
			string artworkFile = (artist + " - " + album);
			RemoveInvalidChars (ref artworkFile);

			string defaultPath = Path.Combine (CacheDir, artworkFile);
			string path = defaultPath;
			string extension = (string) artwork.Tag;

			int i = 2;
			while (File.Exists (path + extension))
				path = defaultPath + " " + (i++).ToString ();

			path += extension;
			artwork.Save (path);

			return path;
		}

		static void RemoveInvalidChars (ref string filename)
		{
			char [] chars = Path.GetInvalidFileNameChars ();
			for (int i = 0; i < chars.Length; i++)
				filename = filename.Replace (chars [i].ToString (), string.Empty);
		}

		static void Flush ()
		{
			if (cache == null)
				return;

			cache.Save (CacheFile);
		}

		static XmlElement FindXmlArtist (string artist)
		{
			Maek.Sure (cache != null, "Кэш не создан!");

			string qArtist = WrapAndEscapeXPathString (FormatStringForCache (artist));
			return (XmlElement) cache.SelectSingleNode (string.Format ("//artist[@name={0}]",
				qArtist));
		}

		static XmlElement FindXmlEntry (string artist, string album)
		{
			Maek.Sure (cache != null, "Кэш не создан!");

			string qArtist = WrapAndEscapeXPathString (FormatStringForCache (artist));
			string qAlbum = WrapAndEscapeXPathString (FormatStringForCache (album));

			return (XmlElement) cache.SelectSingleNode (string.Format ("//entry[@album={0} and ./../@name={1}]",
				qAlbum, qArtist));
		}

		static ArtworkCacheEntry ReadIntoCacheEntry (XmlNode xmlEntry)
		{
			return new ArtworkCacheEntry (
				xmlEntry.ParentNode.Attributes ["name"].Value,
				xmlEntry.Attributes ["album"].Value,
				GetArtworkPath (xmlEntry));
		}

		static string ReadArtworkFileInfo (XmlNode xmlEntry)
		{
			return xmlEntry.Attributes ["artwork"].Value;
		}

		static string GetArtworkPath (XmlNode xmlEntry)
		{
			return Path.Combine (CacheDir, ReadArtworkFileInfo (xmlEntry));
		}

		static XmlElement CreateXmlEntry (string artist, string album, string artworkFile)
		{
			// create entry
			XmlElement xmlArtist = FindXmlArtist (artist);

			if (xmlArtist == null) {
				xmlArtist = cache.CreateElement ("artist");
				xmlArtist.Attributes.Append (cache.CreateAttribute ("name"));
				xmlArtist.Attributes [0].Value = artist;

				GetRoot ().AppendChild (xmlArtist);
			}

			XmlElement xmlEntry = cache.CreateElement ("entry");
			xmlArtist.AppendChild (xmlEntry);

			xmlEntry.Attributes.Append (cache.CreateAttribute ("album"));
			xmlEntry.Attributes.Append (cache.CreateAttribute ("artwork"));

			xmlEntry.Attributes ["album"].Value = album;
			xmlEntry.Attributes ["artwork"].Value = artworkFile;

			return xmlEntry;
		}

		static void WriteArtworkFileInfo (XmlNode xmlEntry, string artworkFile)
		{
			xmlEntry.Attributes ["artwork"].Value = artworkFile;
		}

		static void KillIfOrphan (ref XmlElement xmlEntry)
		{
			string artworkPath = GetArtworkPath (xmlEntry);
			if (File.Exists (artworkPath))
				return;

			KillEntry (xmlEntry, false);
			xmlEntry = null;
		}

		static void KillEntry (XmlElement xmlEntry, bool raiseEvent)
		{
			string albumKey = null;
			if (raiseEvent) {
				ArtworkCacheEntry entry = ReadIntoCacheEntry (xmlEntry);
				albumKey = Albumz.GetUniqueKey (entry);
			}

			string artworkFile = GetArtworkPath (xmlEntry);
			if (File.Exists (artworkFile)) {
				try {
					File.Delete (artworkFile);
				} catch (IOException) {
					//FIXME: sometimes file is being used by process, what's keeping it?
				}
			}

			xmlEntry.ParentNode.RemoveChild (xmlEntry);
			Flush ();

			if (raiseEvent && EntryDeleted != null)
				EntryDeleted (null, new EntryDeletedEventArgs (albumKey));
		}
	
	
		static XmlElement GetRoot ()
		{
			Maek.Sure (cache != null, "Кэш не создан!");

			return (XmlElement) cache.SelectSingleNode ("/artwork-cache");
		}


		static void LoadCache ()
		{
			if (!File.Exists (CacheFile)) {
				if (!Directory.Exists (CacheDir))
					Directory.CreateDirectory (CacheDir);

				using (StreamWriter sr = File.CreateText (CacheFile)) {
					sr.WriteLine (EmptyXml);
					sr.Close ();
				}
			}

			cache = new XmlDocument ();
			cache.Load (CacheFile);
		}

		static string FormatStringForCache (string unformatted)
		{
			if (unformatted == null)
				return string.Empty;

			return unformatted.Trim ().ToLowerInvariant ();
		}

		static string WrapAndEscapeXPathString (string unesc)
		{
			unesc = unesc.Replace ("\"", string.Empty);

			if (!unesc.Contains ("'"))
				return "'" + unesc + "'";

			string esc = string.Empty;
			string [] parts = unesc.Split ('\'');
			foreach (string part in parts) {
				if (esc != string.Empty)
					esc += ",\"'\",";

				esc += "\"" + part + "\"";
			}
			esc = "concat(" + esc + ")";
			return esc;
		}

	}
}
