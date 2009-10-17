using System;

using TagMonkey.UI.Common;

namespace TagMonkey.Taggers {
	class NamesFormatter : Tagger {

		public NamesFormatter (ILogger logger)
			: base (logger) { }

		protected override bool GatherRequiredInfo ()
		{
			throw new NotImplementedException ();
		}

		protected override void WriteChangesToFile ()
		{
			throw new NotImplementedException ();
		}

		protected override void ClearInfo ()
		{
			throw new NotImplementedException ();
		}

		public override bool RequiresWebConnection {
			get { return false; }
		}

		public override string FriendlyName
		{
			get { return "Стандартное форматирование имён"; }
		}
	}
}
