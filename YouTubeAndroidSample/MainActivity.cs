using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Com.Google.Android.Youtube.Player;

namespace YouTubeAndroidSample
{
	[Activity (Label = "YouTubeAndroidSample", MainLauncher = true)]
	public class MainActivity : Activity
	{
		private const string API_KEY = "YOUR_API_KEY_HERE";
		

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);


			var button = FindViewById<Button> (Resource.Id.myButton);
			button.Click += delegate {
				var videoId = "us8j93EZt4U";

				var intent = YouTubeStandalonePlayer.CreateVideoIntent(
					this,
					API_KEY,
					videoId
				);
				StartActivity (intent);
			};
		}
	}
}


