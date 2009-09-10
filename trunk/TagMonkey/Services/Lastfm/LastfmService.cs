using System;
using System.Net;

using iTunesLib;
using Lastfm;
using Lastfm.Scrobbling;
using Lastfm.Services;

using TagMonkey;
using TagMonkey.Services.Authentication;
using TagMonkey.Properties;

namespace TagMonkey.Services.Lastfm {
	class LastfmService : AuthService, ILastfmService {

		private Session session;
		private Connection connection;

		protected override void DoLogin (string login, string password)
		{
			session = new Session (Settings.Default.LastfmApiKey, Settings.Default.LastfmApiSecret);
			try {
				session.Authenticate (login, Utilities.MD5 (password));
			} catch (global::Lastfm.Services.ServiceException sex) {
				throw new AuthFailedException (GetErrorMessage (sex.Type), sex);
			} catch (WebException wex) {
				throw new ServiceUnavailableException (wex);
			}

			if (session.Authenticated)
				connection = new Connection ("glo", "0.0.2", login, session); //FIXME: register last.fm app
		}

		protected override void DoLogout ()
		{
			session = null;
		}


		string GetErrorMessage (ServiceExceptionType errType)
		{
			switch (errType) {
			case ServiceExceptionType.AuthenticationFailed:
				return "Неверное имя пользователя или пароль.";
			case ServiceExceptionType.ServiceOffline:
				return "Last.fm временно перегружен. Попробуйте позже.";
			default:
				return string.Format ("Непредвиденная ошибка Last.fm: {0}.", errType);
			}
		}

		public void Scrobble (IITFileOrCDTrack track)
		{
			Scrobble (track, 0);
		}

		public virtual void Scrobble (IITFileOrCDTrack track, int addSeconds)
		{
			Maek.Sure (IsAuthenticated, "Сначала надо войти!");
			Maek.Sure (connection != null, "Пользователь не вошёл, объект Connection не создан");

			Entry e = new Entry (track.Artist, track.Name, track.PlayedDate.AddSeconds (addSeconds), PlaybackSource.User,
				new TimeSpan (0, 0, track.Duration), ScrobbleMode.Played, track.Album, track.TrackNumber, string.Empty);

			try {
				connection.Scrobble (e);
			} catch (ScrobblingException sex) {
				string msg = string.Format ("Ошибка при скробблинге: {0}", sex.Message);
				throw new ServiceException (msg, sex);
			} catch (WebException wex) {
				throw new ServiceUnavailableException (wex);
			}
		}

		public override bool IsAuthenticated
		{
			get { return session != null && session.Authenticated; }
		}
	}
}
