using System;
using System.Collections.Generic;
using System.Text;

namespace TagMonkey.Services.Authentication {
	interface IAuthService : IService {
		event EventHandler LoginSuccessful;
		event EventHandler<AuthFailedEventArgs> LoginFailed;
		event EventHandler LoggedOut;
		event EventHandler ConnectionStarted;
		event EventHandler Disconnected;

		void BeginLogin (string login, string password);
		void Logout ();

		bool IsAuthenticated { get; }
		bool IsConnecting { get; }
		string CurrentUsername { get; }
	}
}
