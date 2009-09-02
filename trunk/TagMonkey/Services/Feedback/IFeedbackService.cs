using System;

using TagMonkey.Services;

namespace TagMonkey.Services.Feedback {
	interface IFeedbackService : IService {
		void PostFeedback (string feedback);
		int MaxLength { get; }
	}
}
