using OnlineApplicationMobile.HttpService.DTO;
using OnlineApplicationMobile.HttpService.Interfaces;
using OnlineApplicationMobile.HttpService.Requests;
using OnlineApplicationMobile.HttpService.Responses;
using OnlineApplicationMobile.HttpService.Templates;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OnlineApplicationMobile.HttpService.Implementation
{
    public class OrganizationHttpService : BaseHttpService, IOrganizationHttpService
    {
        /// <inheritdoc />
        public async Task<GetOrganizationsByUserResponse> GetOrganizationsByUser(RequestBase request)
        {
            using (var client = GetClientByHeaderAuthorization(request.Token))
            {
                var response = await client.GetAsync(UrlTemplates.GetOrganizationsByUserUrl);

                ResponseBase message = new ResponseBase();
                OrganizationShortDto[] organizationShortDtos = null;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    organizationShortDtos = JsonSerializer.Deserialize<OrganizationShortDto[]>(await response.Content.ReadAsStringAsync(), optionsSerialize);
                }
                else
                {
                    message = JsonSerializer.Deserialize<ResponseBase>(await response.Content.ReadAsStringAsync(), optionsSerialize);
                }

                return new GetOrganizationsByUserResponse
                {
                    Message = message.Message,
                    StatusCode = response.StatusCode,
                    Organizations = organizationShortDtos
                };
            };
        }

        /// <inheritdoc />
        public async Task<GetSearchGlobalOrganizationsResponse> GetSearchGlobalOrganizations(GetSearchGlobalOrganizationsRequest request)
        {
            using (var client = GetClientByHeaderAuthorization(request.Token))
            {
                var response = await client.GetAsync(UrlTemplates.GetSearchGlobalOrganizationsUrl);

                ResponseBase message = new ResponseBase();
                OrganizationShortDto[] organizationShortDtos = null;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    organizationShortDtos = JsonSerializer.Deserialize<OrganizationShortDto[]>(await response.Content.ReadAsStringAsync(), optionsSerialize);
                }
                else
                {
                    message = JsonSerializer.Deserialize<ResponseBase>(await response.Content.ReadAsStringAsync(), optionsSerialize);
                }

                return new GetSearchGlobalOrganizationsResponse
                {
                    Message = message.Message,
                    StatusCode = response.StatusCode,
                    Organizations = organizationShortDtos
                };
            };
        }
    }
}
