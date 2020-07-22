﻿using Xamarin.Forms;
using System;

namespace FormsBackgrounding
{
	public class App : Application
	{
		#region Constructor
		private readonly BackgroundPage _backgroundPage;

		public App ()
		{
			_backgroundPage = new BackgroundPage ();

			var tabbedPage = new TabbedPage ();
			tabbedPage.Children.Add (_backgroundPage);
			tabbedPage.Children.Add (new LongRunningPage ());
			tabbedPage.Children.Add (new DownloadPage ());

			MainPage = tabbedPage;
		}
		#endregion

		protected override void OnStart ()
		{
			LoadPersistedValues ();
		}

		protected override void OnSleep ()
		{
			Application.Current.Properties ["SleepDate"] = DateTime.Now.ToString("O");
			Application.Current.Properties ["FirstName"] = _backgroundPage.FirstName;
		}

		protected override void OnResume ()
		{
			LoadPersistedValues ();
		}

		private void LoadPersistedValues()
		{
			if (Application.Current.Properties.ContainsKey("SleepDate")) {
				var value = (string)Application.Current.Properties ["SleepDate"];
				DateTime sleepDate;
				if (DateTime.TryParse (value, out sleepDate)) {
					_backgroundPage.SleepDate = sleepDate;
				}
			}

			if (Application.Current.Properties.ContainsKey("FirstName")) {
				var firstName = (string)Application.Current.Properties ["FirstName"];
				_backgroundPage.FirstName = firstName;
			}
		}
			
	}
}