using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Sample.Core.Services;

namespace Sample.Core.ViewModels
{
    public class HomeViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService navigationService;
        private readonly INotificationService notificationService;

        public IMvxCommand ShowNotificationCommand => new MvxCommand(ShowNotification);

        public IMvxCommand NavigateToPage2Command => new MvxCommand(NavigateToPage2);

        public HomeViewModel(IMvxNavigationService navigationService, INotificationService notificationService)
        {
            this.navigationService = navigationService;
            this.notificationService = notificationService;
        }

        private void ShowNotification()
        {
            notificationService.ShowNotification();
        }

        private async void NavigateToPage2()
        {
            await navigationService.Navigate<Page2ViewModel>();
        }
    }
}
