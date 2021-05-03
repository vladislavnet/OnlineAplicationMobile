using OnlineApplicationMobile.HttpService.Interfaces;
using OnlineApplicationMobile.HttpService.Requests;
using OnlineApplicationMobile.HttpService.Responses;
using System;
using System.Net;

namespace OnlineApplicationMobile.HttpService.Implementation
{
    public class UserHttpService : BaseHttpService, IUserHttpService
    {
        /// <inheritdoc />
        public AuthorizationResponse Authorization(AuthorizationRequest request)
        {
            return new AuthorizationResponse { Message = "Test Authorization" };
        }

        /// <inheritdoc />
        public GetInfoCurrentClientJKHResponse GetInfoCurrentClientJKH(RequestBase request)
        {
            return new GetInfoCurrentClientJKHResponse { StatusCode = HttpStatusCode.Forbidden, Message = "Test Get Info" };
        }

        /// <inheritdoc />
        public ResponseBase PutInfoCurrentClientJKH(PutInfoCurrentClientJKHRequest request)
        {
            return new ResponseBase { StatusCode = HttpStatusCode.Created, Message = "Данные успешно обновлены" };
        }
    }
}
