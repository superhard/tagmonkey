using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using iTunesLib;

namespace TagMonkey {
	static class ITunez {
		public delegate T Func<T> ();
		
		private const uint ITunesBusyHResult = 0x8001010A;
		private const uint ITunesCallRejectedHResult = 0x80010001;

		private const uint ITunesDisconnectedHResult = 0x80010108;
		private const uint ITunesUnavailableHResult = 0x800706BA;
		private const uint ITunesRPCFailedHResult = 0x800706BE;
		
		public static event EventHandler Launched;

		private static iTunesApp app = null;
		private static bool is_now_restarting = false;

		public static void Go ()
		{
			BackgroundWorker launcher = new BackgroundWorker ();
			launcher.DoWork += delegate {
				try {
					app = new iTunesApp ();
				} catch (COMException ex) {
					throw new ITunesNotInstalledException (ex);
				}
			};
			launcher.RunWorkerCompleted += (s, a) => {
				if (Launched != null)
					Launched (null, EventArgs.Empty);
			};
			launcher.RunWorkerAsync ();
		}

		public static T CrashSafe<T> (Func<T> func)
		{
			T result = default (T);
			CrashSafe (new MethodInvoker (() => result = func ()));
			return result;
		}

		public static void CrashSafe (MethodInvoker method)
		{
			bool success = false;
			do {
				try {
					method ();
					success = true;
				} catch (InvalidCastException icex) { // sometimes gets thrown when itunes's been closed
					if (icex.Message.Contains (string.Format ("{0:X}", ITunesDisconnectedHResult))
						|| icex.Message.Contains (string.Format ("{0:X}", ITunesUnavailableHResult))
						|| icex.Message.Contains (string.Format ("{0:X}", ITunesRPCFailedHResult))) {
						if (ConfirmRestart ()) {
							is_now_restarting = true;
							Application.Restart ();
						}
					} else throw;
				} catch (COMException cex) {
					if ((uint) cex.ErrorCode == ITunesBusyHResult
						|| (uint) cex.ErrorCode == ITunesCallRejectedHResult) {
						AskToCloseModalDialogs ();
					} else if ((uint) cex.ErrorCode == ITunesDisconnectedHResult
						|| (uint) cex.ErrorCode == ITunesUnavailableHResult
						|| (uint) cex.ErrorCode == ITunesRPCFailedHResult) {
						if (ConfirmRestart ()) {
							is_now_restarting = true;
							Application.Restart ();
						}
					} else throw;
				}
			} while (!(success || is_now_restarting));
		}

		static void AskToCloseModalDialogs ()
		{
			MessageBox.Show ("Закройте все диалоговые окна iTunes, кроме основного, и нажмите OK.",
				"Закройте все диалоговые окна iTunes", MessageBoxButtons.OK,
				MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,
				MessageBoxOptions.DefaultDesktopOnly);
		}

		static bool ConfirmRestart ()
		{
			return MessageBox.Show (
				"Связь программы с iTunes потеряна. " + Environment.NewLine
				+ "Обычно в таком случае достаточно перезапустить программу, и она сама перезапустит iTunes." + Environment.NewLine
				+ "Если эта проблема продолжает появляться, убедитесь, что iTunes установлен и корректно работает." + Environment.NewLine
				+ "В таком случае запишите в точности по порядку действия, которые привели к ошибке," + Environment.NewLine
				+ "и обратитесь к разработчику: http://vkontakte.ru/id16921756." + Environment.NewLine
				+ "Перезапустить TagMonkey?",
				"Ошибка", MessageBoxButtons.OKCancel,
				MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,
				MessageBoxOptions.DefaultDesktopOnly)
				
				== DialogResult.OK;
		}

		public static iTunesApp Instance
		{
			get { return app; }
		}
	}
}
