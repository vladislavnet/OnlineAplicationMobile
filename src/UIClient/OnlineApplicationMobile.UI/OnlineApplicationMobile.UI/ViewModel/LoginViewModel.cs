using OnlineApplicationMobile.UI.ViewModel.Interfaces;
using OnlineApplicationMobile.UI.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace OnlineApplicationMobile.UI.ViewModel
{
    /// <summary>
    /// ViewModel Авторизации.
    /// </summary>
    public class LoginViewModel : BaseViewModel, IViewModel
    {
        private string email;
        private string password;
        private string emailValidateMessage;
        private string passwordValidateMessage;
        private bool emailIsVisible;
        private bool passwordIsVisible;

        public LoginViewModel(IView view)
        {
            View = view;
            View.ViewModel = this;

            EmailIsVisible = false;
            PasswordIsVisible = false;
        }

        /// <summary>
        /// Команда для Авторизации.
        /// </summary>
        public ICommand LoginCommand { get; protected set; }

        /// <summary>
        /// Email.
        /// </summary>
        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        /// <summary>
        /// Пароль.
        /// </summary>
        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
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
        /// Валидационное сообщение для Пароля.
        /// </summary>
        public string PasswordValidateMessage
        {
            get => passwordValidateMessage;
            set
            {
                passwordValidateMessage = value;
                OnPropertyChanged(nameof(PasswordValidateMessage));
            }
        }

        /// <summary>
        /// Флаг видимости поля валидацинного сообщения Email.
        /// </summary>
        public bool EmailIsVisible
        {
            get => emailIsVisible;
            set
            {
                emailIsVisible = value;
                OnPropertyChanged(nameof(EmailIsVisible));
            }
        }

        /// <summary>
        /// Флаг видимости поля валидацинного сообщения Пароля.
        /// </summary>
        public bool PasswordIsVisible
        {
            get => passwordIsVisible;
            set
            {
                passwordIsVisible = value;
                OnPropertyChanged(nameof(PasswordIsVisible));
            }
        }

        /// <summary>
        /// Предаствление.
        /// </summary>
        public IView View { get; set; }

        /// <summary>
        /// Метод для авторизации пользователя.
        /// </summary>
        private void toLogin()
        {
            if (!validateToLogin())
                return;

            View.DisplayAlertMessage("Авторизован");
        }

        /// <summary>
        /// Валидация для авторизации.
        /// </summary>
        /// <returns>Флаг валидации.</returns>
        private bool validateToLogin()
        {
            var flag = true;

            if (string.IsNullOrWhiteSpace(Email))
            {
                EmailValidateMessage = "Email не может быть пустым.";
                EmailIsVisible = true;
                flag = false;
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                PasswordValidateMessage = "Пароль не может быть пустым.";
                PasswordIsVisible = true;
                flag = false;
            }

            return flag;
        }
    }
}
