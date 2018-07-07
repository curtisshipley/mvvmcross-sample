using Android.App;
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
        public void ShowNotification()
        {
            var notification = new NotificationCompat.Builder(Application.Context)
                .SetContentTitle("Sample app")
                .SetContentText("Click here to navigate to page 2")
                .SetSmallIcon(Resource.Drawable.ic_notification)
                .SetContentIntent(GetContentIntent())
                .SetShowWhen(false)
                .Build();

            var notificationManager = NotificationManagerCompat.From(Application.Context);
            notificationManager.Notify(1, notification);
        }

        private PendingIntent GetContentIntent()
        {
            var request = MvxViewModelRequest<Page2ViewModel>.GetDefaultRequest();
            var translator = Mvx.Resolve<IMvxAndroidViewModelRequestTranslator>();
            var intent = translator.GetIntentFor(request);
            return PendingIntent.GetActivity(Application.Context, 0, intent, 0);
        }
    }
}