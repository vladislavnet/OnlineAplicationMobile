using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineApplicationMobile.HttpService.Interfaces
{
    public interface IHttpService 
        : IUserHttpService,
        IApplicationHttpService,
        IOrganizationHttpService,
        ICommonHttpService
    {
    }
}
