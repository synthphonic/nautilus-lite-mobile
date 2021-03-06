﻿using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Todo;

namespace Todo.Droid
{
	[Activity(Label = "Todo-NautilusLite", Icon = "@mipmap/appicon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(savedInstanceState);

			Xamarin.Essentials.Platform.Init(this, savedInstanceState);
			global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
			global::Xamarin.Forms.FormsMaterial.Init(this, savedInstanceState);
			InitializeLibraries();

			LoadApplication(new App());
		}

		public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
		{
			Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

			base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
		}

		private void InitializeLibraries()
		{
			NautilusLite.Droid.NautilusServices.Init();
			ImageCircle.Forms.Plugin.Droid.ImageCircleRenderer.Init();
			Xamarin.Forms.PancakeView.Droid.PancakeViewRenderer.Init();
			Acr.UserDialogs.UserDialogs.Init(this);
		}
	}
}