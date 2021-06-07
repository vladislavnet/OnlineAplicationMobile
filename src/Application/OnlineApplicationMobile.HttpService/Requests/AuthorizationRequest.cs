using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

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
        [JsonPropertyName("username")]
        public string Username { get; set; }

        /// <summary>
        /// Пароль.
        /// </summary>
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
