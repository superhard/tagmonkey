using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TagMonkey.Services.GetArtwork {
	interface IGetArtworkService : IService {
		Image GetArtwork (string artist, string album, int year);
		IEnumerable<Uri> GetAllMatches (string artist, string album, int year);
	}
}
