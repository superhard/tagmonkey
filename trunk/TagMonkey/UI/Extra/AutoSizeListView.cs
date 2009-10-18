using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace TagMonkey.UI.Extra {
	/// <summary>
	/// ListView that removes horizontal scrollbar if there's enough place to display all columns.
	/// </summary>
	partial class AutoSizeListView : ListView {

		private const int WM_ERASEBKND = 0x0014;

		public AutoSizeListView ()
		{
			InitializeComponent ();
			this.SetStyle (ControlStyles.OptimizedDoubleBuffer, true);
		}

		protected override void WndProc (ref Message message)
		{
			// prevent exceptions from being thrown in the designer
			try {
				int n = this.Columns.Count;
				if (n > 0 && message.Msg == WM_ERASEBKND)
					this.Columns [n-1].Width = -2; // autosize it		

				// pass the messages to base control for processing
				base.WndProc (ref message);
			}  catch { }
		}
	}
}
