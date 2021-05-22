using OnlineApplicationMobile.UI.Helpers;
using OnlineApplicationMobile.UI.ModelView;
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
    public partial class EditProfilePage : ContentPage, IView
    {
       
        private readonly EditProfileViewModel editProfileViewModel;
        public EditProfilePage()
        {
            InitializeComponent();
            editProfileViewModel = new EditProfileViewModel(this, NavigationGlobalObject.Navigation);
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


        private void regionEntry_Unfocused(object sender, FocusEventArgs e)
        {
            editProfileViewModel.IsVisibleSearchRegionCollection = false;
        }

        private void regionEntry_Focused(object sender, FocusEventArgs e)
        {
            if(editProfileViewModel.SearchRegionCollection != null && editProfileViewModel.SearchRegionCollection.Any())
            {
                editProfileViewModel.IsVisibleSearchRegionCollection = true;
            }
            else
            {
                editProfileViewModel.IsVisibleSearchRegionCollection = false;
            }
        }

        private void districtEntry_Unfocused(object sender, FocusEventArgs e)
        {
            editProfileViewModel.IsVisibleSearchDistrictCollection = false;
        }

        private void districtEntry_Focused(object sender, FocusEventArgs e)
        {
            if (editProfileViewModel.SearchDistrictCollection != null && editProfileViewModel.SearchDistrictCollection.Any())
            {
                editProfileViewModel.IsVisibleSearchDistrictCollection = true;
            }
            else
            {
                editProfileViewModel.IsVisibleSearchDistrictCollection = false;
            }
        }

        private void localityEntry_Unfocused(object sender, FocusEventArgs e)
        {
            editProfileViewModel.IsVisibleSearchLocalityCollection = false;
        }

        private void localityEntry_Focused(object sender, FocusEventArgs e)
        {
            if (editProfileViewModel.SearchLocalityCollection != null && editProfileViewModel.SearchLocalityCollection.Any())
            {
                editProfileViewModel.IsVisibleSearchLocalityCollection = true;
            }
            else
            {
                editProfileViewModel.IsVisibleSearchLocalityCollection = false;
            }
        }

        private void streetEntry_Unfocused(object sender, FocusEventArgs e)
        {
            editProfileViewModel.IsVisibleSearchStreetCollection = false;
        }

        private void streetEntry_Focused(object sender, FocusEventArgs e)
        {
            if (editProfileViewModel.SearchStreetCollection != null && editProfileViewModel.SearchStreetCollection.Any())
            {
                editProfileViewModel.IsVisibleSearchStreetCollection = true;
            }
            else
            {
                editProfileViewModel.IsVisibleSearchStreetCollection = false;
            }
        }

        private void regionEntry_TextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
        }

    }
}