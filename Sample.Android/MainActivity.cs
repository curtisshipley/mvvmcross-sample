using Android.App;
using Android.Content.PM;
using Android.Runtime;
using MvvmCross.Forms.Platforms.Android.Views;
using System;

namespace Sample.Droid
{
    [Activity(Label = "Sample", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : MvxFormsAppCompatActivity<MvxFormsSetup, Core.MvxApp, UI.FormsApp>
    {
        static MainActivity()
        {
            AndroidEnvironment.UnhandledExceptionRaiser += OnUnhandledExceptionOccurred;
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledExceptionOccurred;
        }

        private static void OnUnhandledExceptionOccurred(object sender, UnhandledExceptionEventArgs e)
        {
            Android.Util.Log.Debug("Sample", (e.ExceptionObject as Exception).ToString());
        }

        private static void OnUnhandledExceptionOccurred(object sender, RaiseThrowableEventArgs e)
        {
            Android.Util.Log.Debug("Sample", e.Exception.ToString());
        }
    }
}

