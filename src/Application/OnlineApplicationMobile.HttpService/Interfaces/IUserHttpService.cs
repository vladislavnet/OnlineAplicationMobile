using OnlineApplicationMobile.HttpService.Requests;
using OnlineApplicationMobile.HttpService.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineApplicationMobile.HttpService.Interfaces
{
    public interface IUserHttpService
    {
        /// <summary>
        /// Получение информации по текущему клиенту ЖКХ.
        /// </summary>
        /// <param name="request">Запрос на получение информации.</param>
        /// <returns>Ответ на получение информации.</returns>
        GetInfoCurrentClientJKHResponse GetInfoCurrentClientJKH(RequestBase request);
    }
}
