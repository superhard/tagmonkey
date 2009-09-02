using System;
using System.Collections.Generic;
using System.Text;

namespace TagMonkey.Services.Authentication {
	class AuthFailedEventArgs : EventArgs {
		public readonly string Reason;

		public AuthFailedEventArgs (string reason)
		{
			Reason = reason;
		}

		public AuthFailedEventArgs (AuthFailedException aex)
		{
			Reason = aex.Message;
		}
	}
}
