using OnlineApplicationMobile.HttpService.Interfaces;
using OnlineApplicationMobile.HttpService.Requests;
using OnlineApplicationMobile.UI.ViewModel.Interfaces;
using OnlineApplicationMobile.UI.Views;
using OnlineApplicationMobile.UI.Views.Interfaces;
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
        private string numberPersonalAccount;
        private string addressString;

        public ProfileViewModel(IView view, INavigation navigation) : base(navigation)
        {
            View = view;
            View.ViewModel = this;
            Initialize();
        }

        public ICommand EditProfileCommand
        {
            get => new Command(() =>
            {
                PushPage(new EditProfilePage());
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
        /// Номер лицевого счёта.
        /// </summary>
        public string NumberPersonalAccount
        {
            get => numberPersonalAccount;
            protected set
            {
                numberPersonalAccount = value;
                OnPropertyChanged(nameof(NumberPersonalAccount));
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

            var response = httpService.GetInfoCurrentClientJKH(new RequestBase());

            ToNextAction(response.StatusCode, () => { }, () => { });
        }
    }
}
