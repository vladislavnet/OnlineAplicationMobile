using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace OnlineApplicationMobile.HttpService.DTO
{
    /// <summary>
    /// Тип адресного объекта.
    /// </summary>
    public class TypeAddressingObjectDto
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
        /// Короткое наименование.
        /// </summary>
        [JsonPropertyName("shortName")]
        public string ShortName { get; set; }

        /// <summary>
        /// Уровень объекта адресации.
        /// </summary>
        [JsonPropertyName("level")]
        public LevelAddressingObjectDto Level { get; set; }
    }
}
