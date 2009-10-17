using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Lastfm.Services;
using TagMonkey.UI.Common;
using TagMonkey.Properties;
using TagMonkey.Services.Authentication;
using TagMonkey.Services.Lastfm;

namespace TagMonkey.UI.Lastfm {
	partial class LastfmLoginControl : UserControl, IUserDetailsProvider, ICanProposeButtons {
		enum StatusMessageColor {
			Grey,
			Red,
			Green
		}

		public event EventHandler ProposedButtonsChanged;

		public LastfmLoginControl ()
		{
			InitializeComponent ();
			loginButton.UserDetailsProvider = this;
		}

		void LastfmLoginControl_Load (object sender, EventArgs e)
		{
			Controlz.Enable (loginTextBox, passwordTextBox);
			SetStatusMessage ("Введите свои логин и пароль для доступа к профилю:", StatusMessageColor.Grey);
		}

		void SetServiceHooks ()
		{
			Maek.Sure (loginButton.Service != null, "Сервис должен быть не null.");
			LastfmService service = (LastfmService) loginButton.Service;

			service.ConnectionStarted += delegate {
				Controlz.Disable (loginTextBox, passwordTextBox);
				SetStatusMessage ("Выполняется аутентификация...", StatusMessageColor.Grey);
			};
			service.LoginSuccessful += delegate {
				SetStatusMessage (string.Format ("Вы вошли как {0}.",
					loginButton.Service.CurrentUsername), StatusMessageColor.Green);
			};
			service.LoginFailed += delegate (object sender, AuthFailedEventArgs e) {
				Controlz.Enable (loginTextBox, passwordTextBox);
				SetStatusMessage (e.Reason, StatusMessageColor.Red);
			};
			service.LoggedOut += delegate {
				Controlz.Enable (loginTextBox, passwordTextBox);
				SetStatusMessage ("Введите свои логин и пароль для доступа к профилю:", StatusMessageColor.Grey);
			};
		}

		bool AreTextBoxesFilled ()
		{
			return !string.IsNullOrEmpty (loginTextBox.Text.Trim ())
			    && !string.IsNullOrEmpty (passwordTextBox.Text.Trim ());
		}

		Color GetStatusMessageColor (StatusMessageColor kind)
		{
			switch (kind) {
			case StatusMessageColor.Red:
				return Color.Red;
			case StatusMessageColor.Grey:
				return Color.DimGray;
			case StatusMessageColor.Green:
				return Color.ForestGreen;
			default:
				throw new NotImplementedException ("Нет такого цвета, йо.");
			}
		}

		void SetStatusMessage (string message, StatusMessageColor messageKind)
		{
			statusLabel.Text = message;
			statusLabel.ForeColor = GetStatusMessageColor (messageKind);

			if (messageKind == StatusMessageColor.Green)
				statusLabel.Font = new Font (statusLabel.Font, FontStyle.Bold);
			else
				statusLabel.Font = new Font (statusLabel.Font, FontStyle.Regular);
		}

		public void SetLastfmService (ILastfmService service)
		{
			Maek.Sure (loginButton.Service == null, "Нельзя установить сервис дважды!");
			loginButton.SetService (service);
			SetServiceHooks ();
		}

		public Button GetProposedAcceptButton ()
		{
			return loginButton.GetProposedAcceptButton ();
		}

		public Button GetProposedCancelButton ()
		{
			return loginButton.GetProposedCancelButton ();
		}


		public string UserLogin {
			get { return loginTextBox.Text; }
		}

		public string UserPassword {
			get { return passwordTextBox.Text; }
		}
	}
}
