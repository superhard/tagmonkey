using System;
using System.Collections.Generic;
using System.Text;

namespace TagMonkey.Services.GetLyrics {
	interface IGetLyricsService : IService {
		string GetLyrics (string artist, string title);
	}
}
