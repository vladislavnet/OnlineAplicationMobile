using System.Text.Json.Serialization;

namespace OnlineApplicationMobile.HttpService.DTO
{
    /// <summary>
    /// Типы услуг предоставляемые организациями.
    /// </summary>
    public class ServiceTypeDto
    {
        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Наименование.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}
