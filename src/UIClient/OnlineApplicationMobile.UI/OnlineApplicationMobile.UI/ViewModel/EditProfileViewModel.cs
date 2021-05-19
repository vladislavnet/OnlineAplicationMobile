using OnlineApplicationMobile.Domain.Entities;
using OnlineApplicationMobile.Domain.Enums;
using OnlineApplicationMobile.HttpService.DTO;
using OnlineApplicationMobile.HttpService.DTO.Builders;
using OnlineApplicationMobile.HttpService.Interfaces;
using OnlineApplicationMobile.HttpService.Requests;
using OnlineApplicationMobile.Infrastructure.Globals;
using OnlineApplicationMobile.UI.ModelView;
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
        private DateTime? birthDate;
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

        private List<TypeAddressingObjectModelView> regionTypesAddressingObject;
        private List<TypeAddressingObjectModelView> districtTypesAddressingObject;
        private List<TypeAddressingObjectModelView> localityTypesAddressingObject;
        private List<TypeAddressingObjectModelView> streetTypesAddressingObject;

        private TypeAddressingObjectModelView selectedRegionTypeAddressingObject;
        private TypeAddressingObjectModelView selectedDistrictTypeAddressingObject;
        private TypeAddressingObjectModelView selectedLocalityTypeAddressingObject;
        private TypeAddressingObjectModelView selectedStreetTypeAddressingObject;

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
        private string middleNameValidateMessage;
        private string birthDateValidateMessage;
        private string telephoneValidateMessage;
        private string numberPersonalAccountValidateMessage;
        private string regionValidateMessage;
        private string districtValidateMessage;
        private string localityValidateMessage;
        private string streetValidateMessage;
        private string houseNumberValidateMessage;
        private string apartamentNumberValidateMessage;

        private bool firstNameValidateMessageIsVisible;
        private bool lastNameValidateMessageIsVisible;
        private bool middleNameValidateMessageIsVisible;
        private bool birthDateValidateMessageIsVisible;
        private bool telephoneValidateMessageIsVisible;
        private bool numberPersonalAccountValidateMessageIsVisible;
        private bool regionValidateMessageIsVisible;
        private bool districtValidateMessageIsVisible;
        private bool localityValidateMessageIsVisible;
        private bool streetValidateMessageIsVisible;
        private bool houseNumberValidateMessageIsVisible;
        private bool apartamentNumberValidateMessageIsVisible;

        public EditProfileViewModel(IView view, INavigation navigation) : base(navigation)
        {
            View = view;
            View.ViewModel = this;
            initialize();
            clearValidateMessage();
        }

        /// <summary>
        /// Команда редактирования пользователя.
        /// </summary>
        public ICommand EditUserCommand
        {
            get => new Command(() =>
            {
                clearValidateMessage();

                if (!validateDataEditUser())
                    return;

                var httpService = Startup.GetService<IHttpService>();

                var response = httpService.PutInfoCurrentClientJKH(new PutInfoCurrentClientJKHRequest
                {
                    Token = GetUserToken(),
                    FirstName = FirstName,
                    LastName = LastName,
                    MiddleName = !string.IsNullOrWhiteSpace(MiddleName) ? MiddleName : null,
                    BirthDate = BirthDate?.ToString("yyyy-MM-dd"),
                    Telephone = !string.IsNullOrWhiteSpace(Telephone) ? Telephone : null,
                    NumberPersonalAccount = NumberPersonalAccount,
                    Address = buildAddress()
                });

                Action action = () =>
                {
                    PopModalPage();
                };

                Action errorAction = () =>
                {
                    DisplayMessage(response.Message);
                };

                ToNextAction(response.StatusCode, action, errorAction);
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
        public DateTime? BirthDate
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
        /// Типы адресных объектов для региона.
        /// </summary>
        public List<TypeAddressingObjectModelView> RegionTypesAddressingObject
        {
            get => regionTypesAddressingObject;
            set
            {
                regionTypesAddressingObject = value;
                OnPropertyChanged(nameof(RegionTypesAddressingObject));
            }
        }

        /// <summary>
        /// Типы адресных объектов для района.
        /// </summary>
        public List<TypeAddressingObjectModelView> DistrictTypesAddressingObject
        {
            get => districtTypesAddressingObject;
            set
            {
                districtTypesAddressingObject = value;
                OnPropertyChanged(nameof(DistrictTypesAddressingObject));
            }
        }

        /// <summary>
        /// Типы адресных объектов для населённого пункта.
        /// </summary>
        public List<TypeAddressingObjectModelView> LocalityTypesAddressingObject
        {
            get => localityTypesAddressingObject;
            set
            {
                localityTypesAddressingObject = value;
                OnPropertyChanged(nameof(LocalityTypesAddressingObject));
            }
        }

        /// <summary>
        /// Типы адресных объектов для улицы.
        /// </summary>
        public List<TypeAddressingObjectModelView> StreetTypesAddressingObject
        {
            get => streetTypesAddressingObject;
            set
            {
                streetTypesAddressingObject = value;
                OnPropertyChanged(nameof(StreetTypesAddressingObject));
            }
        }

        /// <summary>
        /// Выбранный тип адресного объекта для региона.
        /// </summary>
        public TypeAddressingObjectModelView SelectedRegionTypeAddressingObject
        {
            get => selectedRegionTypeAddressingObject;
            set
            {
                selectedRegionTypeAddressingObject = value;
                OnPropertyChanged(nameof(SelectedRegionTypeAddressingObject));
            }
        }

        /// <summary>
        /// Выбранный тип адресного объекта для района.
        /// </summary>
        public TypeAddressingObjectModelView SelectedDistrictTypeAddressingObject
        {
            get => selectedDistrictTypeAddressingObject;
            set
            {
                selectedDistrictTypeAddressingObject = value;
                OnPropertyChanged(nameof(SelectedDistrictTypeAddressingObject));
            }
        }

        /// <summary>
        /// Выбранный тип адресного объекта для населённого пункта.
        /// </summary>
        public TypeAddressingObjectModelView SelectedLocalityTypeAddressingObject
        {
            get => selectedLocalityTypeAddressingObject;
            set
            {
                selectedLocalityTypeAddressingObject = value;
                OnPropertyChanged(nameof(SelectedLocalityTypeAddressingObject));
            }
        }

        /// <summary>
        /// Выбранный тип адресного объекта для улицы.
        /// </summary>
        public TypeAddressingObjectModelView SelectedStreetTypeAddressingObject
        {
            get => selectedStreetTypeAddressingObject;
            set
            {
                selectedStreetTypeAddressingObject = value;
                OnPropertyChanged(nameof(SelectedStreetTypeAddressingObject));
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
        /// Валидационное сообщение для отчества.
        /// </summary>
        public string MiddleNameValidateMessage
        {
            get => middleNameValidateMessage;
            set
            {
                middleNameValidateMessage = value;
                OnPropertyChanged(nameof(MiddleNameValidateMessage));
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

        /// <summary>
        /// Валидационное сообщение для Региона.
        /// </summary>
        public string RegionValidateMessage
        {
            get => regionValidateMessage;
            set
            {
                regionValidateMessage = value;
                OnPropertyChanged(nameof(RegionValidateMessage));
            }
        }

        /// <summary>
        /// Валидационное сообщение для Района.
        /// </summary>
        public string DistrictValidateMessage
        {
            get => districtValidateMessage;
            set
            {
                districtValidateMessage = value;
                OnPropertyChanged(nameof(DistrictValidateMessage));
            }
        }

        /// <summary>
        /// Валидационное сообщение для Населённого пункта.
        /// </summary>
        public string LocalityValidateMessage
        {
            get => localityValidateMessage;
            set
            {
                localityValidateMessage = value;
                OnPropertyChanged(nameof(LocalityValidateMessage));
            }
        }

        /// <summary>
        /// Валидационное сообщение для Улицы.
        /// </summary>
        public string StreetValidateMessage
        {
            get => streetValidateMessage;
            set
            {
                streetValidateMessage = value;
                OnPropertyChanged(nameof(StreetValidateMessage));
            }
        }

        /// <summary>
        /// Валидационное сообщение для Номера дома.
        /// </summary>
        public string HouseNumberValidateMessage
        {
            get => houseNumberValidateMessage;
            set
            {
                houseNumberValidateMessage = value;
                OnPropertyChanged(nameof(HouseNumberValidateMessage));
            }
        }

        /// <summary>
        /// Валидационное сообщение для Номера квартиры.
        /// </summary>
        public string ApartamentNumberValidateMessage
        {
            get => apartamentNumberValidateMessage;
            set
            {
                apartamentNumberValidateMessage = value;
                OnPropertyChanged(nameof(ApartamentNumberValidateMessage));
            }
        }

        /// <summary>
        /// Флаг видимости валидационного сообщения для имени.
        /// </summary>
        public bool FirstNameValidateMessageIsVisible
        {
            get => firstNameValidateMessageIsVisible;
            set
            {
                firstNameValidateMessageIsVisible = value;
                OnPropertyChanged(nameof(FirstNameValidateMessageIsVisible));
            }
        }

        /// <summary>
        /// Флаг видимости валидационного сообщения для фамилии.
        /// </summary>
        public bool LastNameValidateMessageIsVisible
        {
            get => lastNameValidateMessageIsVisible;
            set
            {
                lastNameValidateMessageIsVisible = value;
                OnPropertyChanged(nameof(LastNameValidateMessageIsVisible));
            }
        }

        /// <summary>
        /// Флаг видимости валидационного сообщения для отчества.
        /// </summary>
        public bool MiddleNameValidateMessageIsVisible
        {
            get => middleNameValidateMessageIsVisible;
            set
            {
                middleNameValidateMessageIsVisible = value;
                OnPropertyChanged(nameof(MiddleNameValidateMessageIsVisible));
            }
        }

        /// <summary>
        /// Флаг видимости валидационного сообщения для даты рождения.
        /// </summary>
        public bool BirthDateValidateMessageIsVisible
        {
            get => birthDateValidateMessageIsVisible;
            set
            {
                birthDateValidateMessageIsVisible = value;
                OnPropertyChanged(nameof(BirthDateValidateMessageIsVisible));
            }
        }

        /// <summary>
        /// Флаг видимости валидационного сообщения для телефона.
        /// </summary>
        public bool TelephoneValidateMessageIsVisible
        {
            get => telephoneValidateMessageIsVisible;
            set
            {
                telephoneValidateMessageIsVisible = value;
                OnPropertyChanged(nameof(TelephoneValidateMessageIsVisible));
            }
        }

        /// <summary>
        /// Флаг видимости валидационного сообщения для номера лицевого счёта.
        /// </summary>
        public bool NumberPersonalAccountValidateMessageIsVisible
        {
            get => numberPersonalAccountValidateMessageIsVisible;
            set
            {
                numberPersonalAccountValidateMessageIsVisible = value;
                OnPropertyChanged(nameof(NumberPersonalAccountValidateMessageIsVisible));
            }
        }

        /// <summary>
        /// Флаг видимости валидационного сообщения для региона.
        /// </summary>
        public bool RegionValidateMessageIsVisible
        {
            get => regionValidateMessageIsVisible;
            set
            {
                regionValidateMessageIsVisible = value;
                OnPropertyChanged(nameof(RegionValidateMessageIsVisible));
            }
        }

        /// <summary>
        /// Флаг видимости валидационного сообщения для района.
        /// </summary>
        public bool DistrictValidateMessageIsVisible
        {
            get => districtValidateMessageIsVisible;
            set
            {
                districtValidateMessageIsVisible = value;
                OnPropertyChanged(nameof(DistrictValidateMessageIsVisible));
            }
        }

        /// <summary>
        /// Флаг видимости валидационного сообщения для населённого пункта.
        /// </summary>
        public bool LocalityValidateMessageIsVisible
        {
            get => localityValidateMessageIsVisible;
            set
            {
                localityValidateMessageIsVisible = value;
                OnPropertyChanged(nameof(LocalityValidateMessageIsVisible));
            }
        }

        /// <summary>
        /// Флаг видимости валидационного сообщения для улицы.
        /// </summary>
        public bool StreetValidateMessageIsVisible
        {
            get => streetValidateMessageIsVisible;
            set
            {
                streetValidateMessageIsVisible = value;
                OnPropertyChanged(nameof(StreetValidateMessageIsVisible));
            }
        }

        /// <summary>
        /// Флаг видимости валидационного сообщения номера дома.
        /// </summary>
        public bool HouseNumberValidateMessageIsVisible
        {
            get => houseNumberValidateMessageIsVisible;
            set
            {
                houseNumberValidateMessageIsVisible = value;
                OnPropertyChanged(nameof(HouseNumberValidateMessageIsVisible));
            }
        }

        /// <summary>
        /// Флаг видимости валидационного сообщения номера квартиры.
        /// </summary>
        public bool ApartamentNumberValidateMessageIsVisible
        {
            get => apartamentNumberValidateMessageIsVisible;
            set
            {
                apartamentNumberValidateMessageIsVisible = value;
                OnPropertyChanged(nameof(ApartamentNumberValidateMessageIsVisible));
            }
        }

        /// <summary>
        /// Получение массива наименования адресных объектов.
        /// </summary>
        /// <param name="name">Наименование адресного объекта.</param>
        /// <param name="level">Уровень типа адресного объекта.</param>
        /// <returns>Массив наименований адресных объектов.</returns>
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

        /// <summary>
        /// Вывод сообщения пользователю.
        /// </summary>
        /// <param name="httpStatusCode">Код состояния HTTP.</param>
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

        /// <summary>
        /// Валидация данных перед редактировании.
        /// </summary>
        /// <returns>Флаг валидации.</returns>
        private bool validateDataEditUser()
        {
            bool flag = true;

            if (string.IsNullOrWhiteSpace(FirstName))
            {
                FirstNameValidateMessage = "Введите имя.";
                FirstNameValidateMessageIsVisible = true;
                flag = false;
            }

            if (string.IsNullOrWhiteSpace(LastName))
            {
                LastNameValidateMessage = "Введите фамилию.";
                LastNameValidateMessageIsVisible = true;
                flag = false;
            }

            if (string.IsNullOrWhiteSpace(NumberPersonalAccount))
            {
                NumberPersonalAccountValidateMessage = "Введите номер лицевого счёта.";
                NumberPersonalAccountValidateMessageIsVisible = true;
                flag = false;
            }

            if (string.IsNullOrWhiteSpace(Region) || SelectedRegionTypeAddressingObject == null)
            {
                RegionValidateMessage = "Введите регион и его тип.";
                RegionValidateMessageIsVisible = true;
                flag = false;
            }

            if (string.IsNullOrWhiteSpace(District) || SelectedDistrictTypeAddressingObject == null)
            {
                DistrictValidateMessage = "Введите район и его тип.";
                DistrictValidateMessageIsVisible = true;
                flag = false;
            }

            if (string.IsNullOrWhiteSpace(Locality) || SelectedLocalityTypeAddressingObject == null)
            {
                LocalityValidateMessage = "Введите населённый пункт и его тип.";
                LocalityValidateMessageIsVisible = true;
                flag = false;
            }

            if (string.IsNullOrWhiteSpace(Street) || SelectedStreetTypeAddressingObject == null)
            {
                StreetValidateMessage = "Введите улицу и его тип.";
                StreetValidateMessageIsVisible = true;
                flag = false;
            }

            return flag;
        }

        /// <summary>
        /// Очищение валидационных сообщении.
        /// </summary>
        private void clearValidateMessage()
        {
            FirstNameValidateMessage = string.Empty;
            LastNameValidateMessage = string.Empty;
            MiddleNameValidateMessage = string.Empty;
            BirthDateValidateMessage = string.Empty;
            TelephoneValidateMessage = string.Empty;
            NumberPersonalAccountValidateMessage = string.Empty;
            RegionValidateMessage = string.Empty;
            DistrictValidateMessage = string.Empty;
            LocalityValidateMessage = string.Empty;
            StreetValidateMessage = string.Empty;
            HouseNumberValidateMessage = string.Empty;
            ApartamentNumberValidateMessage = string.Empty;

            FirstNameValidateMessageIsVisible = false;
            LastNameValidateMessageIsVisible = false;
            MiddleNameValidateMessageIsVisible = false;
            BirthDateValidateMessageIsVisible = false;
            TelephoneValidateMessageIsVisible = false;
            NumberPersonalAccountValidateMessageIsVisible = false;
            RegionValidateMessageIsVisible = false;
            DistrictValidateMessageIsVisible = false;
            LocalityValidateMessageIsVisible = false;
            StreetValidateMessageIsVisible = false;
            HouseNumberValidateMessageIsVisible = false;
            ApartamentNumberValidateMessageIsVisible = false;
        }

        /// <summary>
        /// Инициализирует данные.
        /// </summary>
        private void initialize()
        {

            var httpService = Startup.GetService<IHttpService>();

            var requestRegion = buildTypesAddressingObjectRequest(LevelAddressingObjectEnum.Region);
            var requestDistrict = buildTypesAddressingObjectRequest(LevelAddressingObjectEnum.District);
            var requestLocality = buildTypesAddressingObjectRequest(LevelAddressingObjectEnum.Locality);
            var requestStreet = buildTypesAddressingObjectRequest(LevelAddressingObjectEnum.Street);

            var regionTypesAddressingObjectResponse = httpService.GetTypesAddressingObject(requestRegion).TypesAddressingObject;
            var districtTypesAddressingObjectResponse = httpService.GetTypesAddressingObject(requestDistrict).TypesAddressingObject;
            var localityTypesAddressingObjectResponse = httpService.GetTypesAddressingObject(requestLocality).TypesAddressingObject;
            var streetTypesAddressingObjectResponse = httpService.GetTypesAddressingObject(requestStreet).TypesAddressingObject;

            RegionTypesAddressingObject = mapTypeAddressingObjectModelView(regionTypesAddressingObjectResponse)?.ToList();
            DistrictTypesAddressingObject = mapTypeAddressingObjectModelView(districtTypesAddressingObjectResponse)?.ToList();
            LocalityTypesAddressingObject = mapTypeAddressingObjectModelView(localityTypesAddressingObjectResponse)?.ToList();
            StreetTypesAddressingObject = mapTypeAddressingObjectModelView(streetTypesAddressingObjectResponse)?.ToList();

            LastName = CurrentUser.LastName;
            FirstName = CurrentUser.FirstName;
            MiddleName = CurrentUser.MiddleName;
            BirthDate = CurrentUser.BirthDate;
            Telephone = CurrentUser.Telephone;
            NumberPersonalAccount = CurrentUser.NumberPersonalAccount;

            var currentUserTypeAddressingObjectRegion = CurrentUser.GetTypeAddressingObjectByAddress(LevelAddressingObjectEnum.Region);
            var currentUserTypeAddressingObjectDistrict = CurrentUser.GetTypeAddressingObjectByAddress(LevelAddressingObjectEnum.District);
            var currentUserTypeAddressingObjectLocality = CurrentUser.GetTypeAddressingObjectByAddress(LevelAddressingObjectEnum.Locality);
            var currentUserTypeAddressingObjectStreet = CurrentUser.GetTypeAddressingObjectByAddress(LevelAddressingObjectEnum.Street);

            var currentUserAddressingObjectRegion = CurrentUser.GetAddressingObjectByAddress(LevelAddressingObjectEnum.Region);
            var currentUserAddressingObjectDistrict = CurrentUser.GetAddressingObjectByAddress(LevelAddressingObjectEnum.District);
            var currentUserAddressingObjectLocality = CurrentUser.GetAddressingObjectByAddress(LevelAddressingObjectEnum.Locality);
            var currentUserAddressingObjectStreet = CurrentUser.GetAddressingObjectByAddress(LevelAddressingObjectEnum.Street);

            if (currentUserTypeAddressingObjectRegion != null)
                SelectedRegionTypeAddressingObject = RegionTypesAddressingObject.FirstOrDefault(x => currentUserTypeAddressingObjectRegion.Id == x.Id);

            if (currentUserTypeAddressingObjectDistrict != null)
                SelectedDistrictTypeAddressingObject = DistrictTypesAddressingObject.FirstOrDefault(x => currentUserTypeAddressingObjectDistrict.Id == x.Id);

            if (currentUserTypeAddressingObjectLocality != null)
                SelectedLocalityTypeAddressingObject = LocalityTypesAddressingObject.FirstOrDefault(x => currentUserTypeAddressingObjectLocality.Id == x.Id);

            if (currentUserTypeAddressingObjectStreet != null)
                SelectedStreetTypeAddressingObject = StreetTypesAddressingObject.FirstOrDefault(x => currentUserTypeAddressingObjectStreet.Id == x.Id);

            region = currentUserAddressingObjectRegion?.Name;
            district = currentUserAddressingObjectDistrict?.Name;
            locality = currentUserAddressingObjectLocality?.Name;
            street = currentUserAddressingObjectStreet?.Name;

            OnPropertyChanged(nameof(Region));
            OnPropertyChanged(nameof(District));
            OnPropertyChanged(nameof(Locality));
            OnPropertyChanged(nameof(Street));

            HouseNumber = CurrentUser.Address?.HouseNumber;
            ApartamentNumber = CurrentUser.Address?.NumberApartament;
        }

        /// <summary>
        /// Возвращает запрос на получение типов адресных объектов по уровню адресации.
        /// </summary>
        /// <param name="level">Уровень адресации.</param>
        /// <returns>Запрос на получение типов адресных объектов.</returns>
        private GetTypesAddressingObjectRequest buildTypesAddressingObjectRequest(LevelAddressingObjectEnum level)
        {
            return new GetTypesAddressingObjectRequest
            {
                Token = CurrentUser.Token,
                Level = (int)level
            };
        }

        /// <summary>
        /// Маппинг типов адресных объектов.
        /// </summary>
        /// <param name="typesAddressingObject">Типы адресных объектов.</param>
        private IEnumerable<TypeAddressingObjectModelView> mapTypeAddressingObjectModelView(TypeAddressingObjectDto[] typesAddressingObject)
        {
            return typesAddressingObject?.Select(x => new TypeAddressingObjectModelView
            {
                Id = x.Id,
                Name = x.Name,
                ShortName = x.ShortName
            });
        }

        /// <summary>
        /// Возвращает адрес для редактирования.
        /// </summary>
        /// <returns>Адрес.</returns>
        private AddressDto buildAddress()
        {
            return new AddressDtoBuilder().BuildAddUserAddress(new AddressDtoBuilder.AddUserAddress
            {
                Region = Region,
                TypeRegion = buildTypeAddressingObject(SelectedRegionTypeAddressingObject),
                District = District,
                TypeDistrict = buildTypeAddressingObject(SelectedDistrictTypeAddressingObject),
                Locality = Locality,
                TypeLocality = buildTypeAddressingObject(SelectedLocalityTypeAddressingObject),
                Street = Street,
                TypeStreet = buildTypeAddressingObject(SelectedStreetTypeAddressingObject),
                NumberHouse = HouseNumber,
                ApartamentNumber = ApartamentNumber
            });
        }

        /// <summary>
        /// Возвращает тип адресного объекта для редактирования.
        /// </summary>
        /// <param name="typeAddressingObject"></param>
        /// <returns></returns>
        private TypeAddressingObjectDto buildTypeAddressingObject(TypeAddressingObjectModelView typeAddressingObject)
        {
            return new TypeAddressingObjectDto 
            { 
                Id = typeAddressingObject.Id,
                Name = typeAddressingObject.Name,
                ShortName = typeAddressingObject.ShortName
            };

        }
    }
}
