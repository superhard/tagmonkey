using System;
using System.Collections.Generic;
using System.Text;

namespace TagMonkey.UI.Common {
	interface IUserDetailsProvider {
		string UserLogin { get; }
		string UserPassword { get; }
	}
}
