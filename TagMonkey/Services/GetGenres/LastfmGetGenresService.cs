using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

using Lastfm;
using Lastfm.Services;
using TagMonkey.Properties;

namespace TagMonkey.Services.GetGenres {
	class LastfmGetGenresService : IGetGenresService {
		private Session session;

		private static readonly List<string> descriptiveTags = new List<string> (new string [] {
			"ambient", "black metal", "blues", "blues rock", "britpop", "celtic",
			"chillout", "classic rock",  "classical", "country", "dance", "dark ambient", "death metal",
			"downtempo", "dream pop", "drum and bass", "experimental", "female vocalists", "folk", "folk metal", "folk rock", 
			"french", "funk", "german", "gothic", "gothic metal", "grindcore", "grunge",
			"hard rock", "hardcore", "heavy metal", "hip-hop", "house", "idm", "indie pop",
			"indie rock", "industrial", "j-pop", "j-rock", "jazz", "new wave", "noise",
			"nu metal", "pop punk", "pop rock", "post-hardcore", "post-punk", "post-rock", 
			"progressive rock", "progressive metal", "psychedelic", "psytrance",
			"punk rock", "rap", "reggae", "rnb", "shoegaze", "ska", "soul", "soundtrack",
			"synthpop", "techno", "thrash metal", "trance", "world"

		});
		private static readonly List<string> indescriptiveTags = new List<string> (new string [] {
			"albums i own", "acoustic", "albums", "american", "awesome", "british",
			"beautiful", "canadian", "chill", "classic", "classic rock", "cool", "cover", 
			"dead man radio", "deutch", "easy listening", "electro",
			"electronic", "electronica", "emusic",
			"favorite", "favorites", "favourite", "favourites", "female", "female vocalist", 
			"heard on pandora", "hip hop", "guitar", "indie", "instrumental", "jpop", "love", "pop",
			"post hardcore", "post punk", "post rock",
			"male vocalists", "new age", "oldies", "piano", "relax", "romantic",
			"rock", "sad", "seen live", "sexy", "singer-songwriter", "vocal",
			"00s", "10s", "20s", "30s", "40s", "50s", "60s", "70s", "80s", "90s", "2000s", 
		});

		private static readonly string [] indescriptiveTagWords = new string [] {
			"like", "love", "fav", "my", "i ", "best", "alternative", "top", "alb", " of", "records"
		};


		public LastfmGetGenresService ()
		{
			session = new Session (Settings.Default.LastfmApiKey, Settings.Default.LastfmApiSecret);
		}

		public List<string> GetGenres (string artist, string album)
		{
			List<string> genres = new List<string> ();
			try {
				Album alb = (string.IsNullOrEmpty (artist))
					? Album.Search (album, session).GetFirstMatch ()
					: new Album (artist, album, session);

				foreach (TopTag tag in alb.GetTopTags ())
					if (IsDescriptive (tag.Item.Name))
						genres.Add (tag.Item.Name);
			} catch (WebException wex) {
				throw new ServiceUnavailableException (wex);
			} catch (global::Lastfm.Services.ServiceException sex) {
				return null;
			} catch (IndexOutOfRangeException) {
				return null; // no first match
			}

			return (genres.Count > 0) ? genres : null;
		}

		static bool IsDescriptive (string tag)
		{
			if (char.IsDigit (tag [0]))
				return false;

			if (descriptiveTags.Contains (tag))
				return true;

			foreach (string badWord in indescriptiveTagWords)
				if (tag.Contains (badWord))
					return false;

			return !indescriptiveTags.Contains (tag);
		}
	}
}
