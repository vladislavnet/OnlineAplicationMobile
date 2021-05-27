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
    public partial class SearchOrganizationsPage : ContentPage, IView
    {
        private readonly SearchOrganizationsViewModel searchOrganizationsViewModel;
        public SearchOrganizationsPage()
        {
            InitializeComponent();
            searchOrganizationsViewModel = new SearchOrganizationsViewModel(this, NavigationGlobalObject.Navigation);
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

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}