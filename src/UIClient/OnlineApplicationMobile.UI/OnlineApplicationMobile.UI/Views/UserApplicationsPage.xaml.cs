using OnlineApplicationMobile.UI.Helpers;
using OnlineApplicationMobile.UI.ViewModel;
using OnlineApplicationMobile.UI.ViewModel.Interfaces;
using OnlineApplicationMobile.UI.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OnlineApplicationMobile.UI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserApplicationsPage : ContentPage, IView
    {
        private  UserApplicationsViewModel userApplicationsViewModel;
        public UserApplicationsPage()
        {
            InitializeComponent();
            userApplicationsViewModel = new UserApplicationsViewModel(this, NavigationGlobalObject.Navigation);
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

        public void Refresh()
        {
            userApplicationsViewModel.RefreshCommand.Execute(null);
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
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