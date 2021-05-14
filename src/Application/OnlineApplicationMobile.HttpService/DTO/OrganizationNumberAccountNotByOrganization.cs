using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace OnlineApplicationMobile.HttpService.DTO
{
    /// <summary>
    /// Номер счёта которому организация предоставляет услуги.
    /// </summary>
    public class OrganizationNumberAccountNotByOrganization
    {
        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Номер счёта.
        /// </summary>
        [JsonPropertyName("numberAccount")]
        public string NumberAccount { get; set; }

        /// <summary>
        /// Имя отвественного плательщика.
        /// </summary>
        [JsonPropertyName("firstNamePayer")]
        public string FirstNamePayer { get; set; }

        /// <summary>
        /// Фамилия отвественного плательщика.
        /// </summary>
        [JsonPropertyName("lastNamePayer")]
        public string LastNamePayer { get; set; }

        /// <summary>
        /// Отчество отвественного плательщика.
        /// </summary>
        [JsonPropertyName("middleNamePayer")]
        public string MiddleNamePayer { get; set; }
    }
}
