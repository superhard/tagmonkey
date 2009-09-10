using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TagMonkey.Services.GetGenres {
	class CommonGetGenresService : IGetGenresService {

		public List<string> GetGenres (string artist, string album)
		{
			List<string> discogsGenres = null;
			List<string> lastfmGenres = null;
			List<string> listsIntersection = new List<string> ();

			DiscogsGetGenresService discogs = new DiscogsGetGenresService ();
			LastfmGetGenresService lastfm = new LastfmGetGenresService ();

			discogsGenres = discogs.GetGenres (artist, album);
			lastfmGenres = lastfm.GetGenres (artist, album);

			if (IsNullOrEmptyList (discogsGenres)) {
				if (IsNullOrEmptyList (lastfmGenres))
					return null;

				listsIntersection.Add (lastfmGenres [0]);
				return listsIntersection;
			}

			discogsGenres = discogsGenres.ConvertAll (s => s.ToLowerInvariant ());

			if (IsNullOrEmptyList (lastfmGenres)) {
				listsIntersection.Add (discogsGenres [0]);
				return listsIntersection;
			}

			foreach (string lastfmGenre in lastfmGenres)
				if (discogsGenres.Contains (lastfmGenre))
					listsIntersection.Add (lastfmGenre);

			if (listsIntersection.Count == 0) {
				listsIntersection.Add (discogsGenres [0]);
			}

			listsIntersection.Sort ((t1, t2) => {
				if (t1 == t2)
					return 0;

				int t1words = t1.Split (' ', '-').Length;
				int t2words = t2.Split (' ', '-').Length;

				return -t1words.CompareTo (t2words);
			});

			listsIntersection.RemoveRange (1, listsIntersection.Count - 1);
			return listsIntersection;
		}

		bool IsNullOrEmptyList<T> (List<T> list)
		{
			return list == null || list.Count == 0;
		}
	}
}
