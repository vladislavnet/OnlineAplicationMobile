using OnlineApplicationMobile.HttpService.DTO;
using OnlineApplicationMobile.HttpService.Interfaces;
using OnlineApplicationMobile.HttpService.Requests;
using OnlineApplicationMobile.Infrastructure.Globals;
using OnlineApplicationMobile.UI.ModelView;
using OnlineApplicationMobile.UI.ViewModel.Interfaces;
using OnlineApplicationMobile.UI.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace OnlineApplicationMobile.UI.ViewModel
{
    /// <summary>
    /// ViewModel для добавления заявки.
    /// </summary>
    public class AddApplicationViewModel : BaseViewModel, IViewModel
    {
        private OrganizationModelView organization;

        private string messageText;
        private string numberAccount;
        private string firstNamePayer;
        private string lastNamePayer;
        private string middleNamePayer;
        private List<ServiceTypeSelectionModelView> serviceTypes;
        private ServiceTypeSelectionModelView selectedServiceType;

        private string messageTextValidateMessage;
        private string numberAccountValidateMessage;
        private string firstNamePayerValidateMessage;
        private string lastNamePayerValidateMessage;
        private string middleNamePayerValidateMessage;

        private bool messageTextValidateMessageIsVisible;
        private bool numberAccountValidateMessageIsVisible;
        private bool firstNamePayerValidateMessageIsVisible;
        private bool lastNamePayerValidateMessageIsVisible;
        private bool middleNamePayerValidateMessageIsVisible;

        public AddApplicationViewModel(OrganizationModelView organization, IView view, INavigation navigation) : base(navigation)
        {
            View = view;
            View.ViewModel = this;
            this.organization = organization;
            initialization();
        }

        /// <summary>
        /// Команда для заполнения полей из профиля.
        /// </summary>
        public ICommand SetFieldByProfileCommand
        {
            get => new Command(() =>
            {
                NumberAccount = CurrentUser.NumberPersonalAccount;
                FirstNamePayer = CurrentUser.FirstName;
                LastNamePayer = CurrentUser.LastName;
                MiddleNamePayer = CurrentUser.MiddleName;
            });
        }

        /// <summary>
        /// Команда для добавления заявки.
        /// </summary>
        public ICommand AddApplicationCommand
        {
            get => new Command(() =>
            {
                if (!validateField())
                    return;

                var httpService = Startup.GetService<IHttpService>();

                var selectedServiceTypes = ServiceTypes.Where(x => x.IsSelect);

                var response = httpService.PostApplication(new PostApplicationRequest
                {
                    Token = GetUserToken(),
                    MessageText = MessageText,
                    NumberAccount = NumberAccount,
                    FirstNamePayer = FirstNamePayer,
                    LastNamePayer = LastNamePayer,
                    MiddleNamePayer = MiddleNamePayer,
                    OrganizationId = organization.Id,
                    ServiseTypes = selectedServiceTypes.Count() > 0 ? selectedServiceTypes.Select(x => mapServiceTypeDto(x)).Select(x => x.Id).ToArray() : null,
                });

                Action action = () =>
                {
                    DisplayMessage("Заявка успешно отправлена");
                    PopPage();
                };

                Action actionError = () =>
                {
                    DisplayMessage(response.Message);
                };

                ToNextAction(response.StatusCode, action, actionError);
            });
        }

        /// <summary>
        /// Текст обращения.
        /// </summary>
        public string MessageText
        {
            get => messageText;
            set
            {
                messageText = value;
                OnPropertyChanged(nameof(MessageText));
            }
        }

        /// <summary>
        /// Номер счёта.
        /// </summary>
        public string NumberAccount
        {
            get => numberAccount;
            set
            {
                numberAccount = value;
                OnPropertyChanged(nameof(NumberAccount));
            }
        }

        /// <summary>
        /// Имя ответсвенного плательщика.
        /// </summary>
        public string FirstNamePayer
        {
            get => firstNamePayer;
            set
            {
                firstNamePayer = value;
                OnPropertyChanged(nameof(FirstNamePayer));
            }
        }

        /// <summary>
        /// Фамилия ответсвенного плательщика.
        /// </summary>
        public string LastNamePayer
        {
            get => lastNamePayer;
            set
            {
                lastNamePayer = value;
                OnPropertyChanged(nameof(LastNamePayer));
            }
        }

        /// <summary>
        /// Отчетво ответсвенного плательщика.
        /// </summary>
        public string MiddleNamePayer
        {
            get => middleNamePayer;
            set
            {
                middleNamePayer = value;
                OnPropertyChanged(nameof(MiddleNamePayer));
            }
        }

        /// <summary>
        /// Типы сервисов.
        /// </summary>
        public List<ServiceTypeSelectionModelView> ServiceTypes
        {
            get => serviceTypes;
            set
            {
                serviceTypes = value;
                OnPropertyChanged(nameof(ServiceTypes));
            }
        }

        /// <summary>
        /// Выбранный тип сервисов.
        /// </summary>
        public ServiceTypeSelectionModelView SelectedServiceType
        {
            get => selectedServiceType;
            set
            {
                if (value != null)
                {
                    value.IsSelect = !value.IsSelect;
                }
            }
        }

        /// <summary>
        /// Валидационное сообщение для текста обращения.
        /// </summary>
        public string MessageTextValidateMessage
        {
            get => messageTextValidateMessage;
            set
            {
                messageTextValidateMessage = value;
                OnPropertyChanged(nameof(MessageTextValidateMessage));
            }
        }

        /// <summary>
        /// Валидационное сообщение для номера счёта.
        /// </summary>
        public string NumberAccountValidateMessage
        {
            get => numberAccountValidateMessage;
            set
            {
                numberAccountValidateMessage = value;
                OnPropertyChanged(nameof(NumberAccountValidateMessage));
            }
        }

        /// <summary>
        /// Валидационное сообщение для имени ответсвенного плательщика.
        /// </summary>
        public string FirstNamePayerValidateMessage
        {
            get => firstNamePayerValidateMessage;
            set
            {
                firstNamePayerValidateMessage = value;
                OnPropertyChanged(nameof(FirstNamePayerValidateMessage));
            }
        }

        /// <summary>
        /// Валидационное сообщение для фамилии ответсвенного плательщика.
        /// </summary>
        public string LastNamePayerValidateMessage
        {
            get => lastNamePayerValidateMessage;
            set
            {
                lastNamePayerValidateMessage = value;
                OnPropertyChanged(nameof(LastNamePayerValidateMessage));
            }
        }

        /// <summary>
        /// Валидационное сообщение для отчетва ответсвенного плательщика.
        /// </summary>
        public string MiddleNamePayerValidateMessage
        {
            get => middleNamePayerValidateMessage;
            set
            {
                middleNamePayerValidateMessage = value;
                OnPropertyChanged(nameof(MiddleNamePayerValidateMessage));
            }
        }


        /// <summary>
        /// Флаг для валидационного сообщения для текста обращения.
        /// </summary>
        public bool MessageTextValidateMessageIsVisible
        {
            get => messageTextValidateMessageIsVisible;
            set
            {
                messageTextValidateMessageIsVisible = value;
                OnPropertyChanged(nameof(MessageTextValidateMessageIsVisible));
            }
        }

        /// <summary>
        /// Флаг для валидационного сообщения для номера счёта.
        /// </summary>
        public bool NumberAccountValidateMessageIsVisible
        {
            get => numberAccountValidateMessageIsVisible;
            set
            {
                numberAccountValidateMessageIsVisible = value;
                OnPropertyChanged(nameof(NumberAccountValidateMessageIsVisible));
            }
        }

        /// <summary>
        /// Флаг для валидационного сообщения для имени ответсвенного плательщика.
        /// </summary>
        public bool FirstNamePayerValidateMessageIsVisible
        {
            get => firstNamePayerValidateMessageIsVisible;
            set
            {
                firstNamePayerValidateMessageIsVisible = value;
                OnPropertyChanged(nameof(FirstNamePayerValidateMessageIsVisible));
            }
        }

        /// <summary>
        /// Флаг для валидационного сообщения для фамилии ответсвенного плательщика.
        /// </summary>
        public bool LastNamePayerValidateMessageIsVisible
        {
            get => lastNamePayerValidateMessageIsVisible;
            set
            {
                lastNamePayerValidateMessageIsVisible = value;
                OnPropertyChanged(nameof(LastNamePayerValidateMessageIsVisible));
            }
        }

        /// <summary>
        /// Флаг для валидационного сообщения для отчетва ответсвенного плательщика.
        /// </summary>
        public bool MiddleNamePayerValidateMessageIsVisible
        {
            get => middleNamePayerValidateMessageIsVisible;
            set
            {
                middleNamePayerValidateMessageIsVisible = value;
                OnPropertyChanged(nameof(MiddleNamePayerValidateMessageIsVisible));
            }
        }


        private void initialization()
        {
            ServiceTypes = organization.ServiceTypes.Select(x => mapServiceTypeSelection(x)).ToList();
            clearValidateField();
        }

        private ServiceTypeSelectionModelView mapServiceTypeSelection(ServiceTypeModelView serviceType)
        {
            return new ServiceTypeSelectionModelView
            {
                Id = serviceType.Id,
                Title = serviceType.Title
            };
        }

        private ServiceTypeDto mapServiceTypeDto(ServiceTypeSelectionModelView serviceType)
        {
            return new ServiceTypeDto
            {
                Id = serviceType.Id,
                Title = serviceType.Title
            };
        }
        private bool validateField()
        {
            clearValidateField();

            var flag = true;

            if (string.IsNullOrWhiteSpace(MessageText))
            {
                MessageTextValidateMessage = "Введите текст обращения.";
                MessageTextValidateMessageIsVisible = true;
                flag = false;
            }

            if (string.IsNullOrWhiteSpace(NumberAccount))
            {
                NumberAccountValidateMessage = "Введите номер счёта.";
                NumberAccountValidateMessageIsVisible = true;
                flag = false;
            }

            if (string.IsNullOrWhiteSpace(FirstNamePayer))
            {
                FirstNamePayerValidateMessage = "Введите имя ответсвенного плательщика";
                FirstNamePayerValidateMessageIsVisible = true;
                flag = false;
            }

            if (string.IsNullOrWhiteSpace(LastNamePayer))
            {
                LastNamePayerValidateMessage = "Введите фамилию отвественного плательщика";
                LastNamePayerValidateMessageIsVisible = true;
                flag = false;
            }

            if (string.IsNullOrWhiteSpace(MiddleNamePayer))
            {
                MiddleNamePayerValidateMessage = "Введите отчество ответсвенного плательщика";
                MiddleNamePayerValidateMessageIsVisible = true;
                flag = false;
            }

            return flag;
        }

        private void clearValidateField()
        {
            MessageTextValidateMessage = string.Empty;
            NumberAccountValidateMessage = string.Empty;
            FirstNamePayerValidateMessage = string.Empty;
            LastNamePayerValidateMessage = string.Empty;
            MiddleNamePayerValidateMessage = string.Empty;

            MessageTextValidateMessageIsVisible = false;
            NumberAccountValidateMessageIsVisible = false;
            FirstNamePayerValidateMessageIsVisible = false;
            LastNamePayerValidateMessageIsVisible = false;
            MiddleNamePayerValidateMessageIsVisible = false;
        }
    }
}
