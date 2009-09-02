using System;
using System.Diagnostics;

namespace TagMonkey {
	static class Maek {
		[Conditional ("DEBUG")]
		public static void Sure (bool what, string message)
		{
			if (!what)
				throw new InvalidOperationException (message);
		}
	}
}
