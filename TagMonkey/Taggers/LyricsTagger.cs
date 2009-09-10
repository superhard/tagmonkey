using System;
using System.Collections.Generic;
using System.Text;

using TagMonkey.Services;
using TagMonkey.Services.GetLyrics;
using TagMonkey.UI.CommonControls;

namespace TagMonkey.Taggers {
	class LyricsTagger : Tagger {
		private string downloadedLyrics = null;

		public LyricsTagger (ILogger logger)
			: base (logger) { }

		protected override bool GatherRequiredInfo ()
		{
			IGetLyricsService getLyrics = ServiceFactory.GetService<IGetLyricsService> ();
			downloadedLyrics = getLyrics.GetLyrics (Stringz.NotNull (CurrentTrack.Artist), Stringz.NotNull (CurrentTrack.Name));

			if (downloadedLyrics == null) {
				Log (LogEntryKind.Warning, "Текст песни отсутствует в базе данных");
				return false;
			}

			return true;
		}

		protected override void ClearInfo ()
		{
			downloadedLyrics = null;
		}

		protected override void WriteChangesToFile ()
		{
			CurrentTrack.Lyrics = downloadedLyrics;
			Log (LogEntryKind.Information, "Текст песни записан в файл");
		}

		public override bool RequiresWebConnection {
			get { return true; }
		}

		public override string FriendlyName {
			get { return "Поиск текстов песен в интернете"; }
		}
	}
}
