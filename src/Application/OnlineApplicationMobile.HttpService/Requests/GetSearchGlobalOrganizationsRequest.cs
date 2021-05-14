using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace OnlineApplicationMobile.HttpService.Requests
{
    /// <summary>
    /// Запрос на поиск организаций.
    /// </summary>
    public class GetSearchGlobalOrganizationsRequest : RequestBase
    {
        [JsonPropertyName("searchText")]
        public string SearchText { get; set; }
    }
}
