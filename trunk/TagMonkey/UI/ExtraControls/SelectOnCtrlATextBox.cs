using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TagMonkey.UI.ExtraControls {
	public partial class SelectOnCtrlATextBox : TextBox {
		public SelectOnCtrlATextBox ()
		{
			InitializeComponent ();
		}

		//http://schotime.net/blog/index.php/2008/03/12/select-all-ctrla-for-textbox/
		protected override void OnKeyDown (KeyEventArgs e)
		{
			if (e.Control && (e.KeyCode == Keys.A)) {
				this.SelectAll ();
				e.SuppressKeyPress = true;
				e.Handled = true;
			} else
				base.OnKeyDown (e);
		}
	}
}
