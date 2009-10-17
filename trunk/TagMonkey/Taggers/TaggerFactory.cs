using System;
using System.Collections.Generic;
using System.Text;

using TagMonkey.UI.Common;

namespace TagMonkey.Taggers {
	static class TaggerFactory {
		private static Dictionary<TaggerKind, Tagger> instances = new Dictionary<TaggerKind, Tagger> ();
		private static ILogger logger = null;

		public static Tagger GetTagger (TaggerKind kind)
		{
			Maek.Sure (logger != null, "logger не должен быть null.");

			if (instances.ContainsKey (kind))
				return instances [kind];

			Tagger instance;
			switch (kind) {
			case TaggerKind.AlbumsSorter:
				instance = new AlbumSorter (logger);
				break;
			case TaggerKind.ArtworkDownloader:
				instance = new ArtworkDownloader (logger);
				break;
			case TaggerKind.ArtworkTagger:
				instance = new ArtworkTagger (logger);
				break;
			case TaggerKind.LyricsTagger:
				instance = new LyricsTagger (logger);
				break;
			case TaggerKind.NamesFormatter:
				instance = new NamesFormatter (logger);
				break;
			case TaggerKind.GenreTagger:
				instance = new GenreTagger (logger);
				break;
			default:
				throw new NotImplementedException ();
			}

			instances.Add (kind, instance);
			return instance;
		}

		public static ILogger CurrentLogger {
			get { return logger; }
			set { logger = value; }
		}

	}
}