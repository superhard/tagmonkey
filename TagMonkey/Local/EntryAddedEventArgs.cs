using System;

namespace TagMonkey.Local {
	class EntryAddedEventArgs : EventArgs {
		private ArtworkCacheEntry entry;

		public EntryAddedEventArgs (ArtworkCacheEntry entry)
		{
			this.entry = entry;
		}

		public ArtworkCacheEntry AddedEntry {
			get { return entry; }
		}
	}
}
