using System;
using System.Windows.Forms;

namespace TagMonkey {
	static class Controlz {
		public static void Enable (params Control [] controls)
		{
			foreach (Control c in controls)
				c.Enabled = true;
		}

		public static void Disable (params Control [] controls)
		{
			foreach (Control c in controls)
				c.Enabled = false;
		}

		public static void ThreadSafe (MethodInvoker method)
		{
			TagMonkey.UI.MainForm f = UI.Forms.MainForm;
			if (f.InvokeRequired)
				f.Invoke (method);
			else
				method ();
		}
	}

}
