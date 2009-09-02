using System;

namespace TagMonkey.Services {
	class ServiceException : Exception {
		public ServiceException (string message)
			: base (message) { }

		public ServiceException (string message, Exception inner)
			: base (message, inner) { }
	}
}
