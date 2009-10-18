using System;
using System.Collections.Generic;
using System.Text;

namespace TagMonkey.UI.Common {
	class BeforeWorkEventArgs : EventArgs {
		public bool CanProceed = false;
		public object Argument = null;
	}
}
