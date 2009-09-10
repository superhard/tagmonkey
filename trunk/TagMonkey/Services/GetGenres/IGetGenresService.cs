using System;
using System.Collections.Generic;

using TagMonkey.Services;

namespace TagMonkey.Services.GetGenres {
	interface IGetGenresService : IService {
		List<string> GetGenres (string artist, string album);
	}
}
