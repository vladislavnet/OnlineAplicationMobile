using System;
using System.Text.Json.Serialization;

namespace OnlineApplicationMobile.HttpService.Requests
{
    /// <summary>
    /// Запрос на регистрацию клиента ЖКХ.
    /// </summary>
    public class PostRegistrationClientJKHRequest : RequestBase
    {
        /// <summary>
        /// Email.
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; set; }

        /// <summary>
        /// Пароль.
        /// </summary>
        [JsonPropertyName("password")]
        public string Password { get; set; }

        /// <summary>
        /// Подтверждение пароля.
        /// </summary>
        [JsonPropertyName("password2")]
        public string Password2 { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        /// <summary>
        /// Отчество.
        /// </summary>
        [JsonPropertyName("middleName")]
        public string MiddleName { get; set; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        [JsonPropertyName("birthDate")]
        public string BirthDate { get; set; }

        /// <summary>
        /// Телефон.
        /// </summary>
        [JsonPropertyName("telephone")]
        public string Telephone { get; set; }
    }
}
