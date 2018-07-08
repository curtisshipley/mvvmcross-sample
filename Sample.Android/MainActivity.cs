using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using MvvmCross;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Forms.Platforms.Android.Views;
using MvvmCross.ViewModels;
using MvvmCross.Views;
using System;

namespace Sample.Droid
{
	[Activity(Label = "Sample", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : MvxFormsAppCompatActivity<MvxFormsSetup, Core.MvxApp, UI.FormsApp>
	{
		public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
		{
			base.OnCreate(savedInstanceState, persistentState);

			NavigateToRequestIfPresent(Intent);
		}

		protected override void OnNewIntent(Intent intent)
		{
			base.OnNewIntent(intent);

			NavigateToRequestIfPresent(intent);
		}

		protected void NavigateToRequestIfPresent(Intent intent)
		{
			// If MvxLaunchData is present, we then know we should navigate to that intent
			var requestText = intent.GetStringExtra("MvxLaunchData");

			if (requestText == null)
				return;

			var viewDispatcher = Mvx.Resolve<IMvxViewDispatcher>();

			var converter = Mvx.Resolve<IMvxNavigationSerializer>();
			var request = converter.Serializer.DeserializeObject<MvxViewModelRequest>(requestText);

			viewDispatcher.ShowViewModel(request);
		}



	}
}

