using System;
using System.Collections.Generic;
using System.Threading;

using Lastfm.Scrobbling;

using TagMonkey.Services.Authentication;

namespace TagMonkey.Services.Lastfm {
	class FakeLastfmService : LastfmService  {
		private bool ok = false;
		private Random r = new Random ();

		protected override void DoLogin (string login, string password)
		{
			System.Threading.Thread.Sleep (3000);
			if (r.NextDouble () > 0.9)
				throw new AuthFailedException ("Ваш логин — хуита.");

			ok = true;
		}

		protected override void DoLogout ()
		{
			ok = false;
		}

		public override bool IsAuthenticated
		{
			get { return ok; }
		}

		public override void Scrobble (iTunesLib.IITFileOrCDTrack track)
		{
			Thread.Sleep (2000);

			if (r.NextDouble () < 0.1)
				throw new ScrobblingException ("Ваш трек — хуита.");
		}
	}
}
