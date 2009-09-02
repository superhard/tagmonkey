using System;

namespace TagMonkey.Local {
	class EntryDeletedEventArgs : EventArgs {
		private string key;

		public EntryDeletedEventArgs (string albumKey)
		{
			key = albumKey;
		}

		public string DeletedAlbumKey
		{
			get { return key; }
		}
	}
}
