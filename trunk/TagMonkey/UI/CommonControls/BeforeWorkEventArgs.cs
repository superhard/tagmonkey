using System;
using System.Collections.Generic;
using System.Text;

namespace TagMonkey.UI.CommonControls {
	class BeforeWorkEventArgs : EventArgs {
		public bool CanProceed = false;
		public object Argument = null;
	}
}
