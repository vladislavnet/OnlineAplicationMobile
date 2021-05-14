using OnlineApplicationMobile.HttpService.Requests;
using OnlineApplicationMobile.HttpService.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineApplicationMobile.HttpService.Interfaces
{
    public interface IOrganizationHttpService
    {
        /// <summary>
        /// Получение пользователей которые обслуживают текущего пользователя.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<GetOrganizationsByUserResponse> GetOrganizationsByUser(RequestBase request);

        /// <summary>
        /// Поиск организаций.
        /// </summary>
        /// <param name="request">Запрос.</param>
        /// <returns>Ответ.</returns>
        Task<GetSearchGlobalOrganizationsResponse> GetSearchGlobalOrganizations(GetSearchGlobalOrganizationsRequest request);
    }
}
