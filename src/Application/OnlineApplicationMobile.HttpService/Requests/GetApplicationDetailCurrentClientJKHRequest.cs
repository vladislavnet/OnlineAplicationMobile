using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace OnlineApplicationMobile.HttpService.Requests
{
    /// <summary>
    /// Запрос получения детальной информации заявки текущего пользователя.
    /// </summary>
    public class GetApplicationDetailCurrentClientJKHRequest : RequestBase
    {
        /// <summary>
        /// Уникальный идентификатор заявки.
        /// </summary>
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
    }
}
