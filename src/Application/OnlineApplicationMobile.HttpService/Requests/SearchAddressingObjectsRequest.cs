using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace OnlineApplicationMobile.HttpService.Requests
{
    /// <summary>
    /// Запрос на получение адресных объектов.
    /// </summary>
    public class SearchAddressingObjectsRequest : RequestBase
    {
        /// <summary>
        /// Наияменование.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Уровень.
        /// </summary>
        [JsonPropertyName("level")]
        public int Level { get; set; }
    }
}
