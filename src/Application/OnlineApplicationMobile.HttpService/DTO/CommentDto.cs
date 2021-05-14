using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace OnlineApplicationMobile.HttpService.DTO
{
    /// <summary>
    /// Комментарий.
    /// </summary>
    public class CommentDto
    {
        /// <summary>
        /// Автор комментария.
        /// </summary>
        [JsonPropertyName("author")]
        public UserCommentInformationDto Author { get; set; }

        /// <summary>
        /// Комментарий.
        /// </summary>
        [JsonPropertyName("comment")]
        public string Comment { get; set; }

        /// <summary>
        /// Дата создания комментария.
        /// </summary>
        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }
    }
}
