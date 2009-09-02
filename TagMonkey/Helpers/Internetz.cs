using System;
using System.Net.NetworkInformation;

namespace TagMonkey {
	static class Internetz {
		private static readonly string [] pingList
			= new string [] { "www.google.com", "www.4chan.org", "www.microsoft.com" };

		public static bool PingPong ()
		{
			Ping ping = new Ping ();
			int phailed = 0;
			for (int i = 0; i < pingList.Length; i++) {
				PingReply reply = ping.Send (pingList [i], 5000);
				if (reply.Status == IPStatus.Success)
					return true;
				else
					phailed++;
			}

			if (phailed == pingList.Length)
				return false;

			return true;
		}

	}

}
