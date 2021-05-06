using OnlineApplicationMobile.HttpService.Interfaces;
using OnlineApplicationMobile.HttpService.Requests;
using OnlineApplicationMobile.HttpService.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineApplicationMobile.HttpService.Implementation
{
    public class HttpService : IHttpService
    {
        private readonly IUserHttpService _userHttpService;
        private readonly IApplicationHttpService _applicationHttpService;
        private readonly IOrganizationHttpService _organizationHttpService;
        private readonly ICommonHttpService _commonHttpService;

        public HttpService(IUserHttpService userHttpService,
            IApplicationHttpService applicationHttpService,
            IOrganizationHttpService organizationHttpService,
            ICommonHttpService commonHttpService)
        {
            _userHttpService = userHttpService;
            _applicationHttpService = applicationHttpService;
            _organizationHttpService = organizationHttpService;
            _commonHttpService = commonHttpService;
        }

        /// <inheritdoc />
        public AuthorizationResponse Authorization(AuthorizationRequest request)
        {
            return _userHttpService.Authorization(request);
        }

        /// <inheritdoc />
        public GetApplicationsCurrentClientJKHResponse GetApplicationsCurrentClientJKH(RequestBase request)
        {
            return _applicationHttpService.GetApplicationsCurrentClientJKH(request);
        }

        /// <inheritdoc />
        public GetInfoCurrentClientJKHResponse GetInfoCurrentClientJKH(RequestBase request)
        {
            return _userHttpService.GetInfoCurrentClientJKH(request);
        }

        /// <inheritdoc />
        public SearchAddressingObjectsResponse GetSearchAddressingObjects(SearchAddressingObjectsRequest request)
        {
            return _commonHttpService.GetSearchAddressingObjects(request);
        }

        /// <inheritdoc />
        public GetTypesAddressingObjectResponse GetTypesAddressingObject(GetTypesAddressingObjectRequest request)
        {
            return _commonHttpService.GetTypesAddressingObject(request);
        }

        /// <inheritdoc />
        public ResponseBase PutInfoCurrentClientJKH(PutInfoCurrentClientJKHRequest request)
        {
            return _userHttpService.PutInfoCurrentClientJKH(request);
        }
    }
}
