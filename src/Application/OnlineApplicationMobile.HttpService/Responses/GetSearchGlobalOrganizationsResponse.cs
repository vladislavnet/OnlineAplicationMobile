using OnlineApplicationMobile.HttpService.DTO;

namespace OnlineApplicationMobile.HttpService.Responses
{
    /// <summary>
    /// Ответ на запрос поиска организаций.
    /// </summary>
    public class GetSearchGlobalOrganizationsResponse : ResponseBase
    {
        /// <summary>
        /// Список организаций.
        /// </summary>
        public OrganizationShortDto[] Organizations { get; set; }
    }
}
