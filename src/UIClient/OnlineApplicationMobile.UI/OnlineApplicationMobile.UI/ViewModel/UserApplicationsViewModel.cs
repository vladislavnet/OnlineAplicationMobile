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
using System.Net;
using System.Threading.Tasks;
using System.Windows.Input;
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
            RefreshCommand.Execute(null);
        }

        /// <summary>
        /// Команда для Обновления раздела.
        /// </summary>
        public ICommand RefreshCommand
        {
            get => new Command(() =>
            {
                Task.Run(() => 
                {
                    IsRefreshing = true;
                    initialize();
                    IsRefreshing = false;
                });          
            });
        }

        public ICommand AddApplication
        {
            get => new Command(() =>
            {
                PushModalPage(new OrganizationSelectedAddApplicationPage());
            });
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
                    PushModalPage(new ApplicationDetailPage(selectedApplication.Id));
            }
        }

        private void initialize()
        {
            var httpService = Startup.GetService<IHttpService>();

            var response = httpService.GetApplicationsCurrentClientJKH(BuildRequestBase());

            //if ((response.StatusCode == HttpStatusCode.Forbidden || response.StatusCode == HttpStatusCode.Unauthorized) && !NavigationGlobalObject.IsLoginStart && NavigationGlobalObject.IsStart)
            //{
            //    NavigationGlobalObject.IsLoginStart = true;
            //}

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
            var mapApplications = applications.Select(x => new ApplicationShortModelView
            {
                Id = x.Id,
                OrganizationName = x?.Organization.Name ?? "-",
                MessageText = x.MessageText,
                CreatedAt = x.CreatedAt,
                Status = StatusApplicationHelper.GetStatusApplicationByInteger(x.StatusApplication),
                HistoryApplication = HistoryApplicationModelView.mapHistoryApplication(x.HistoryApplication)
            }).ToList();

            foreach (var application in mapApplications)
            {
                if (!string.IsNullOrWhiteSpace(application.MessageText))
                {
                    if (application.MessageText.Length > 121)
                    {
                        application.MessageText = application.MessageText.Substring(0, 120) + "...";
                    }
                }
            }

            return mapApplications;
        }

    }
}
