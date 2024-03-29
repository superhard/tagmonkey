﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

using iTunesLib;

using TagMonkey.Taggers;
using TagMonkey.UI.Common;

namespace TagMonkey.UI.AutoTagger {
	partial class AutoTaggerFrame : UserControl, ICanProposeButtons {

		private delegate bool ActionCheck (IITFileOrCDTrack track);

		public event EventHandler ProposedButtonsChanged;

		private ILogger logger = null;

		public AutoTaggerFrame ()
		{
			InitializeComponent ();
		}

		void TagFillerFrame_Load (object sender, EventArgs e)
		{
			playlistSelector.SelectedPlaylistChanged += (s, a) =>
				RefreshBoomboxState ();
			taggerOptions.OptionsChanged += (s, a) =>
				RefreshBoomboxState ();

			boombox.EnabledChanged += delegate {
				if (ProposedButtonsChanged != null)
					ProposedButtonsChanged (this, EventArgs.Empty);
			};

			Controlz.Disable (clearLogButton);
			logger = new ThreadSafeLogger (unsafeLogger, this);

			if (ParentForm != null) {
				ParentForm.FormClosing += delegate { taggerWorker.CancelAsync (); };
			};
		}

		void boombox_Go (object sender, EventArgs e)
		{
			Controlz.Disable (taggerOptions, playlistSelector);
			logger.ClearLog ();
			logger.SetProgressPercentage (0);

			taggerWorker.RunWorkerAsync (playlistSelector.SelectedTracks);
		}

		void boombox_Stop (object sender, EventArgs e)
		{
			taggerWorker.CancelAsync ();
			Controlz.Disable (boombox);

			ProposedButtonsChanged (this, EventArgs.Empty);
		}

		void worker_DoWork (object sender, DoWorkEventArgs e)
		{
			IITTrackCollection tracks = e.Argument as IITTrackCollection;
			if (tracks == null)
				return;

			TaggerFactory.CurrentLogger = logger;
			AutoTaggerOptions options = taggerOptions.Options;
			foreach (TaggerKind kind in options.SelectedTaggers) {
				if (taggerWorker.CancellationPending) {
					e.Cancel = true;
					return;
				}

				Tagger tagger = TaggerFactory.GetTagger (kind);

				ActionCheck check = GetActionCheck (kind, options);
				Action<IITFileOrCDTrack> action = new Action<IITFileOrCDTrack> (tagger.ProcessTrack);

				Controlz.ThreadSafe (() => taggerOptions.SetBoldFeature (kind, true));
				try {
					ApplyAction (tracks, check, action);
				} catch (Services.ServiceUnavailableException) {
					if (tagger.RequiresWebConnection) {
						string msg;
						msg = Internetz.PingPong ()
							? "Сервис недоступен"
							: "Необходимо подключение к интернету";

						logger.AddLogEntry (tagger.FriendlyName, LogEntryKind.Error, msg);
						continue; // since it requires connection, skip the rest of playlist
					} else {
						logger.AddLogEntry (tagger.FriendlyName, LogEntryKind.Error, "Сервис недоступен");
					}
				} finally {
					Controlz.ThreadSafe (() => taggerOptions.SetBoldFeature (kind, false));
				}

				if (taggerWorker.CancellationPending) {
					e.Cancel = true;
					return;
				}
			}
		}

		void worker_ProgressChanged (object sender, ProgressChangedEventArgs e)
		{
			logger.SetProgressPercentage (e.ProgressPercentage);
		}

		void worker_RunWorkerCompleted (object sender, RunWorkerCompletedEventArgs e)
		{
			logger.SetProgressPercentage (e.Cancelled ? 0 : 100);

			Controlz.Enable (playlistSelector, taggerOptions);
			RefreshBoomboxState ();

			ProposedButtonsChanged (this, EventArgs.Empty);

			if (boombox.IsWorking || boombox.IsPaused)
				boombox.DoStop ();
		}

		void clearLogButton_Click (object sender, EventArgs e)
		{
			logger.ClearLog ();
			Controlz.Disable (clearLogButton);

			if (!boombox.IsWorking)
				logger.SetProgressPercentage (0);
		}

		void RefreshBoomboxState ()
		{
			boombox.Enabled = taggerOptions.Options.AnyChangedRequested;
		}

		ActionCheck GetActionCheck (TaggerKind taggerKind, AutoTaggerOptions options)
		{
			if (options.OnlyMissingArtwork && (taggerKind == TaggerKind.ArtworkDownloader
				|| taggerKind == TaggerKind.ArtworkTagger))
				return (t => t.Artwork.Count == 0);
			else if (options.OnlyMissingGenre && taggerKind == TaggerKind.GenreTagger)
				return (t => string.IsNullOrEmpty (t.Genre));
			else if (options.OnlyMissingLyrics && taggerKind == TaggerKind.LyricsTagger)
				return (t => string.IsNullOrEmpty (t.Lyrics));
			else
				return (t => true);
		}

		void ApplyAction (IITTrackCollection tracks, ActionCheck check, Action<IITFileOrCDTrack> action)
		{
			int n = ITunez.CrashSafe (() => tracks.Count);
			for (int i = 1; i <= n; i++) {
				var track = ITunez.CrashSafe (() =>
					(IITFileOrCDTrack) tracks.get_ItemByPlayOrder (i));

				while (boombox.IsPaused) {
					Thread.Sleep (300);
					if (taggerWorker.CancellationPending)
						return;
				}

				if (taggerWorker.CancellationPending)
					return;

				// do action!
				if (ITunez.CrashSafe (() => check (track)))
					action (track); // taggers are itunes-safe

				taggerWorker.ReportProgress ((int) ((float) i / (float) n * 100.0));

				if (logger.EntriesCount > 0)
					Controlz.ThreadSafe (() => Controlz.Enable (clearLogButton));
			}
		}

		public Button GetProposedAcceptButton ()
		{
			return boombox.GetProposedAcceptButton ()
				?? taggerOptions.GetProposedAcceptButton ()
				?? playlistSelector.GetProposedAcceptButton ();
		}

		public Button GetProposedCancelButton ()
		{
			return boombox.GetProposedCancelButton ()
				?? clearLogButton;
		}
	}
}
