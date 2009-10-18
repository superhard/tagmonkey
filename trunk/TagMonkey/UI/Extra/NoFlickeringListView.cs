using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace TagMonkey.UI.Extra {
	/// <summary>
	/// ListView that ain't flickers.
	/// </summary>
	partial class NoFlickeringListView : ListView {
		
		private const int WM_ERASEBKND = 0x0014;

		public NoFlickeringListView ()
		{
			InitializeComponent ();
			
			//Activate double buffering
			this.SetStyle (ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

			//Enable the OnNotifyMessage event so we get a chance to filter out 
			// Windows messages before they get to the form's WndProc
			this.SetStyle (ControlStyles.EnableNotifyMessage, true);

		}

		protected override void WndProc (ref Message message)
		{
			try {
				if (message.Msg != WM_ERASEBKND)
					base.WndProc (ref message);
			} catch {
				// who cares?
			}
		}
	}
}
