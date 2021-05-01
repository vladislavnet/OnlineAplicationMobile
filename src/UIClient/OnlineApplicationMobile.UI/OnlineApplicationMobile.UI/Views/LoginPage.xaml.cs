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
    public partial class LoginPage : ContentPage, IView
    {
        private readonly LoginViewModel loginViewModel;

        public LoginPage()
        {
            InitializeComponent();
            ViewModel = new LoginViewModel(this);
        }

        public IViewModel ViewModel 
        { 
            get => BindingContext as IViewModel; 
            set => BindingContext = value; 
        }

        public void DisplayAlertMessage(string message)
        {
            DisplayAlert(AlertMessageTemplate.AlertTemplate, message, AlertMessageTemplate.OkTemplate);
        }

        public void PopModalPage()
        {
            Navigation.PopModalAsync().RunSynchronously();
        }

        public void PopPage()
        {
            Navigation.PopAsync().RunSynchronously();
        }

        public void PushModalPage(Page page)
        {
            Navigation.PushModalAsync(page).RunSynchronously();
        }

        public void PushPage(Page page)
        {
            Navigation.PushAsync(page).RunSynchronously();
        }
    }
}