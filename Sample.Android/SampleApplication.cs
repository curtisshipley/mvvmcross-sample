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

namespace Sample.Droid
{
	[Application]
	public class SampleApplication : Application
	{
		public const string NOTIFICATION_CHANNEL = "NotificationChannel1";

		public SampleApplication(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer) { }

		public override void OnCreate()
		{
			base.OnCreate();

			// Create the notification channel stuff for Oreo
			
			NotificationChannel chan = new NotificationChannel(NOTIFICATION_CHANNEL, "Notification Channel", NotificationImportance.High);

			NotificationManager notificationManager = (NotificationManager)GetSystemService(NotificationService);
			notificationManager.CreateNotificationChannel(chan);
		}


		static SampleApplication()
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