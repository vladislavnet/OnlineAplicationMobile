using System.Net;

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
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Сообщение от сервера.
        /// </summary>
        public string Message { get; set; }
    }
}
