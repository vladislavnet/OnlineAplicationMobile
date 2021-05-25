using OnlineApplicationMobile.HttpService.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace OnlineApplicationMobile.HttpService.Requests
{
    /// <summary>
    /// Запрос на обновление информации текущего пользователя.
    /// </summary>
    public class PutInfoCurrentClientJKHRequest : RequestBase
    {
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

        /// <summary>
        /// Адрес.
        /// </summary>
        [JsonPropertyName("address")]
        public AddressDto Address { get; set; }
    }
}
