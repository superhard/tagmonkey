using System;
using System.Collections.Generic;
using System.Text;

using iTunesLib;

namespace TagMonkey {
	static class Albumz {

		public static string GetUniqueKey (string artist, string album)
		{
			return artist + "$" + album;
		}

		public static string GetUniqueKey (TagMonkey.Local.ArtworkCacheEntry entry)
		{
			return GetUniqueKey (entry.Artist, entry.Album);
		}

		public static string GetUniqueKey (IITFileOrCDTrack track)
		{
			string key = null;
			ITunez.CrashSafe (() => key = GetUniqueKey (track.Artist, track.Album)); //TODO: use generics
			return key;
		}
	}

}
