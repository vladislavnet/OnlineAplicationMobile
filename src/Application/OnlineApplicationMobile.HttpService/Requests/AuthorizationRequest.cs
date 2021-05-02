using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineApplicationMobile.HttpService.Requests
{
    /// <summary>
    /// Класс запроса на авторизацию.
    /// </summary>
    public class AuthorizationRequest : RequestBase
    {
        /// <summary>
        /// Email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Пароль.
        /// </summary>
        public string Password { get; set; }
    }
}
