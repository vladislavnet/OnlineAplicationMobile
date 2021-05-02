﻿using OnlineApplicationMobile.HttpService.Interfaces;
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
        public GetInfoCurrentClientJKHResponse GetInfoCurrentClientJKH(RequestBase request)
        {
            return _userHttpService.GetInfoCurrentClientJKH(request);
        }
    }
}