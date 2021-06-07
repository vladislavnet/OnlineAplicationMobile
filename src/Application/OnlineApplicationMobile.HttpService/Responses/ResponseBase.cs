using System.Net;
using System.Text.Json.Serialization;

namespace OnlineApplicationMobile.HttpService.Responses
{
    /// <summary>
    /// Базовый ответ от сервера.
    /// </summary>
    public class ResponseBase
    {
        /// <summary>
        /// Код состояния HTTP переданный от сервера.
        /// </summary>
        [JsonIgnore]
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Сообщение от сервера.
        /// </summary>
        [JsonPropertyName("message")] 
        public string Message { get; set; }
    }
}
