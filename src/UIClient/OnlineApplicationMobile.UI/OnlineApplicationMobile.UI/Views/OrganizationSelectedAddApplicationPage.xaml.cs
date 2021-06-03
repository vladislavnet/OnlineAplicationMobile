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
    public partial class OrganizationSelectedAddApplicationPage : ContentPage, IView
    {
        private readonly OrganizationSelectedAddApplicationViewModel organizationSelectedAddApplicationViewModel;
        public OrganizationSelectedAddApplicationPage()
        {
            InitializeComponent();
            organizationSelectedAddApplicationViewModel = new OrganizationSelectedAddApplicationViewModel(this, NavigationGlobalObject.Navigation);
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

        public async Task<bool> DisplayQuestionMessage(string title, string question, string accept, string cancel)
        {
            return await DisplayAlert(title, question, accept, cancel);
        }
    }
}