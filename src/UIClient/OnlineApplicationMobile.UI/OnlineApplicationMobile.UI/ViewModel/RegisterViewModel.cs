using OnlineApplicationMobile.HttpService.Interfaces;
using OnlineApplicationMobile.HttpService.Requests;
using OnlineApplicationMobile.UI.ViewModel.Interfaces;
using OnlineApplicationMobile.UI.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace OnlineApplicationMobile.UI.ViewModel
{
    public class RegisterViewModel : BaseViewModel, IViewModel
    {
        private string email;
        private string password1;
        private string password2;
        private string firstName;
        private string lastName;
        private string middleName;
        private DateTime? birthDate;
        private string telephone;

        private string emailValidateMessage;
        private string password1ValidateMessage;
        private string password2ValidateMessage;
        private string firstNameValidateMessage;
        private string lastNameValidateMessage;

        private bool emailValidateMessageIsVisible;
        private bool password1ValidateMessageIsVisible;
        private bool password2ValidateMessageIsVisible;
        private bool firstNameValidateMessageIsVisible;
        private bool lastNameValidateMessageIsVisible;

        public RegisterViewModel(IView view, INavigation navigation) : base(navigation)
        {
            View = view;
            View.ViewModel = this;
            clearValidatedField();
        }

        /// <summary>
        /// Команда для регистрации пользователя.
        /// </summary>
        public ICommand RegisterCommand
        {
            get => new Command(() =>
            {
                if (!validateRegisterField())
                    return;

                var httpService = Startup.GetService<IHttpService>();

                var response = httpService.PostRegistrationClientJKH(new PostRegistrationClientJKHRequest 
                {
                    Email = Email,
                    Password = Password1,
                    Password2 = Password2,
                    FirstName = FirstName,
                    LastName = LastName,
                    MiddleName = MiddleName,
                    BirthDate = BirthDate?.ToString("yyyy-MM-dd"),
                    Telephone = Telephone
                }).Result;

                Action action = () =>
                {
                    DisplayMessage("Регистрация прошла успешно, подтвердите Email.");
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
        /// Пароль.
        /// </summary>
        public string Password1
        {
            get => password1;
            set
            {
                password1 = value;
                OnPropertyChanged(nameof(Password1));
            }
        }

        /// <summary>
        /// Повторение пароля.
        /// </summary>
        public string Password2
        {
            get => password2;
            set
            {
                password2 = value;
                OnPropertyChanged(nameof(Password2));
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
        public DateTime? BirthDate
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
        /// Валидационное сообщение для Email.
        /// </summary>
        public string EmailValidateMessage
        {
            get => emailValidateMessage;
            set
            {
                emailValidateMessage = value;
                OnPropertyChanged(nameof(EmailValidateMessage));
            }
        }

        /// <summary>
        /// Валидационное сообщение для пароля.
        /// </summary>
        public string Password1ValidateMessage
        {
            get => password1ValidateMessage;
            set
            {
                password1ValidateMessage = value;
                OnPropertyChanged(nameof(Password1ValidateMessage));
            }
        }

        /// <summary>
        /// Валидационное сообщение для подтверждения пароля.
        /// </summary>
        public string Password2ValidateMessage
        {
            get => password2ValidateMessage;
            set
            {
                password2ValidateMessage = value;
                OnPropertyChanged(nameof(Password2ValidateMessage));
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
        /// Флаг для валидационнного сообщения для Email.
        /// </summary>
        public bool EmailValidateMessageIsVisible 
        {
            get => emailValidateMessageIsVisible;
            set
            {
                emailValidateMessageIsVisible = value;
                OnPropertyChanged(nameof(EmailValidateMessageIsVisible));
            }
        }

        /// <summary>
        /// Флаг для валидационнного сообщения для пароля.
        /// </summary>
        public bool Password1ValidateMessageIsVisible
        {
            get => password1ValidateMessageIsVisible;
            set
            {
                password1ValidateMessageIsVisible = value;
                OnPropertyChanged(nameof(Password1ValidateMessageIsVisible));
            }
        }

        /// <summary>
        /// Флаг для валидационнного сообщения для подтверждения пароля.
        /// </summary>
        public bool Password2ValidateMessageIsVisible
        {
            get => password2ValidateMessageIsVisible;
            set
            {
                password2ValidateMessageIsVisible = value;
                OnPropertyChanged(nameof(Password2ValidateMessageIsVisible));
            }
        }

        /// <summary>
        /// Флаг для валидационнного сообщения для имени.
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
        /// Флаг для валидационнного сообщения для Фамилии.
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


        private bool validateRegisterField()
        {
            clearValidatedField();

            var flag = true;

            if (string.IsNullOrWhiteSpace(Email))
            {
                EmailValidateMessage = "Введите Email.";
                EmailValidateMessageIsVisible = true;
                flag = false;
            }

            if (string.IsNullOrWhiteSpace(Password1))
            {
                Password1ValidateMessage = "Введите пароль.";
                Password1ValidateMessageIsVisible = true;
                flag = false;
            }

            if (string.IsNullOrWhiteSpace(Password2))
            {
                Password2ValidateMessage = "Введите подтверждение пароля.";
                Password2ValidateMessageIsVisible = true;
                flag = false;
            }

            if ((Password1 != Password2) && !flag)
            {
                Password1ValidateMessage = "Пароли должны совпадать.";
                Password2ValidateMessage = Password1ValidateMessage;
                Password1ValidateMessageIsVisible = true;
                Password2ValidateMessageIsVisible = Password1ValidateMessageIsVisible;
                flag = false;
            }

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

            return flag;
        }

        private void clearValidatedField()
        {
            EmailValidateMessage = string.Empty;
            Password1ValidateMessage = string.Empty;
            Password2ValidateMessage = string.Empty;
            FirstNameValidateMessage = string.Empty;
            LastNameValidateMessage = string.Empty;

            EmailValidateMessageIsVisible = false;
            Password1ValidateMessageIsVisible = false;
            Password2ValidateMessageIsVisible = false;
            FirstNameValidateMessageIsVisible = false;
            LastNameValidateMessageIsVisible = false;
        }
    }
}
