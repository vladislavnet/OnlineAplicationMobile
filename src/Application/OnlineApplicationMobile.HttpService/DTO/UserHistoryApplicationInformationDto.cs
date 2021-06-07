using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace OnlineApplicationMobile.HttpService.DTO
{
    /// <summary>
    /// Информация о пользователе для истории заявки
    /// </summary>
    public class UserHistoryApplicationInformationDto
    {
        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Имя пользователя.
        /// </summary>
        [JsonPropertyName("firtsName")]
        public string FirtsName { get; set; }

        /// <summary>
        /// Фамилия пользователя.
        /// </summary>
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        /// <summary>
        /// Отчество пользователя.
        /// </summary>
        [JsonPropertyName("middleName")]
        public string MiddleName { get; set; }
    }
}
