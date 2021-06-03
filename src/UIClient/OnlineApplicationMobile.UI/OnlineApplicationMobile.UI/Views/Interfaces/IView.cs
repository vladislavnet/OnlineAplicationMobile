using OnlineApplicationMobile.UI.ViewModel.Interfaces;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OnlineApplicationMobile.UI.Views.Interfaces
{
    public interface IView
    {
        IViewModel ViewModel { get; set; }

        void DisplayAlertMessage(string message);

        Task<bool> DisplayQuestionMessage(string title, string question, string accept, string cancel);
    }
}
