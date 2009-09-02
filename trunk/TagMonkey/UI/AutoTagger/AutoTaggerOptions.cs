using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using TagMonkey.Taggers;

namespace TagMonkey.UI.AutoTagger {
	struct AutoTaggerOptions {
		
		public readonly ReadOnlyCollection<TaggerKind> SelectedTaggers; //TODO: write Set<T>
		public readonly bool OnlyMissingLyrics, OnlyMissingArtwork;

		public AutoTaggerOptions (ReadOnlyCollection<TaggerKind> taggers, bool onlyMissingLyrics, bool onlyMissingArtwork)
		{
			SelectedTaggers = taggers;
			OnlyMissingLyrics = onlyMissingLyrics;
			OnlyMissingArtwork = onlyMissingArtwork;
		}

		public bool AnyChangedRequested {
			get { return SelectedTaggers.Count > 0; }
		}
	}
}