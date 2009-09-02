using System;
using System.ComponentModel;
using System.Security.Authentication;

using TagMonkey;

namespace TagMonkey.Services.Authentication {
	abstract class AuthService : IAuthService {
		struct UserData {
			public string Login, Password;
		}

		public event EventHandler LoginSuccessful;
		public event EventHandler<AuthFailedEventArgs> LoginFailed;
		public event EventHandler LoggedOut;
		public event EventHandler ConnectionStarted;
		public event EventHandler Disconnected;

		
		protected abstract void DoLogin (string login, string password);
		protected abstract void DoLogout ();

		public abstract bool IsAuthenticated { get; }

		private string currentUsername = null;
		private BackgroundWorker loginWorker = new BackgroundWorker ();
		
		public AuthService ()
		{
			loginWorker.DoWork += delegate (object sender, DoWorkEventArgs e) {
				try {
					UserData user = (UserData) e.Argument;
					DoLogin (user.Login, user.Password);
				} catch (AuthFailedException aex) {
					e.Result = aex;
				} catch (Exception ex) {
					throw ex;
				}
			};

			loginWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler (worker_RunWorkerCompleted);
		}

		void worker_RunWorkerCompleted (object sender, RunWorkerCompletedEventArgs e)
		{
			if (Disconnected != null)
				Disconnected (this, EventArgs.Empty);

			AuthFailedException aex = e.Result as AuthFailedException;
			if (aex == null) {
				Maek.Sure (IsAuthenticated, "Ошибки не было, но и аутентификация не удалась.");
				if (LoginSuccessful != null)
					LoginSuccessful (this, EventArgs.Empty);

				return;
			}

			currentUsername = null;
			if (LoginFailed != null)
				LoginFailed (this, new AuthFailedEventArgs (aex));
		}

		public void BeginLogin (string login, string password)
		{
			Maek.Sure (!IsConnecting, "Уже идёт вход!");
			Maek.Sure (!IsAuthenticated, "Нельзя залогиниться дважды!");

			currentUsername = login;
			loginWorker.RunWorkerAsync (new UserData { Login = login, Password = password });

			if (ConnectionStarted != null)
				ConnectionStarted (this, EventArgs.Empty);
		}


		public void Logout ()
		{
			Maek.Sure (IsAuthenticated, "Вход не был произведён.");
			Maek.Sure (!IsConnecting, "Нельзя выйти во время операции входа.");

			DoLogout ();
			Maek.Sure (!IsAuthenticated, "Выход запрашивался, но не был произведён.");

			currentUsername = null;
			if (LoggedOut != null)
				LoggedOut (this, EventArgs.Empty);
		}

		public bool IsConnecting {
			get { return loginWorker.IsBusy; }
		}

		public string CurrentUsername {
			get { return currentUsername; }
		}
	}
}