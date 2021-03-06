using OnlineApplicationMobile.HttpService.DTO;
using OnlineApplicationMobile.UI.ModelView;
using OnlineApplicationMobile.UI.ViewModel.Interfaces;
using OnlineApplicationMobile.UI.Views;
using OnlineApplicationMobile.UI.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace OnlineApplicationMobile.UI.ViewModel
{
    public abstract class OrganizationsBaseViewModel : BaseViewModel, IViewModel
    {
        protected List<OrganizationModelView> organizations;
        protected OrganizationModelView selectedOrganization;
        public OrganizationsBaseViewModel(IView view, INavigation navigation) : base(navigation)
        {
            View = view;
            View.ViewModel = this;
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
                    SetOrganizations();
                    IsRefreshing = false;
                });
            });
        }

        /// <summary>
        /// Список организаций.
        /// </summary>
        public List<OrganizationModelView> Organizations
        {
            get => organizations;
            set
            {
                organizations = value;
                OnPropertyChanged(nameof(Organizations));
            }
        }

        /// <summary>
        /// Выбранная организация.
        /// </summary>
        public OrganizationModelView SelectedOrganization
        {
            get => selectedOrganization;
            set
            {
                selectedOrganization = value;

                if (selectedOrganization != null)
                    PushModalPage(new OrganizationDetailPage(selectedOrganization));

                selectedOrganization = null;
                OnPropertyChanged(nameof(SelectedOrganization));
            }
        }

        /// <summary>
        /// Маппинг организации.
        /// </summary>
        public OrganizationModelView MapOrganization(OrganizationShortDto organization)
        {
            return new OrganizationModelView
            {
                Id = organization.Id,
                Name = organization.Name,
                Description = organization.Description,
                Email = organization.Email,
                Telephone = organization.Telephone,
                ServiceTypes = organization.ServiceTypes.Select(x => MapServiceType(x)).ToList(),
                IsCheckNumberAccount = organization.IsCheckNumberAccount,
            };
        }

        /// <summary>
        /// Заполняет список организаций.
        /// </summary>
        public abstract void SetOrganizations();
    }
}
