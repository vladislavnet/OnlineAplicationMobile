using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace OnlineApplicationMobile.HttpService.DTO
{
    /// <summary>
    /// Адресный объект (Сокращенный).
    /// </summary>
    public class AddressingObjectShortDto
    {
        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Наименование.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Тип адресного объекта.
        /// </summary>
        [JsonPropertyName("type")]
        public TypeAddressingObjectDto Type { get; set; }
    }
}
