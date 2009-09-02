using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using iTunesLib;

namespace TagMonkey {
	static class ITunez {
		public delegate T Func<T> ();

		private const string ITunesBusyHResult = "0x8001010A";
		private const string ITunesCallRejectedHResult = "0x80010001";

		public static event EventHandler Launched;

		private static iTunesApp app = null;

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
				} catch (COMException cex) {
					if (cex.Message.Contains (ITunesBusyHResult)
						|| cex.Message.Contains (ITunesCallRejectedHResult))
						ShowFreeITunesMessage ();
					else throw;
				}
			} while (!success);
		}

		static void ShowFreeITunesMessage ()
		{
			MessageBox.Show ("Закройте все диалоговые окна iTunes, кроме основного, и нажмите OK.",
				"Закройте все диалоговые окна iTunes", MessageBoxButtons.OK,
				MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,
				MessageBoxOptions.DefaultDesktopOnly);
		}


		public static iTunesApp Instance
		{
			get { return app; }
		}
	}
}
