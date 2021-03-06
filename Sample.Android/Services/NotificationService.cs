﻿using Android.App;
using Android.Content;
using Android.Support.V4.App;
using MvvmCross;
using MvvmCross.Platforms.Android.Views;
using MvvmCross.ViewModels;
using Sample.Core.Services;
using Sample.Core.ViewModels;

namespace Sample.Droid.Services
{
	public class NotificationService : INotificationService
	{

		public void ShowNotification<VM>() where VM : IMvxViewModel
		{
			var notification = new NotificationCompat.Builder(Application.Context, SampleApplication.NOTIFICATION_CHANNEL)
				.SetContentTitle("Sample app")
				.SetContentText("Click here to navigate to page 2")
				.SetSmallIcon(Resource.Drawable.ic_notification)
				.SetContentIntent(GetContentIntent<VM>())
				.SetShowWhen(false)
				.Build();

			var notificationManager = NotificationManagerCompat.From(Application.Context);
			notificationManager.Notify(1, notification);
		}

		private PendingIntent GetContentIntent<VM>() where VM : IMvxViewModel
		{
			var request = MvxViewModelRequest<VM>.GetDefaultRequest();

			var converter = Mvx.Resolve<IMvxNavigationSerializer>();
			var requestText = converter.Serializer.SerializeObject(request);

			var intent = new Intent(Application.Context, typeof(MainActivity)); 

			// We only want one activity started
			intent.AddFlags(ActivityFlags.SingleTop);
			
			intent.PutExtra("MvxLaunchData", requestText);

			// Create Pending intent, with OneShot. We're not going to want to update this.
			return PendingIntent.GetActivity(Application.Context, 0, intent, PendingIntentFlags.OneShot);
		}

	}
}