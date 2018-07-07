using MvvmCross;
using MvvmCross.Forms.Platforms.Android.Core;
using MvvmCross.Forms.Presenters;
using Sample.Core.Services;
using Sample.Droid.Services;

namespace Sample.Droid
{
    public class MvxFormsSetup : MvxFormsAndroidSetup<Core.MvxApp, UI.FormsApp>
    {
        protected override IMvxFormsPagePresenter CreateFormsPagePresenter(IMvxFormsViewPresenter viewPresenter)
        {
            var formsPresenter = base.CreateFormsPagePresenter(viewPresenter);
            Mvx.RegisterSingleton(formsPresenter);
            return formsPresenter;
        }

        protected override void InitializeFirstChance()
        {
            Mvx.RegisterType<INotificationService, NotificationService>();
            base.InitializeFirstChance();
        }
    }
}