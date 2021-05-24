using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace OnlineApplicationMobile.HttpService.DTO
{
    /// <summary>
    /// История заявки.
    /// </summary>
    public class HistoryApplicationDto
    {
        /// <summary>
        /// Пользователь сделавший обновление.
        /// </summary>
        [JsonPropertyName("user")]
        public UserHistoryApplicationInformationDto User { get; set; }

        /// <summary>
        /// Статус заявки.
        /// </summary>
        [JsonPropertyName("statusApplication")]
        public int StatusApplication { get; set; }

        /// <summary>
        /// Дата создания.
        /// </summary>
        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }
    }
}
