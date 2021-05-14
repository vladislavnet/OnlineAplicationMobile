using OnlineApplicationMobile.HttpService.Interfaces;
using OnlineApplicationMobile.HttpService.Requests;
using OnlineApplicationMobile.UI.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace OnlineApplicationMobile.UI.ViewModel
{
    public class SearchOrganizationsViewModel : OrganizationsBaseViewModel
    {
        private string searchText;
        public SearchOrganizationsViewModel(IView view, INavigation navigation) : base(view, navigation) { }

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

        /// <inheritdoc />
        public override void SetOrganizations()
        {
            var httpService = Startup.GetService<IHttpService>();

            var response = httpService.GetSearchGlobalOrganizations(new GetSearchGlobalOrganizationsRequest
            {
                Token = GetUserToken(),
                SearchText = !string.IsNullOrWhiteSpace(SearchText) ? SearchText : null
            }).Result;

            Action action = () =>
            {
                Organizations = response.Organizations.Select(x => MapOrganization(x)).ToList();
            };

            Action actionError = () =>
            {
                DisplayMessage(response.Message);
            };

            ToNextAction(response.StatusCode, action, actionError);
        }
    }
}
