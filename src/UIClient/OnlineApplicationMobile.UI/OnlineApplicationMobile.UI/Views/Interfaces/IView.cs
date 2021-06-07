using OnlineApplicationMobile.UI.ViewModel.Interfaces;
using System;

namespace OnlineApplicationMobile.UI.Views.Interfaces
{
    public interface IView
    {
        IViewModel ViewModel { get; set; }

        void DisplayAlertMessage(string message);

        void DisplayQuestionMessage(string title, string question, string accept, string cancel, Action action);
    }
}
