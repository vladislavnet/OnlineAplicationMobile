using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace OnlineApplicationMobile.HttpService.Requests
{
    /// <summary>
    /// Запрос на добавления комментария заявки.
    /// </summary>
    public class PostCommentApplicationRequest : RequestBase
    {
        /// <summary>
        /// Уникальный идентификатор заявки.
        /// </summary>
        [JsonPropertyName("applicationId")]
        public Guid ApplicationId { get; set; }

        /// <summary>
        /// Комментарий для заявки.
        /// </summary>
        [JsonPropertyName("comment")]
        public string Comment { get; set; }
    }
}
