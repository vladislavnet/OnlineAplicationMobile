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
        public int Id { get; set; }

        /// <summary>
        /// Наименование.
        /// </summary>
        public string Title { get; set; }
    }
}
