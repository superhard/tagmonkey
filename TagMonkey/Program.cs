using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using iTunesLib;

namespace TagMonkey {
	static class Program {

		[STAThread]
		static void Main ()
		{
			Application.EnableVisualStyles ();
			Application.SetCompatibleTextRenderingDefault (false);
			Application.Run (UI.Forms.MainForm);
		}
	}
}
