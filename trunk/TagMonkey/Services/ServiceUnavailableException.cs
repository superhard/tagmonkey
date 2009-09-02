using System;
using System.Collections.Generic;
using System.Text;

namespace TagMonkey.Services {
	class ServiceUnavailableException : ServiceException {
		private const string DefaultMessage = "Не удалось связаться с сервисом. Проверьте подключение к интернету.";

		public ServiceUnavailableException (string message)
			: base (message) { }

		public ServiceUnavailableException (string message, Exception inner)
			: base (message, inner) { }
		
		public ServiceUnavailableException ()
			: base (DefaultMessage) { }

		public ServiceUnavailableException (Exception inner)
			: base (DefaultMessage, inner) { }
	}
}
