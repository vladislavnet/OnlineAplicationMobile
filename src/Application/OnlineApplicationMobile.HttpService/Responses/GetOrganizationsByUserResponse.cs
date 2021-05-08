using OnlineApplicationMobile.HttpService.DTO;

namespace OnlineApplicationMobile.HttpService.Responses
{
    /// <summary>
    /// Ответ на запрос получения организаций пользователя.
    /// </summary>
    public class GetOrganizationsByUserResponse : ResponseBase
    {
        public OrganizationShortDto[] Organizations { get; set; }
    }
}
