using OnlineApplicationMobile.Domain.Entities;
using OnlineApplicationMobile.Domain.Enums;
using OnlineApplicationMobile.HttpService.Interfaces;
using OnlineApplicationMobile.HttpService.Requests;
using OnlineApplicationMobile.Infrastructure.Globals;
using OnlineApplicationMobile.UI.ViewModel.Interfaces;
using OnlineApplicationMobile.UI.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace OnlineApplicationMobile.UI.ViewModel
{
    /// <summary>
    /// ViewModel Редактирования информации пользователя.
    /// </summary>
    public class EditProfileViewModel : BaseViewModel, IViewModel
    {
        private string firstName;
        private string lastName;
        private string middleName;
        private DateTime birthDate;
        private string telephone;
        private string numberPersonalAccount;
        private string region;
        private string district;
        private string locality;
        private string street;
        private string houseNumber;
        private string apartamentNumber;

        private List<string> searchRegionCollection;
        private List<string> searchDistrictCollection;
        private List<string> searchLocalityCollection;
        private List<string> searchStreetCollection;

        private string selectedRegionCollection;
        private string selectedDistrictCollection;
        private string selectedLocalityCollection;
        private string selectedStreetCollection;

        private bool isVisibleSearchRegionCollection;
        private bool isVisibleSearchDistrictCollection;
        private bool isVisibleSearchLocalityCollection;
        private bool isVisibleSearchStreetCollection;

        private string firstNameValidateMessage;
        private string lastNameValidateMessage;
        private string birthDateValidateMessage;
        private string telephoneValidateMessage;
        private string numberPersonalAccountValidateMessage;
        private string regionValidateMessage;
        private string districtValidateMessage;
        private string localityValidateMessage;
        private string streetValidateMessage;
        private string houseNumberValidateMessage;
        private string apartamentNumberValidateMessage;

        public EditProfileViewModel(IView view, INavigation navigation) : base(navigation)
        {
            View = view;
            View.ViewModel = this;
        }

        /// <summary>
        /// Команда редактирования пользователя.
        /// </summary>
        public ICommand EditUserCommand
        {
            get => new Command(() =>
            {
                
            });
        }

        /// <summary>
        /// Имя.
        /// </summary>
        public string FirstName
        {
            get => firstName;
            set
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
            set
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
            set
            {
                middleName = value;
                OnPropertyChanged(nameof(MiddleName));
            }
        }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime BirthDate
        {
            get => birthDate;
            set
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
            set
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
            set
            {
                numberPersonalAccount = value;
                OnPropertyChanged(nameof(NumberPersonalAccount));
            }
        }

        /// <summary>
        /// Регион.
        /// </summary>
        public string Region
        {
            get => region;
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value != region)
                    SearchRegionCollection = GetSearchCollection(value, LevelAddressingObjectEnum.Region);

                region = value;
                OnPropertyChanged(nameof(Region));
            }
        }

        /// <summary>
        /// Район.
        /// </summary>
        public string District
        {
            get => district;
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value != district)
                    SearchDistrictCollection = GetSearchCollection(value, LevelAddressingObjectEnum.District);

                district = value;
                OnPropertyChanged(nameof(District));
            }
        }

        /// <summary>
        /// Населённый пункт.
        /// </summary>
        public string Locality
        {
            get => locality;
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value != locality)
                    SearchLocalityCollection = GetSearchCollection(value, LevelAddressingObjectEnum.Locality);

                locality = value;
                OnPropertyChanged(nameof(Locality));
            }
        }

        /// <summary>
        /// Улица.
        /// </summary>
        public string Street
        {
            get => street;
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value != street)
                    SearchStreetCollection = GetSearchCollection(value, LevelAddressingObjectEnum.Street);

                street = value;
                OnPropertyChanged(nameof(Street));
            }
        }

        /// <summary>
        /// Номер дома.
        /// </summary>
        public string HouseNumber
        {
            get => houseNumber;
            set
            {
                houseNumber = value;
                OnPropertyChanged(nameof(HouseNumber));
            }
        }

        /// <summary>
        /// Номер квартиры.
        /// </summary>
        public string ApartamentNumber
        {
            get => apartamentNumber;
            set
            {
                apartamentNumber = value;
                OnPropertyChanged(nameof(ApartamentNumber));
            }
        }

        /// <summary>
        /// Список регионов для автозаполнения.
        /// </summary>
        public List<string> SearchRegionCollection
        {
            get => searchRegionCollection;
            set
            {
                searchRegionCollection = value;

                if (searchRegionCollection != null && searchRegionCollection.Any())
                    IsVisibleSearchRegionCollection = true;

                OnPropertyChanged(nameof(SearchRegionCollection));
            }
        }

        /// <summary>
        /// Список районов для автозаполнения.
        /// </summary>
        public List<string> SearchDistrictCollection
        {
            get => searchDistrictCollection;
            set
            {
                searchDistrictCollection = value;

                if (searchDistrictCollection != null && searchDistrictCollection.Any())
                    IsVisibleSearchDistrictCollection = true;

                searchDistrictCollection = value;
                OnPropertyChanged(nameof(SearchDistrictCollection));
            }
        }

        /// <summary>
        /// Список населённых пунктов для автозаполнения.    
        /// </summary>
        public List<string> SearchLocalityCollection
        {
            get => searchLocalityCollection;
            set
            {
                searchLocalityCollection = value;

                if (searchLocalityCollection != null && searchLocalityCollection.Any())
                    IsVisibleSearchLocalityCollection = true;

                searchLocalityCollection = value;
                OnPropertyChanged(nameof(SearchLocalityCollection));
            }
        }

        /// <summary>
        /// Список улиц для автозаполнения.
        /// </summary>
        public List<string> SearchStreetCollection
        {
            get => searchStreetCollection;
            set
            {
                searchStreetCollection = value;

                if (searchStreetCollection != null && searchStreetCollection.Any())
                    IsVisibleSearchStreetCollection = true;

                searchStreetCollection = value;
                OnPropertyChanged(nameof(SearchStreetCollection));
            }
        }

        /// <summary>
        /// Выбранный из списка поиска регион.
        /// </summary>
        public string SelectedRegionCollection
        {
            get => selectedRegionCollection;
            set
            {
                Region = value;
                IsVisibleSearchRegionCollection = false;
                SearchRegionCollection = new List<string>();
                OnPropertyChanged(nameof(SelectedRegionCollection));
            }
        }

        /// <summary>
        /// Выбранный из списка поиска район.
        /// </summary>
        public string SelectedDistrictCollection
        {
            get => selectedDistrictCollection;
            set
            {
                District = value;
                IsVisibleSearchDistrictCollection = false;
                SearchDistrictCollection = new List<string>();
                OnPropertyChanged(nameof(SelectedDistrictCollection));
            }
        }

        /// <summary>
        /// Выбранный из списка поиска населённый пункт.
        /// </summary>
        public string SelectedLocalityCollection
        {
            get => selectedLocalityCollection;
            set
            {

                Locality = value;
                IsVisibleSearchLocalityCollection = false;
                SearchLocalityCollection = new List<string>();
                OnPropertyChanged(nameof(SelectedLocalityCollection));
            }
        }

        /// <summary>
        /// Выбранный из списка поиска улицы.
        /// </summary>
        public string SelectedStreetCollection
        {
            get => selectedStreetCollection;
            set
            {
                Street = value;
                IsVisibleSearchStreetCollection = false;
                SearchStreetCollection = new List<string>();
                OnPropertyChanged(nameof(SelectedStreetCollection));
            }
        }

        /// <summary>
        /// Флаг видимости списка поиска региона.
        /// </summary>
        public bool IsVisibleSearchRegionCollection
        {
            get => isVisibleSearchRegionCollection;
            set
            {
                isVisibleSearchRegionCollection = value;
                OnPropertyChanged(nameof(IsVisibleSearchRegionCollection));
            }
        }

        /// <summary>
        /// Флаг видимости списка поиска район.
        /// </summary>
        public bool IsVisibleSearchDistrictCollection
        {
            get => isVisibleSearchDistrictCollection;
            set
            {
                isVisibleSearchDistrictCollection = value;
                OnPropertyChanged(nameof(IsVisibleSearchDistrictCollection));
            }
        }

        /// <summary>
        /// Флаг видимости списка поиска населённый пункт.
        /// </summary>
        public bool IsVisibleSearchLocalityCollection
        {
            get => isVisibleSearchLocalityCollection;
            set
            {
                isVisibleSearchLocalityCollection = value;
                OnPropertyChanged(nameof(IsVisibleSearchLocalityCollection));
            }
        }

        /// <summary>
        /// Флаг видимости списка поиска улицы.
        /// </summary>
        public bool IsVisibleSearchStreetCollection
        {
            get => isVisibleSearchStreetCollection;
            set
            {
                isVisibleSearchStreetCollection = value;
                OnPropertyChanged(nameof(IsVisibleSearchStreetCollection));
            }
        }

        /// <summary>
        /// Валидационное сообщение для имени.
        /// </summary>
        public string FirstNameValidateMessage
        {
            get => firstNameValidateMessage;
            set
            {
                firstNameValidateMessage = value;
                OnPropertyChanged(nameof(FirstNameValidateMessage));
            }
        }

        /// <summary>
        /// Валидационное сообщение для фамилии.
        /// </summary>
        public string LastNameValidateMessage
        {
            get => lastNameValidateMessage;
            set
            {
                lastNameValidateMessage = value;
                OnPropertyChanged(nameof(LastNameValidateMessage));
            }
        }

        /// <summary>
        /// Валидационное сообщение для дня рождении.
        /// </summary>
        public string BirthDateValidateMessage
        {
            get => birthDateValidateMessage;
            set
            {
                birthDateValidateMessage = value;
                OnPropertyChanged(nameof(BirthDateValidateMessage));
            }
        }

        /// <summary>
        /// Валидационное сообщение для телефона.
        /// </summary>
        public string TelephoneValidateMessage
        {
            get => telephoneValidateMessage;
            set
            {
                telephoneValidateMessage = value;
                OnPropertyChanged(nameof(TelephoneValidateMessage));
            }
        }

        /// <summary>
        /// Валидационное сообщение для лицевого счёта.
        /// </summary>
        public string NumberPersonalAccountValidateMessage
        {
            get => numberPersonalAccountValidateMessage;
            set
            {
                numberPersonalAccountValidateMessage = value;
                OnPropertyChanged(nameof(NumberPersonalAccountValidateMessage));
            }
        }

        private List<string> GetSearchCollection(string name, LevelAddressingObjectEnum level)
        {
            var httpService = Startup.GetService<IHttpService>();

            var response = httpService.GetSearchAddressingObjects(new SearchAddressingObjectsRequest
            {
                Token = CurrentUser.Token,
                Name = name,
                Level = (int)level
            });

            displayMessageGetSearchCollection(response.StatusCode);

            return response.addressingObjectsShort != null ? response.addressingObjectsShort.Select(x => x.Name).ToList() : new List<string>();
        }

        private void displayMessageGetSearchCollection(HttpStatusCode httpStatusCode)
        {
            switch (httpStatusCode)
            {
                case HttpStatusCode.NotFound:
                    View.DisplayAlertMessage("Ресурс не был найден.");
                    break;
                case HttpStatusCode.InternalServerError:
                    View.DisplayAlertMessage($"Произошла ошибка на сервере.");
                    break;
                case HttpStatusCode.Forbidden:
                    View.DisplayAlertMessage($"У вас нет прав на доступ к ресурсу.");
                    break;
            }
        }
    }
}
