using OnlineApplicationMobile.HttpService.Interfaces;
using OnlineApplicationMobile.UI.ViewModel.Interfaces;
using OnlineApplicationMobile.UI.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace OnlineApplicationMobile.UI.ViewModel
{
    /// <summary>
    /// ViewModel рекомендованых организации.
    /// </summary>
    public class RecomendedOrganizationsViewModel : OrganizationsBaseViewModel
    {
        public RecomendedOrganizationsViewModel(IView view, INavigation navigation) : base(view, navigation) 
        {
        }
        
        /// <inheritdoc />
        public override void SetOrganizations()
        {
            var httpService = Startup.GetService<IHttpService>();

            var response = httpService.GetOrganizationsByUser(BuildRequestBase());

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
