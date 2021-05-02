namespace OnlineApplicationMobile.HttpService.Responses
{
    /// <summary>
    /// Класс ответа авторизации.
    /// </summary>
    public class AuthorizationResponse : ResponseBase
    {
        /// <summary>
        /// Токен пользователя.
        /// </summary>
        public string Token { get; set; }
    }
}
