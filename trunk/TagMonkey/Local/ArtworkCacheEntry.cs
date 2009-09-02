using System;
using System.Collections.Generic;
using System.Text;

namespace TagMonkey.Local {
	struct ArtworkCacheEntry {
		public string Artist;
		public string Album;
		public string ArtworkPath;

		public ArtworkCacheEntry (string artist, string album, string artworkPath)
		{
			Artist = artist;
			Album = album;
			ArtworkPath = artworkPath;
		}
	}
}
