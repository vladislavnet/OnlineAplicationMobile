using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace OnlineApplicationMobile.HttpService.Requests
{
    public class GetTypesAddressingObjectRequest : RequestBase
    {
        [JsonPropertyName("level")]
        public int Level { get; set; }
    }
}
