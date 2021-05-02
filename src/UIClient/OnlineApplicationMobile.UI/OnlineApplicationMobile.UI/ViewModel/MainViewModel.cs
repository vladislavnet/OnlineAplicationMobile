using OnlineApplicationMobile.UI.ViewModel.Interfaces;
using OnlineApplicationMobile.UI.Views;
using OnlineApplicationMobile.UI.Views.Interfaces;
using Xamarin.Forms;

namespace OnlineApplicationMobile.UI.ViewModel
{
    public class MainViewModel : BaseViewModel, IViewModel
    {
        public MainViewModel(IView view, INavigation navigation) : base(navigation)
        {
            View = view;
            //PushModalPage(GetNavigatedPage(new LoginPage()));
        }
        public IView View { get; set; }
    }
}
