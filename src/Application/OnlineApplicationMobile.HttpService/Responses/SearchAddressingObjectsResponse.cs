using OnlineApplicationMobile.HttpService.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineApplicationMobile.HttpService.Responses
{
    /// <summary>
    /// Ответ на запрос получения адресных объектов.
    /// </summary>
    public class SearchAddressingObjectsResponse : ResponseBase
    {
        /// <summary>
        /// Массив адресных объектов.
        /// </summary>
        public AddressingObjectShortDto[] addressingObjectsShort { get; set; }
    }
}
