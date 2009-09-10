using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using TagMonkey.Taggers;

namespace TagMonkey.UI.AutoTagger {
	struct AutoTaggerOptions {
		
		public readonly ReadOnlyCollection<TaggerKind> SelectedTaggers; //TODO: write Set<T>
		public readonly bool OnlyMissingLyrics, OnlyMissingArtwork, OnlyMissingGenre;

		public AutoTaggerOptions (ReadOnlyCollection<TaggerKind> taggers, bool onlyMissingLyrics, bool onlyMissingArtwork,
			bool onlyMissingGenre)
		{
			SelectedTaggers = taggers;
			OnlyMissingLyrics = onlyMissingLyrics;
			OnlyMissingArtwork = onlyMissingArtwork;
			OnlyMissingGenre = onlyMissingGenre;
		}

		public bool AnyChangedRequested {
			get { return SelectedTaggers.Count > 0; }
		}
	}
}