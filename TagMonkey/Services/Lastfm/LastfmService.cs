using System;
using System.Net;

using iTunesLib;
using Lastfm;
using Lastfm.Scrobbling;
using Lastfm.Services;

using TagMonkey;
using TagMonkey.Services.Authentication;

namespace TagMonkey.Services.Lastfm {
	class LastfmService : AuthService, ILastfmService {
		private const string ApiKey = "a65154a4c8dadfea92f93c0a7c94492f";
		private const string ApiSecret = "10c98fc8a17e17085c8c24d54fa7c304";

		private Session session;
		private Connection connection;

		protected override void DoLogin (string login, string password)
		{
			session = new Session (ApiKey, ApiSecret);
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


		public virtual void Scrobble (IITFileOrCDTrack track)
		{
			Maek.Sure (IsAuthenticated, "Сначала надо войти!");
			Maek.Sure (connection != null, "Пользователь не вошёл, объект Connection не создан");

			Entry e = new Entry (track.Artist, track.Name, track.PlayedDate, PlaybackSource.User,
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
