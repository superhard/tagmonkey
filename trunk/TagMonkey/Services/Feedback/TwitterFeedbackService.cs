using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace TagMonkey.Services.Feedback {
	class TwitterFeedbackService : IFeedbackService {

		private const string UserData = "dGFnbW9ua2V5OmxvbmdjYXRpc3NvbG9vb29vbmc=";
		private const int MaxTweetLength = 140;

		/*
		 * A function to post an update to Twitter programmatically
		* Author: Danny Battison
		* Contact: gabehabe@hotmail.com
		*/
		public void PostFeedback (string feedback)
		{
			try {
				byte [] bytes = System.Text.Encoding.UTF8.GetBytes ("status=" + feedback);
				HttpWebRequest request = (HttpWebRequest) WebRequest.Create ("http://twitter.com/statuses/update.xml");
				request.Method = "POST";
				request.ServicePoint.Expect100Continue = false;
				request.Headers.Add ("Authorization", "Basic " + UserData);
				request.ContentType = "application/x-www-form-urlencoded";
				request.ContentLength = bytes.Length;

				Stream reqStream = request.GetRequestStream ();
				reqStream.Write (bytes, 0, bytes.Length);
				reqStream.Close ();
			} catch (WebException wex) {
				throw new ServiceUnavailableException (wex);
			} catch (Exception ex) {
				throw new ServiceException ("Неизвестная ошибка при попытке обращения к сервису.", ex);
			}
		}

		public int MaxLength
		{
			get { return MaxTweetLength; }
		}
	}
}
