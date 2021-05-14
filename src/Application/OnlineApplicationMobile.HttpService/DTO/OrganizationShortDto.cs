using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace OnlineApplicationMobile.HttpService.DTO
{
    public class OrganizationShortDto : OrganizationShortNotByServiceTypesDto
    {
        /// <summary>
        /// Типы услуг которая предоставляет организация.
        /// </summary>
        [JsonPropertyName("serviceTypes")]
        public ServiceTypeDto[] ServiceTypes { get; set; }
    }
}
