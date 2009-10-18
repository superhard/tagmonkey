using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using TagMonkey.Properties;
using TagMonkey.Services.Authentication;

namespace TagMonkey.UI.Common {
	partial class LoginButton : UserControl, ICanProposeButtons {

		private IAuthService service = null;
		private IUserDetailsProvider userDetails = null;
		private bool ask_logout_confirmation = false;

		private const string LogoutText = "В&ыйти";
		private const string LoginText = "В&ойти";

		public event EventHandler ProposedButtonsChanged;

		public LoginButton ()
		{
			InitializeComponent ();
		}

		void LoginButton_Load (object sender, EventArgs e)
		{
			SetButtonFace (LoginText, Resources.loginIcon);
		}

		void button_Click (object sender, EventArgs e)
		{
			Maek.Sure (userDetails != null, "У кнопки не установлен UserDetailsProvider!");
			Maek.Sure (service != null, "Не установлен сервис!");

			if (!service.IsAuthenticated)
				service.BeginLogin (userDetails.UserLogin, userDetails.UserPassword);
			else if (!ask_logout_confirmation || ConfirmLogout ())
				service.Logout ();
		}

		void SetButtonFace (string text, Image img)
		{
			button.Text = text;
			button.Image = img;
		}

		bool ConfirmLogout ()
		{
			return MessageBox.Show ("Выйти из аккаунта?", "Выйти?", MessageBoxButtons.YesNo,
				MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes;
		}

		public void SetService (IAuthService value)
		{
			Maek.Sure (service == null, "У кнопки может быть только один сервис за всё время жизни!");
			Maek.Sure (value != null, "Нефиг ставить null'овый сервис!");

			service = value;
			service.LoginSuccessful += delegate {
				SetButtonFace (LogoutText, Resources.cancelIcon);
				ProposedButtonsChanged (this, EventArgs.Empty);
			};
			service.LoggedOut += delegate {
				SetButtonFace (LoginText, Resources.loginIcon);
				ProposedButtonsChanged (this, EventArgs.Empty);
			};
			service.ConnectionStarted += delegate {
				Controlz.Disable (button);
				ProposedButtonsChanged (this, EventArgs.Empty);
			};
			service.Disconnected += delegate {
				Controlz.Enable (button);
				ProposedButtonsChanged (this, EventArgs.Empty);
			};
		}

		public Button GetProposedAcceptButton ()
		{
			if (button.Enabled && !ServiceIsAuthenticated) // before logging in
				return button;

			return null;
		}

		public Button GetProposedCancelButton ()
		{
			if (button.Enabled && ServiceIsAuthenticated) // after logging in
				return button;

			return null;
		}


		bool ServiceIsConnecting {
			get { return service != null && service.IsConnecting; }
		}

		bool ServiceIsAuthenticated {
			get { return service != null && service.IsAuthenticated; }
		}

		[DefaultValue (false)]
		public bool AskConfirmationOnLogout {
			get { return ask_logout_confirmation; }
			set { ask_logout_confirmation = value; }
		}

		public IAuthService Service {
			get { return service; }
		}

		public IUserDetailsProvider UserDetailsProvider {
			set { userDetails = value; }
		}
	}
}

