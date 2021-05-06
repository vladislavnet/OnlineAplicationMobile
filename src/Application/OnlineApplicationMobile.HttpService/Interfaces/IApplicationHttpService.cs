using OnlineApplicationMobile.HttpService.Requests;
using OnlineApplicationMobile.HttpService.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineApplicationMobile.HttpService.Interfaces
{
    public interface IApplicationHttpService
    {
        /// <summary>
        /// Получение заявок текущего клиента ЖКХ.
        /// </summary>
        /// <param name="request">Запрос.</param>
        /// <returns>Ответ.</returns>
        GetApplicationsCurrentClientJKHResponse GetApplicationsCurrentClientJKH(RequestBase request);
    }
}
