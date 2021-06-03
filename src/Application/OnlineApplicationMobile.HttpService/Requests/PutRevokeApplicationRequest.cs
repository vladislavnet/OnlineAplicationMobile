using System;
using System.Text.Json.Serialization;

namespace OnlineApplicationMobile.HttpService.Requests
{
    /// <summary>
    /// Класс запроса на отзыва заявки.
    /// </summary>
    public class PutRevokeApplicationRequest : RequestBase
    {
        /// <summary>
        /// Уникальный идентификатор заявки.
        /// </summary>
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
    }
}
