using OnlineApplicationMobile.HttpService.Interfaces;
using OnlineApplicationMobile.HttpService.Requests;
using OnlineApplicationMobile.HttpService.Responses;
using System;

namespace OnlineApplicationMobile.HttpService.Implementation
{
    public class UserHttpService : BaseHttpService, IUserHttpService
    {
        /// <inheritdoc />
        public GetInfoCurrentClientJKHResponse GetInfoCurrentClientJKH(RequestBase request)
        {
            throw new NotImplementedException();
        }
    }
}
