using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Windows.Forms;

using TagMonkey.Services;
using TagMonkey.Services.Feedback;
using TagMonkey.UI.CommonControls;

namespace TagMonkey.UI.Feedback {
	public partial class FeedbackControl : UserControl, ICanProposeButtons {

		public event EventHandler ProposedButtonsChanged;
		public event EventHandler HideRequested;

		private IFeedbackService feedbackService;

		public FeedbackControl ()
		{
			InitializeComponent ();
		}

		void FeedbackControl_Load (object sender, EventArgs e)
		{
			feedbackService = ServiceFactory.GetService<IFeedbackService> ();
			ideaTextBox.MaxLength = feedbackService.MaxLength;
		}

		void FeedbackControl_Enter (object sender, EventArgs e)
		{
			ideaTextBox.Select ();
		}

		void ideaTextBox_TextChanged (object sender, EventArgs e)
		{
			if (ideaTextBox.Text.Length < 2) //either 0 or 1: HasText changed
				if (ProposedButtonsChanged != null)
					ProposedButtonsChanged (this, EventArgs.Empty);

			ideaTextBox.Select ();
		}

		void hideButton_Click (object sender, EventArgs e)
		{
			if (HideRequested != null)
				HideRequested (this, EventArgs.Empty);
		}

		void sendIdeaButton_Click (object sender, EventArgs e)
		{
			if (ideaTextBox.Text.Length < 10) {
				MessageBox.Show ("Вы определённо не графоман. Можно развернуть мысль?", "Обратная связь", MessageBoxButtons.OK,
					MessageBoxIcon.Question);
				return;
			}

			try {
				feedbackService.PostFeedback (ideaTextBox.Text);
			} catch (ServiceUnavailableException) {
				ReportError ("Не удалось достучаться до сервиса. Может быть, интернет не подключён?");
			} catch (ServiceException) {
				ReportError ("Непонятная ошибка. Лучше бы написать об этом самому разработчику: gaearon@gmail.com");
			}

			MessageBox.Show ("Спасибо! Разработчик обязательно учтёт ваши пожелания :-)", "Готово", MessageBoxButtons.OK,
				MessageBoxIcon.Information);

			ideaTextBox.Clear ();

			if (HideRequested != null)
				HideRequested (this, EventArgs.Empty);
		}
	
		void ReportError (string text)
		{
			MessageBox.Show (text, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}

		public Button GetProposedAcceptButton ()
		{
			return sendIdeaButton;
		}

		public Button GetProposedCancelButton ()
		{
			return hideButton;
		}

		public bool HasText {
			get { return ideaTextBox.Text.Length > 0; }
		}

		private void ideaTextBox_KeyDown (object sender, KeyEventArgs e)
		{

		}
	}
}
