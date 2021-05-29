using OnlineApplicationMobile.HttpService.Interfaces;
using OnlineApplicationMobile.HttpService.Requests;
using OnlineApplicationMobile.UI.ModelView;
using OnlineApplicationMobile.UI.Views;
using OnlineApplicationMobile.UI.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace OnlineApplicationMobile.UI.ViewModel
{
    public class OrganizationSelectedAddApplicationViewModel : OrganizationsBaseViewModel
    {
        private string searchText;
        public OrganizationSelectedAddApplicationViewModel(IView view, INavigation navigation) : base(view, navigation) 
        {
            IsRefreshing = true;
        }

        public override void SetOrganizations()
        {
            var httpService = Startup.GetService<IHttpService>();

            var response = httpService.GetSearchGlobalOrganizations(new GetSearchGlobalOrganizationsRequest
            {
                Token = GetUserToken(),
                SearchText = !string.IsNullOrWhiteSpace(SearchText) ? SearchText : null
            });

            Action action = () =>
            {
                Organizations = response.Organizations.Select(x => MapOrganization(x)).ToList();
                Organizations.OrderBy(x => x.IsCheckNumberAccount);
            };

            Action actionError = () =>
            {
                DisplayMessage(response.Message);
            };

            ToNextAction(response.StatusCode, action, actionError);
        }

        /// <summary>
        /// Выбранная организация.
        /// </summary>
        public new OrganizationModelView SelectedOrganization
        {
            get => selectedOrganization;
            set
            {
                selectedOrganization = value;

                if (selectedOrganization != null)
                    PushModalPage(new AddApplicationPage(selectedOrganization));

                selectedOrganization = null;
                OnPropertyChanged(nameof(SelectedOrganization));
            }
        }

        /// <summary>
        /// Строка поиска
        /// </summary>
        public string SearchText
        {
            get => searchText;
            set
            {
                searchText = value;
                OnPropertyChanged(nameof(SearchText));
            }
        }

    }
}
