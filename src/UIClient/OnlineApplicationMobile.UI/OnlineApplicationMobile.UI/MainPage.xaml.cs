using OnlineApplicationMobile.UI.Helpers;
using OnlineApplicationMobile.UI.ViewModel;
using OnlineApplicationMobile.UI.ViewModel.Interfaces;
using OnlineApplicationMobile.UI.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OnlineApplicationMobile.UI
{
    public partial class MainPage : ContentPage, IView
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public IViewModel ViewModel
        {
            get => BindingContext as IViewModel;
            set => BindingContext = value;
        }

        public async void DisplayAlertMessage(string message)
        {
            await DisplayAlert(AlertMessageTemplate.AlertTemplate, message, AlertMessageTemplate.OkTemplate);
        }

        public async void DisplayQuestionMessage(string title, string question, string accept, string cancel, Action action)
        {
            var result = await DisplayAlert(title, question, accept, cancel);
            if (result)
            {
                action.Invoke();
            }
        }
    }
}
