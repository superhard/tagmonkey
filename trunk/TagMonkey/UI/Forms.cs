using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TagMonkey.UI {
	static class Forms {
		private static Dictionary<Type, Form> forms = new Dictionary<Type, Form> ();

		static TForm GetForm<TForm> ()
			where TForm : Form, new()
		{
			if (forms.ContainsKey (typeof (TForm)))
				return (TForm) forms [typeof (TForm)];

			TForm form = new TForm ();
			forms.Add (typeof (TForm), form);
			return form;
		}

		public static MainForm MainForm {
			get { return GetForm<MainForm> (); }
		}
	}
}
