using OnlineApplicationMobile.UI.ModelView;
using OnlineApplicationMobile.UI.ViewModel.Interfaces;
using OnlineApplicationMobile.UI.Views;
using OnlineApplicationMobile.UI.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace OnlineApplicationMobile.UI.ViewModel
{
    /// <summary>
    /// ViewModel для детальной информации по организации.
    /// </summary>
    public class OrganizationDetailViewModel : BaseViewModel, IViewModel
    {
        private OrganizationModelView organization;

        public OrganizationDetailViewModel(OrganizationModelView organization, IView view, INavigation navigation) : base(navigation)
        {
            View = view;
            View.ViewModel = this;
            this.Organization = organization;
        }

        /// <summary>
        /// Команда на переход страницы с добавлением заявки.
        /// </summary>
        public ICommand AddApplicationCommand
        {
            get => new Command(() =>
            {
                PushModalPage(new AddApplicationPage(organization));
            });
        }

        /// <summary>
        /// Организация.
        /// </summary>
        public OrganizationModelView Organization
        {
            get => organization;
            protected set
            {
                organization = value;
                OnPropertyChanged(nameof(Organization));
            }
        }
    }
}
