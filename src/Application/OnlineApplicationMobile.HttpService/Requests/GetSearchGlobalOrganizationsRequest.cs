using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineApplicationMobile.HttpService.Requests
{
    /// <summary>
    /// Запрос на поиск организаций.
    /// </summary>
    public class GetSearchGlobalOrganizationsRequest : RequestBase
    {
        public string SearchText { get; set; }
    }
}
