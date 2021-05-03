using OnlineApplicationMobile.HttpService.Requests;
using OnlineApplicationMobile.HttpService.Responses;

namespace OnlineApplicationMobile.HttpService.Interfaces
{
    public interface ICommonHttpService
    {
        /// <summary>
        /// Возвращает массив адресных объектов.
        /// </summary>
        /// <param name="request">Запрос.</param>
        /// <returns>Ответ.</returns>
        SearchAddressingObjectsResponse GetSearchAddressingObjects(SearchAddressingObjectsRequest request);
    }
}
