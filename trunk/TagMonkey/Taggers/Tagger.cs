using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

using iTunesLib;
using TagMonkey.Services;
using TagMonkey.UI.CommonControls;

namespace TagMonkey.Taggers {
	abstract class Tagger {

		private IITFileOrCDTrack track = null;
		private ILogger logger;
		private bool serviceAvailable = true;

		public Tagger (ILogger logger)
		{
			Maek.Sure (logger != null, "logger не должен быть null.");
			this.logger = logger;
		}

		protected IITFileOrCDTrack CurrentTrack {
			get { return track; }
			private set { track = value; }
		}

		protected abstract bool GatherRequiredInfo ();
		protected abstract void WriteChangesToFile ();
		protected abstract void ClearInfo ();

		public abstract bool RequiresWebConnection { get; }
		public abstract string FriendlyName { get; }

		public void ProcessTrack (IITFileOrCDTrack track)
		{
			Maek.Sure (track != null, "track не должен быть null.");

			if (!serviceAvailable)
				return;

			CurrentTrack = track;
			ClearInfo ();

			try {
				if (ITunez.CrashSafe<bool> (() => GatherRequiredInfo ()))
					ITunez.CrashSafe (() => WriteChangesToFile ());
			} catch (ServiceUnavailableException) {
				throw;
			}  catch (ServiceException sex) {
				Log (FriendlyName, LogEntryKind.Error, sex.Message);
			} catch (COMException) {
				Log (LogEntryKind.Error, "Не удалось осуществить запись в файл");
			} finally {
				CurrentTrack = null;
			}
		}

		protected void Log (LogEntryKind kind, string msg)
		{
			ITunez.CrashSafe (() => Log (track.Artist + " — " + track.Name, kind, msg));
		}

		protected void Log (string subject, LogEntryKind kind, string msg)
		{
			logger.AddLogEntry (subject, kind, msg);
		}

		protected void LogAlbum (LogEntryKind kind, string msg)
		{
			string subject = (CurrentTrack.Compilation) ? "Разные исполнители" : CurrentTrack.Artist;
			subject += " — " + CurrentTrack.Album + " (альбом)";

			Log (subject, kind, msg);
		}
	}
}
