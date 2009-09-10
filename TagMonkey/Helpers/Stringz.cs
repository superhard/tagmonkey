using System;
using System.Collections.Generic;
using System.Text;

namespace TagMonkey {
	static class Stringz {
		public static string NotNull (string s)
		{
			if (s == null)
				return string.Empty;

			return s;
		}

	}
}
