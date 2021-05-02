using OnlineApplicationMobile.UI.ViewModel.Interfaces;
using Xamarin.Forms;

namespace OnlineApplicationMobile.UI.Views.Interfaces
{
    public interface IView
    {
        IViewModel ViewModel { get; set; }

        void DisplayAlertMessage(string message);
    }
}
