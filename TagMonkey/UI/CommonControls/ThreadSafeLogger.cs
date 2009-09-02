using System.Windows.Forms;
using System;

using iTunesLib;

namespace TagMonkey.UI.CommonControls {
	class ThreadSafeLogger : ILogger {

		private ILogger logger;
		private Control context;

		public ThreadSafeLogger (ILogger unsafeLogger, Control context)
		{
			this.logger = unsafeLogger;
			this.context = context;
		}

		public void AddLogEntry (string subject, LogEntryKind type, string message)
		{
			Controlz.ThreadSafe (() => logger.AddLogEntry (subject, type, message));
		}

		public void ClearLog ()
		{
			Controlz.ThreadSafe (() => logger.ClearLog ());
		}

		public void SetProgressPercentage (int px)
		{
			Controlz.ThreadSafe (() => logger.SetProgressPercentage (px));
		}

		public int EntriesCount {
			get { return logger.EntriesCount; }
		}
	}
}
