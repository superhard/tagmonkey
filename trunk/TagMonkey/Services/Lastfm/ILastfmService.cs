using System;

using iTunesLib;
using TagMonkey.Services.Authentication;

namespace TagMonkey.Services.Lastfm {
	interface ILastfmService : IAuthService {
		void Scrobble (IITFileOrCDTrack track, int addSeconds);
	}
}
