
## Sample of how to post and respond to local notifications in Android with Mvvm Cross.

This is in response to this question on Stack Overflow 

[https://stackoverflow.com/questions/48750654/mvvmcross-android-notification-pass-parameter-to-existing-viewmodel](https://stackoverflow.com/questions/48750654/mvvmcross-android-notification-pass-parameter-to-existing-viewmodel)


To send the notification:


    public void ShowNotification<VM>() where VM : IMvxViewModel
    {
        var notification = 
            new NotificationCompat.Builder(Application.Context, SampleApplication.NOTIFICATION_CHANNEL)
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

To respond we need to allow the MainActivity to know about the intent. This method checks the Intent for the serialized request for the view model. If present, 
we deserialize and then navigate.

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



