using OnlineApplicationMobile.HttpService.DTO;
using OnlineApplicationMobile.HttpService.Interfaces;
using OnlineApplicationMobile.HttpService.Requests;
using OnlineApplicationMobile.HttpService.Responses;
using OnlineApplicationMobile.HttpService.Templates;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OnlineApplicationMobile.HttpService.Implementation
{
    public class ApplicationHttpService : BaseHttpService, IApplicationHttpService
    {
        /// <inheritdoc />
        public async Task<GetApplicationDetailCurrentClientJKHResponse> GetApplicationDetailCurrentClientJKH(GetApplicationDetailCurrentClientJKHRequest request)
        {
            using (var client = GetClientByHeaderAuthorization(request.Token))
            {
                var response = await client.GetAsync(string.Format(UrlTemplates.GetApplicationDetailCurrentClientJKHUrl, request.Id));

                var content = JsonSerializer.Deserialize<GetApplicationDetailCurrentClientJKHResponse>(await response.Content.ReadAsStringAsync(), optionsSerialize);
                content.StatusCode = response.StatusCode;

                return content;
            }
        }

        /// <inheritdoc />
        public async Task<GetApplicationsCurrentClientJKHResponse> GetApplicationsCurrentClientJKH(RequestBase request)
        {
            using (var client = GetClientByHeaderAuthorization(request.Token))
            {
                var response = await client.GetAsync(UrlTemplates.GetApplicationsCurrentClientJKHUrl);

                ResponseBase message = new ResponseBase();
                ApplicationShortDto[] applicationShortDtos = null;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    applicationShortDtos = JsonSerializer.Deserialize<ApplicationShortDto[]>(await response.Content.ReadAsStringAsync(), optionsSerialize);
                }
                else
                {
                    message = JsonSerializer.Deserialize<ResponseBase>(await response.Content.ReadAsStringAsync(), optionsSerialize);
                }

                return new GetApplicationsCurrentClientJKHResponse
                {
                    Message = message.Message,
                    StatusCode = response.StatusCode,
                    Applications = applicationShortDtos
                };
            }
        }

        public async Task<ResponseBase> PostApplication(PostApplicationRequest request)
        {
            using (var client = GetClientByHeaderAuthorization(request.Token))
            {
                var response = await client.PostAsync(UrlTemplates.PostApplicationUrl, new StringContent(
                    JsonSerializer.Serialize(request),
                    Encoding.UTF8, "application/json"));

                var content = JsonSerializer.Deserialize<ResponseBase>(await response.Content.ReadAsStringAsync(), optionsSerialize);
                content.StatusCode = response.StatusCode;

                return content;
            }
        }

        /// <inheritdoc />
        public async Task<ResponseBase> PostCommentApplication(PostCommentApplicationRequest request)
        {
            using (var client = GetClientByHeaderAuthorization(request.Token))
            {
                var response = await client.PostAsync(UrlTemplates.PostApplicationUrl, new StringContent(
                    JsonSerializer.Serialize(request),
                    Encoding.UTF8, "application/json"));

                var content = JsonSerializer.Deserialize<ResponseBase>(await response.Content.ReadAsStringAsync(), optionsSerialize);
                content.StatusCode = response.StatusCode;

                return content;
            }
        }
    }
}
