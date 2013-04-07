using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Org.Json;

using Com.Google.Android.Youtube.Player;

namespace YouTubeAndroidSample
{
	[Activity (Label = "YouTubeAndroidSample", MainLauncher = true)]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			var button = FindViewById<Button> (Resource.Id.myButton);
			button.Click += async delegate {
				var account = new JSONObject(await ReadAccountInfo());
				var apiKey  = account.GetString("api_key");

				var videoId = "us8j93EZt4U";

				var intent = YouTubeStandalonePlayer.CreateVideoIntent(
					this,
					apiKey,
					videoId
				);
				StartActivity (intent);
			};
		}

		private async Task<string> ReadAccountInfo() {
			var stream = this.Resources.OpenRawResource(Resource.Raw.account);
			using (var s = new StreamReader(stream, Encoding.UTF8)) {
				return await s.ReadToEndAsync();
			}
		}
	}
}


