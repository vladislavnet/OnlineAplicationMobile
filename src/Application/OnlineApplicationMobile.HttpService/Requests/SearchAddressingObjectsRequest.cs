using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineApplicationMobile.HttpService.Requests
{
    /// <summary>
    /// Запрос на получение адресных объектов.
    /// </summary>
    public class SearchAddressingObjectsRequest : RequestBase
    {
        /// <summary>
        /// Наияменование.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Уровень.
        /// </summary>
        public int Level { get; set; }
    }
}
