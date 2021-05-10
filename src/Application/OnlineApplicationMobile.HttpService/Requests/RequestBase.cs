using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace OnlineApplicationMobile.HttpService.Requests
{
    /// <summary>
    /// Класс базового запроса.
    /// </summary>
    public class RequestBase
    {
        [JsonIgnore]
        public string Token { get; set; }
    }
}
