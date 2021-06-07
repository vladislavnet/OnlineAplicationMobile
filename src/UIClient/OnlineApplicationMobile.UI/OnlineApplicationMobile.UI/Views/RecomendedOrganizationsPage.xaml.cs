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
        }

        public IViewModel ViewModel
        {
            get => BindingContext as IViewModel;
            set => BindingContext = value;
        }
        public bool SetAutrozation { set => throw new NotImplementedException(); }

        public async void DisplayAlertMessage(string message)
        {
            await DisplayAlert(AlertMessageTemplate.AlertTemplate, message, AlertMessageTemplate.OkTemplate);
        }

        protected override bool OnBackButtonPressed()
        {
            NavigationGlobalObject.GoToUserApplicationsPage(null, null);
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