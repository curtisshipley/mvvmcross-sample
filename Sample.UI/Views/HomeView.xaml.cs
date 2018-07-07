using MvvmCross.Forms.Views;
using Xamarin.Forms.Xaml;

namespace Sample.UI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeView : MvxContentPage
    {
        public HomeView()
        {
            InitializeComponent();
        }
    }
}