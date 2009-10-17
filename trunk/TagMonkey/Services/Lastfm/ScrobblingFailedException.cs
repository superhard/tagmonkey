using System;
using System.Collections.Generic;
using System.Text;

namespace TagMonkey.Services.Lastfm {
	class ScrobblingFailedException : ServiceException {
		public ScrobblingFailedException (string message)
			: base (message) { }

		public ScrobblingFailedException (string message, Exception inner)
			: base (message, inner) { }
	}
}
