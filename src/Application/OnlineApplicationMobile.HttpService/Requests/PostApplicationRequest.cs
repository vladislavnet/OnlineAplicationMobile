using OnlineApplicationMobile.HttpService.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace OnlineApplicationMobile.HttpService.Requests
{
    /// <summary>
    /// Запрос на добавление заявки.
    /// </summary>
    public class PostApplicationRequest : RequestBase
    {
        /// <summary>
        /// Текст обращения.
        /// </summary>
        [JsonPropertyName("messageText")]
        public string MessageText { get; set; }

        /// <summary>
        /// Номер счёта.
        /// </summary>
        [JsonPropertyName("numberAccount")]
        public string NumberAccount { get; set; }

        /// <summary>
        /// Имя ответсвенного плательщика.
        /// </summary>
        [JsonPropertyName("firstNamePayer")]
        public string FirstNamePayer { get; set; }

        /// <summary>
        /// Фамилия ответсвенного плательщика.
        /// </summary>
        [JsonPropertyName("lastNamePayer")]
        public string LastNamePayer { get; set; }

        /// <summary>
        /// Отчество ответсвенного плательщика.
        /// </summary>
        [JsonPropertyName("middleNamePayer")]
        public string MiddleNamePayer { get; set; }

        /// <summary>
        /// Уникальный идентификатор организации.
        /// </summary>
        [JsonPropertyName("organizationId")]
        public int OrganizationId { get; set; }

        /// <summary>
        /// Выбранные типы услуг.
        /// </summary>
        [JsonPropertyName("serviseTypes")]
        public ServiceTypeDto[] ServiseTypes { get; set; }
    }
}
