using System;

namespace TagMonkey.UI.CommonControls {
	interface ILogger {
		void AddLogEntry (string subject, LogEntryKind type, string message);
		void ClearLog ();
		void SetProgressPercentage (int px);

		int EntriesCount { get; }
	}
}
