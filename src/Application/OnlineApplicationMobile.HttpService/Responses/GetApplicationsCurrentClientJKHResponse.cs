using OnlineApplicationMobile.HttpService.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineApplicationMobile.HttpService.Responses
{
    /// <summary>
    /// Ответ на запрос получения заявок текущего клиента ЖКХ.
    /// </summary>
    public class GetApplicationsCurrentClientJKHResponse : ResponseBase
    {
        /// <summary>
        /// Массив заявок.
        /// </summary>
        public ApplicationShortDto[] Applications { get; set; }
    }
}
