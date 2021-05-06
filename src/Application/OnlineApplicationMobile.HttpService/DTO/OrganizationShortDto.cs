using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineApplicationMobile.HttpService.DTO
{
    public class OrganizationShortDto : OrganizationShortNotByServiceTypesDto
    {
        /// <summary>
        /// Типы услуг которая предоставляет организация.
        /// </summary>
        public ServiceTypeDto[] ServiceTypes { get; set; }
    }
}
