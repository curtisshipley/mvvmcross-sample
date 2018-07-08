using System;
using MvvmCross.ViewModels;

namespace Sample.Core.Services
{
    public interface INotificationService
    {
        void ShowNotification<VM>() where VM : IMvxViewModel;
    }
}