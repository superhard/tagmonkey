using System;
using System.Collections.Generic;
using System.Text;

using TagMonkey.Services.Feedback;
using TagMonkey.Services.GetArtwork;
using TagMonkey.Services.GetGenres;
using TagMonkey.Services.GetLyrics;
using TagMonkey.Services.Lastfm;

namespace TagMonkey.Services {
	static class ServiceFactory {
		private static Dictionary<Type, Type> implTable;
		private static Dictionary<Type, IService> instances;

		private const bool UseFakeLastfm = false;

		static ServiceFactory ()
		{
			implTable = new Dictionary<Type, Type> ();
			implTable.Add (typeof (IGetArtworkService), typeof (GoogleImagesGetArtworkService));
			implTable.Add (typeof (IGetGenresService), typeof (CommonGetGenresService));
			implTable.Add (typeof (IGetLyricsService), typeof (LyricWikiService));
			implTable.Add (typeof (IFeedbackService), typeof (TwitterFeedbackService));
			implTable.Add (typeof (ILastfmService), (UseFakeLastfm)
				? typeof (FakeLastfmService)
				: typeof (LastfmService));

			instances = new Dictionary<Type, IService> ();
		}

		public static TService GetService<TService> ()
			where TService : IService
		{
			Maek.Sure (implTable.ContainsKey (typeof (TService)), "Неподдерживаемый вид сервиса (должен быть интерфейс)");
			return (TService) GetService (implTable [typeof (TService)]);
		}

		static IService GetService (Type implType)
		{
			if (instances.ContainsKey (implType))
				return instances [implType];

			IService service = (IService) Activator.CreateInstance (implType);
			instances [implType] = service;
			return service;
		}
	}
}
