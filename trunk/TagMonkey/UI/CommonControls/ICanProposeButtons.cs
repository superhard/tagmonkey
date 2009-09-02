using System;
using System.Windows.Forms;

namespace TagMonkey.UI.CommonControls {
	interface ICanProposeButtons {
		event EventHandler ProposedButtonsChanged;

		Button GetProposedAcceptButton ();
		Button GetProposedCancelButton ();
	}
}
