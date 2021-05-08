using OnlineApplicationMobile.HttpService.DTO;
using OnlineApplicationMobile.HttpService.Interfaces;
using OnlineApplicationMobile.Infrastructure.Helpers;
using OnlineApplicationMobile.UI.ModelView;
using OnlineApplicationMobile.UI.ViewModel.Interfaces;
using OnlineApplicationMobile.UI.Views;
using OnlineApplicationMobile.UI.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace OnlineApplicationMobile.UI.ViewModel
{
    /// <summary>
    /// ViewModel для заявок пользователя
    /// </summary>
    public class UserApplicationsViewModel : BaseViewModel, IViewModel
    {
        private List<ApplicationShortModelView> applications;
        private ApplicationShortModelView selectedApplication;
        public UserApplicationsViewModel(IView view, INavigation navigation) : base(navigation)
        {
            View = view;
            View.ViewModel = this;
            initialize();
        }

        /// <summary>
        /// Список заявок.
        /// </summary>
        public List<ApplicationShortModelView> Applications
        {
            get => applications;
            set
            {
                applications = value;
                OnPropertyChanged(nameof(Applications));
            }
        }

        /// <summary>
        /// Выбранная заявка.
        /// </summary>
        public ApplicationShortModelView SelectedApplication
        {
            get => selectedApplication;
            set
            {
                selectedApplication = value;

                if (selectedApplication != null)
                    PushPage(new ApplicationDetailPage(selectedApplication.Id));
            }
        }

        private void initialize()
        {
            var httpService = Startup.GetService<IHttpService>();

            var response = httpService.GetApplicationsCurrentClientJKH(BuildRequestBase());

            Action actionError = () =>
            {
                DisplayMessage(response.Message);
            };

            Action action = () =>
            {
                Applications = mapApplications(response.Applications).ToList();
            };

            ToNextAction(response.StatusCode, action, actionError);
        }

        private IEnumerable<ApplicationShortModelView> mapApplications(IEnumerable<ApplicationShortDto> applications)
        {
            return applications.Select(x => new ApplicationShortModelView
            {
                Id = x.Id,
                OrganizationName = x?.Organization.Name ?? "-",
                MessageText = x.MessageText,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,
                Status = StatusApplicationHelper.GetStatusApplicationByInteger(x.StatusApplication),
            });
        }

    }
}
