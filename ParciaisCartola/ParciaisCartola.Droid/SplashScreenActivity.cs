
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ParciaisCartola.Droid
{
	[Activity(Theme="@style/ParciaisCartolaTheme.Splash", MainLauncher=true, NoHistory=true)]
	public class SplashScreenActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your application here
		}

		protected override void OnResume()
		{
			base.OnResume();
			StartActivity(new Intent(Application.Context, typeof(MainActivity)));
		}
	}
}
