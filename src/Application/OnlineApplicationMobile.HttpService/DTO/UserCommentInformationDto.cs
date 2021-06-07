using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace OnlineApplicationMobile.HttpService.DTO
{
    /// <summary>
    /// Информация пользователя который оставил комментарий.
    /// </summary>
    public class UserCommentInformationDto
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
    }
}
