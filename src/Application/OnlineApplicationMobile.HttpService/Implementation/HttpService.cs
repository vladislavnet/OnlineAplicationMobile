using OnlineApplicationMobile.HttpService.Interfaces;
using OnlineApplicationMobile.HttpService.Requests;
using OnlineApplicationMobile.HttpService.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<AuthorizationResponse> Authorization(AuthorizationRequest request)
        {
            return await _userHttpService.Authorization(request);
        }

        /// <inheritdoc />
        public async Task<GetApplicationDetailCurrentClientJKHResponse> GetApplicationDetailCurrentClientJKH(GetApplicationDetailCurrentClientJKHRequest request)
        {
            return await _applicationHttpService.GetApplicationDetailCurrentClientJKH(request);
        }

        /// <inheritdoc />
        public async Task<GetApplicationsCurrentClientJKHResponse> GetApplicationsCurrentClientJKH(RequestBase request)
        {
            return await _applicationHttpService.GetApplicationsCurrentClientJKH(request);
        }

        /// <inheritdoc />
        public async Task<GetInfoCurrentClientJKHResponse> GetInfoCurrentClientJKH(RequestBase request)
        {
            return await _userHttpService.GetInfoCurrentClientJKH(request);
        }

        /// <inheritdoc />
        public async Task<GetOrganizationsByUserResponse> GetOrganizationsByUser(RequestBase request)
        {
            return await _organizationHttpService.GetOrganizationsByUser(request);
        }

        /// <inheritdoc />
        public async Task<SearchAddressingObjectsResponse> GetSearchAddressingObjects(SearchAddressingObjectsRequest request)
        {
            return await _commonHttpService.GetSearchAddressingObjects(request);
        }

        /// <inheritdoc />
        public async Task<GetSearchGlobalOrganizationsResponse> GetSearchGlobalOrganizations(GetSearchGlobalOrganizationsRequest request)
        {
            return await _organizationHttpService.GetSearchGlobalOrganizations(request);
        }

        /// <inheritdoc />
        public async Task<GetTypesAddressingObjectResponse> GetTypesAddressingObject(GetTypesAddressingObjectRequest request)
        {
            return await _commonHttpService.GetTypesAddressingObject(request);
        }

        /// <inheritdoc />
        public async Task<ResponseBase> PostApplication(PostApplicationRequest request)
        {
            return await _applicationHttpService.PostApplication(request);
        }

        /// <inheritdoc />
        public async Task<ResponseBase> PostCommentApplication(PostCommentApplicationRequest request)
        {
            return await _applicationHttpService.PostCommentApplication(request);
        }

        /// <inheritdoc />
        public async Task<ResponseBase> PostRegistrationClientJKH(PostRegistrationClientJKHRequest request)
        {
            return await _userHttpService.PostRegistrationClientJKH(request);
        }

        /// <inheritdoc />
        public async Task<ResponseBase> PutInfoCurrentClientJKH(PutInfoCurrentClientJKHRequest request)
        {
            return await _userHttpService.PutInfoCurrentClientJKH(request);
        }
    }
}
