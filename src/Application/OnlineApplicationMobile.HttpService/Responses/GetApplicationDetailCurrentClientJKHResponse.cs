using OnlineApplicationMobile.HttpService.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace OnlineApplicationMobile.HttpService.Responses
{
    /// <summary>
    /// Ответ на запрос получения детальной информации заявки текущего пользователя.
    /// </summary>
    public class GetApplicationDetailCurrentClientJKHResponse : ResponseBase
    {
        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Статус заявки.
        /// </summary>
        [JsonPropertyName("statusApplication")]
        public int StatusApplication { get; set; }

        /// <summary>
        /// Текст обращения.
        /// </summary>
        [JsonPropertyName("messageText")]
        public string MessageText { get; set; }

        /// <summary>
        /// Организация.
        /// </summary>
        [JsonPropertyName("organization")]
        public OrganizationShortNotByServiceTypesDto Organization { get; set; }

        /// <summary>
        /// Номер лицевого счёта которому предоставляет организация услуги.
        /// </summary>
        [JsonPropertyName("organizationNumberAccount")]
        public OrganizationNumberAccountNotByOrganization OrganizationNumberAccount { get; set; }

        /// <summary>
        /// Дата создания.
        /// </summary>
        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Дата редактирования.
        /// </summary>
        [JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Типы услуг указанные в заявке.
        /// </summary>
        [JsonPropertyName("serviceTypes")]
        public ServiceTypeDto[] ServiceTypes { get; set; }

        /// <summary>
        /// Комментарии в заявке.
        /// </summary>
        [JsonPropertyName("comments")]
        public CommentDto[] Comments { get; set; }
    }
}
