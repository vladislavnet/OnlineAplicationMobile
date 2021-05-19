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
    public partial class RecomendedOrganizationsPage : ContentPage, IView
    {
        private readonly RecomendedOrganizationsViewModel recomendedOrganizationsViewModel;
        public RecomendedOrganizationsPage()
        {
            InitializeComponent();
            recomendedOrganizationsViewModel = new RecomendedOrganizationsViewModel(this, NavigationGlobalObject.Navigation);
            recomendedOrganizationsViewModel.RefreshCommand.Execute(null);
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
    }
}