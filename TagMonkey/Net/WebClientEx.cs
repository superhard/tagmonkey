/*****************************************************************************
  Copyright © 2003 - 2007 by CodeGator. All rights are reserved. If you like
  this code then feel free to go ahead and use it. The only thing we ask is
  that you don't remove or alter our copyright notice. Your use of this
  software is entirely at your own risk. CodeGator make no claims about the
  reliability or fitness of this code for any particular purpose. If you make
  changes or additions to the code then please clearly mark your changes as
  your own.

  Have Fun! :o)
*****************************************************************************/

using System;
using System.Net;

namespace TagMonkey.Net {

	/// <summary>
	/// A web-client class with additional properties.
	/// </summary>
	public class WebClientEx : WebClient {

		// ******************************************************************
		// Fields.
		// ******************************************************************

		#region Fields

		private System.Net.CookieContainer cookieContainer;
		private string userAgent;
		private int timeout;

		#endregion

		// ******************************************************************
		// Properties.
		// ******************************************************************

		#region Properties

		/// <summary>
		/// Gets or sets the cookies associated with the request.
		/// </summary>
		public System.Net.CookieContainer CookieContainer
		{
			get { return cookieContainer; }
			set { cookieContainer = value; }
		}

		// ******************************************************************

		/// <summary>
		/// Gets or sets the value of the User-agent HTTP header.
		/// </summary>
		public string UserAgent
		{
			get { return userAgent; }
			set { userAgent = value; }
		}

		// ******************************************************************

		/// <summary>
		/// Gets or sets the time-out value for the System.Net.HttpWebRequest.GetResponse()
		/// and System.Net.HttpWebRequest.GetRequestStream() methods.
		/// </summary>
		public int Timeout
		{
			get { return timeout; }
			set { timeout = value; }
		}

		#endregion

		// ******************************************************************
		// Constructors.
		// ******************************************************************

		#region Constructors

		/// <summary>
		/// Creates a new instance of the WebClientEx class.
		/// </summary>
		public WebClientEx ()
		{
			timeout = -1;
			userAgent = @"Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727; InfoPath.1; IEMB3; .NET CLR 3.0.04506.30; IEMB3)";
			cookieContainer = new CookieContainer ();
		}

		public WebClientEx (int timeout)
		{
			this.timeout = timeout;
			userAgent = @"Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727; InfoPath.1; IEMB3; .NET CLR 3.0.04506.30; IEMB3)";
			cookieContainer = new CookieContainer ();
		}


		#endregion

		// ******************************************************************
		// Overrides.
		// ******************************************************************

		#region Overrides

		/// <summary>
		/// Returns a System.Net.WebRequest object for the specified resource.
		/// </summary>
		/// <param name="address">A System.Uri that identifies the resource to request.</param>
		/// <returns>A new System.Net.WebRequest object for the specified resource.</returns>
		protected override WebRequest GetWebRequest (Uri address)
		{

			WebRequest request = base.GetWebRequest (address);

			if (request.GetType () == typeof (HttpWebRequest)) {
				((HttpWebRequest) request).CookieContainer = cookieContainer;
				((HttpWebRequest) request).UserAgent = userAgent;
				((HttpWebRequest) request).Timeout = timeout;
				((HttpWebRequest) request).AllowAutoRedirect = true;
			}

			return request;
		}

		#endregion
	}

}
