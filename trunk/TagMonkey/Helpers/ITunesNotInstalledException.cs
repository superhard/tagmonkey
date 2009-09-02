using System;

namespace TagMonkey {
	class ITunesNotInstalledException : Exception {
		public ITunesNotInstalledException (Exception ex)
			: base ("Для работы программы вы должны установить iTunes.", ex)
		{
		}
	}
}
