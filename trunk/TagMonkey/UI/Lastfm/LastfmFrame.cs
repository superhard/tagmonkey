using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using iTunesLib;
using LastfmLib = Lastfm;

using TagMonkey.Properties;
using TagMonkey.Services;
using TagMonkey.Services.Lastfm;
using TagMonkey.UI.CommonControls;

namespace TagMonkey.UI.Lastfm {
	partial class LastfmFrame : UserControl, ICanProposeButtons {

		public event EventHandler ProposedButtonsChanged;

		private ILogger logger;
		private ILastfmService lastfm;

		public LastfmFrame ()
		{
			InitializeComponent ();

			logger = new ThreadSafeLogger (loggerControl, this);
			lastfm = ServiceFactory.GetService<ILastfmService> ();

			loginControl.SetLastfmService (lastfm);

			lastfm.LoginSuccessful += (s, a) =>
				RefreshControlsState ();
			trackQueue.TracksToScrobbleChanged += (s, a) =>
				RefreshControlsState ();

			lastfm.LoggedOut += delegate {
				RefreshControlsState ();
				ResetProgressBar ();
			};
			trackQueue.ScanningStarted += delegate {
				RefreshControlsState ();
				ResetProgressBar ();
			};

			scrobbleButton.EnabledChanged += delegate {
				if (ProposedButtonsChanged != null)
					ProposedButtonsChanged (this, EventArgs.Empty);
			};
		}

		void LastfmScrobblerFrame_Load (object sender, EventArgs e)
		{
			RefreshControlsState ();
		}

		void RefreshControlsState ()
		{
			scrobbleButton.Enabled = lastfm.IsAuthenticated
				&& trackQueue.HasTracksToScrobble;

			bool isScrobbling = scrobbleButton.IsBusy;
			trackQueue.Enabled = !isScrobbling;
			loginControl.Enabled = !isScrobbling;
		}

		void scrobbleButton_BeforeWork (object sender, BeforeWorkEventArgs e)
		{
			if (!trackQueue.HasTracksToScrobble) {
				e.CanProceed = false;
				return;
			}

			trackQueue.RemoveUnselectedRows ();
			e.Argument = trackQueue.GetTracksToScrobble ();
			e.CanProceed = true;

			RefreshControlsState ();
			trackQueue.Enabled = false;
		}


		void scrobbleButton_AfterWork (object sender, RunWorkerCompletedEventArgs e)
		{
			trackQueue.Clear ();
			trackQueue.Enabled = true;

			if (e.Cancelled)
				ResetProgressBar ();

			RefreshControlsState ();
		}

		void scrobbleButton_DoWork (object sender, DoWorkEventArgs e)
		{
			ReadOnlyCollection<IITFileOrCDTrack> tx = (ReadOnlyCollection<IITFileOrCDTrack>) e.Argument;
			for (int i = 0; i < tx.Count; i++) {
				IITFileOrCDTrack tr = tx [i];
				if (scrobbleButton.CancellationPending) {
					e.Cancel = true;
					return;
				}

				string loggerText = tr.Artist + " — " + tr.Name; //FIXME:DUEP
				try {
					int addSeconds = 0; // many simultaneous scrobbles are treated as the same
					while (ITunez.CrashSafe (() => tr.PlayedCount > 0)) {
						try {
							ITunez.CrashSafe (() => lastfm.Scrobble (tr, addSeconds));
						} catch (LastfmLib.Scrobbling.ScrobblingException ex) {
							logger.AddLogEntry (loggerText, LogEntryKind.Error, ex.Message);
							continue; //TODO: break if too many failures
						}

						ITunez.CrashSafe (() => tr.PlayedCount --);
						addSeconds++;

						logger.AddLogEntry (loggerText, LogEntryKind.Information, "Готово");
						logger.SetProgressPercentage ((int) ((float) (i+1) / (float) tx.Count * 100.0));
					}
				} catch (COMException) {
					logger.AddLogEntry (string.Empty, LogEntryKind.Error, "Ошибка при извлечении данных");
					continue;
				}

				Controlz.ThreadSafe (() => trackQueue.RemoveRow (tr));
			}
		}

		void ResetProgressBar ()
		{
			logger.SetProgressPercentage (0);
		}

		public Button GetProposedAcceptButton ()
		{
			return scrobbleButton.GetProposedAcceptButton ()
				?? loginControl.GetProposedAcceptButton ()
				?? ((trackQueue.Enabled)
					? trackQueue.GetProposedAcceptButton ()
					: null);
		}

		public Button GetProposedCancelButton ()
		{
			return scrobbleButton.GetProposedCancelButton ()
				?? trackQueue.GetProposedCancelButton ()
				?? loginControl.GetProposedCancelButton ();
		}
	}
}
