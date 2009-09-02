using System;
using System.Windows.Forms;

using iTunesLib;

namespace TagMonkey.UI.CommonControls {
	partial class LoggerControl : UserControl, ILogger {

		public event EventHandler LogEntryAdded;
		public event EventHandler LogCleared;

		public LoggerControl ()
		{
			InitializeComponent ();
		}

		public void AddLogEntry (string subject, LogEntryKind entryKind, string message)
		{
			string [] cells = { string.Empty, subject, message };
			string iconKey = Enum.GetName (typeof (LogEntryKind), entryKind);
			logListView.Items.Insert (0, new ListViewItem (cells, iconKey));

			if (LogEntryAdded != null)
				LogEntryAdded (this, EventArgs.Empty);
		}

		public void ClearLog ()
		{
			logListView.Items.Clear ();

			if (LogCleared != null)
				LogCleared (this, EventArgs.Empty);
		}

		public void SetProgressPercentage (int px)
		{
			Maek.Sure (px >= 0 && px <= 100, "Проценты должны быть от 0 до 100.");
			progressBar.Value = px;
		}

		public int EntriesCount {
			get { return logListView.Items.Count; }
		}
	}
}
