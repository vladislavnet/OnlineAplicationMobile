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
        public GetOrganizationsByUserResponse GetOrganizationsByUser(RequestBase request)
        {
            using (var client = GetClientByHeaderAuthorization(request.Token))
            {
                var response = client.GetAsync(UrlTemplates.GetOrganizationsByUserUrl).Result;

                ResponseBase message = new ResponseBase();
                OrganizationShortDto[] organizationShortDtos = null;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    organizationShortDtos = JsonSerializer.Deserialize<OrganizationShortDto[]>(response.Content.ReadAsStringAsync().Result, optionsSerialize);
                }
                else
                {
                    message = JsonSerializer.Deserialize<ResponseBase>(response.Content.ReadAsStringAsync().Result, optionsSerialize);
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
        public GetSearchGlobalOrganizationsResponse GetSearchGlobalOrganizations(GetSearchGlobalOrganizationsRequest request)
        {
            using (var client = GetClientByHeaderAuthorization(request.Token))
            {
                var response = client.GetAsync(string.Format(UrlTemplates.GetSearchGlobalOrganizationsUrl, request.SearchText)).Result;

                ResponseBase message = new ResponseBase();
                OrganizationShortDto[] organizationShortDtos = null;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    organizationShortDtos = JsonSerializer.Deserialize<OrganizationShortDto[]>(response.Content.ReadAsStringAsync().Result, optionsSerialize);
                }
                else
                {
                    message = JsonSerializer.Deserialize<ResponseBase>(response.Content.ReadAsStringAsync().Result, optionsSerialize);
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
