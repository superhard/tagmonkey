using System;
using System.Windows.Forms;

namespace TagMonkey.UI.Common {
	interface ICanProposeButtons {
		event EventHandler ProposedButtonsChanged;

		Button GetProposedAcceptButton ();
		Button GetProposedCancelButton ();
	}
}
