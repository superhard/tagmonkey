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
			string artist = (track.Compilation) ? string.Empty : track.Artist;
			if (artist == null)
				artist = string.Empty;
			string album = (track.Album == null) ? string.Empty : track.Album; //FIXME: extract denullify
			return ITunez.CrashSafe (() => GetUniqueKey (artist, album));
		}
	}

}
