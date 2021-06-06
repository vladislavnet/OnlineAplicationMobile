using OnlineApplicationMobile.Domain.Entities;
using OnlineApplicationMobile.HttpService.Interfaces;
using OnlineApplicationMobile.HttpService.Requests;
using OnlineApplicationMobile.Infrastructure.Builders;
using OnlineApplicationMobile.Infrastructure.Globals;
using OnlineApplicationMobile.Infrastructure.SqlLiteData.Repository.Interfaces;
using OnlineApplicationMobile.UI.ViewModel.Interfaces;
using OnlineApplicationMobile.UI.Views;
using OnlineApplicationMobile.UI.Views.Interfaces;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace OnlineApplicationMobile.UI.ViewModel
{
    /// <summary>
    /// ViewModel Профиля пользователя.
    /// </summary>
    public class ProfileViewModel : BaseViewModel, IViewModel
    {
        private string email;
        private string firstName;
        private string lastName;
        private string middleName;
        private string birthDate;
        private string telephone;
        private string addressString;

        public ProfileViewModel(IView view, INavigation navigation) : base(navigation)
        {
            View = view;
            View.ViewModel = this;
            IsRefreshing = true;
        }

        public ICommand EditProfileCommand
        {
            get => new Command(() =>
            {
                PushModalPage(new EditProfilePage());
            });
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
                    Initialize();
                    IsRefreshing = false;
                });
            });
        }

        /// <summary>
        /// Email.
        /// </summary>
        public string Email
        {
            get => email;
            protected set
            {
                email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        /// <summary>
        /// Имя.
        /// </summary>
        public string FirstName
        {
            get => firstName;
            protected set
            {
                firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string LastName
        {
            get => lastName;
            protected set
            {
                lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        /// <summary>
        /// Отчество.
        /// </summary>
        public string MiddleName
        {
            get => middleName;
            protected set
            {
                middleName = value;
                OnPropertyChanged(nameof(MiddleName));
            }
        }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public string BirthDate
        {
            get => birthDate;
            protected set
            {
                birthDate = value;
                OnPropertyChanged(nameof(BirthDate));
            }
        }
        
        /// <summary>
        /// Телефон.
        /// </summary>
        public string Telephone
        {
            get => telephone;
            protected set
            {
                telephone = value;
                OnPropertyChanged(nameof(Telephone));
            }
        }

        /// <summary>
        /// Строка адреса.
        /// </summary>
        public string AddressString
        {
            get => addressString;
            protected set
            {
                addressString = value;
                OnPropertyChanged(nameof(AddressString));
            }
        }


        public void Initialize()
        {
            var httpService = Startup.GetService<IHttpService>();

            var response = httpService.GetInfoCurrentClientJKH(BuildRequestBase());          

            Action action = () =>
            {
                CurrentUser.SetCurrentUser(new ClientJKH
                {
                    User = new UserDomainBuilder().Build(response.User),
                });

                setField();
            };

            ToNextAction(response.StatusCode, action, () => { });
        }

        private void setField()
        {
            Email = CurrentUser.Email;
            FirstName = CurrentUser.FirstName;
            LastName = CurrentUser.LastName;
            MiddleName = CurrentUser.MiddleName;
            BirthDate = CurrentUser.BirthDate.HasValue ? CurrentUser.BirthDate.Value.ToString("d") : string.Empty;
            Telephone = CurrentUser.Telephone;
            AddressString = CurrentUser.GetAddressShortToString();
        }
    }
}
