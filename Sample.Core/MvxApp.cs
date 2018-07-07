using MvvmCross.ViewModels;
using Sample.Core.ViewModels;

namespace Sample.Core
{
    public class MvxApp : MvxApplication
    {
        public override void Initialize()
        {
            RegisterAppStart<HomeViewModel>();
        }
    }
}
