using System;
using System.Collections.Generic;
using System.Text;

namespace TagMonkey.Services.Authentication {
	class AuthFailedException : Exception {
		public AuthFailedException (string message)
			: base (message) { }

		public AuthFailedException (string message, Exception inner)
			: base (message, inner) { }
	}
}
