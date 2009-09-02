using System;
using System.Collections.Generic;
using System.Text;

namespace TagMonkey.UI.CommonControls {
	interface IUserDetailsProvider {
		string UserLogin { get; }
		string UserPassword { get; }
	}
}
