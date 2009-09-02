using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TagMonkey.UI.ExtraControls {
	// http://stackoverflow.com/questions/97459/automatically-select-all-text-on-focus-in-winforms-textbox
	/// <summary>
	/// Textbox that selects-all on focus like browser's address bar.
	/// </summary>
	partial class AutoSelectTextBox : TextBox {
		bool already_focused = false;

		public AutoSelectTextBox ()
		{
			InitializeComponent ();

			base.GotFocus += delegate {
				if (MouseButtons == MouseButtons.None) {
					this.SelectAll ();
					already_focused = true;
				}
			};
		
			base.Leave += delegate {
				already_focused = false;
			};
			
			base.MouseUp += delegate {
				if (!already_focused && this.SelectionLength == 0) {
					already_focused = true;
					this.SelectAll ();
				}
			};
		}
	}
}
