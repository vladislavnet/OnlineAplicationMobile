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
        public GetApplicationDetailCurrentClientJKHResponse GetApplicationDetailCurrentClientJKH(GetApplicationDetailCurrentClientJKHRequest request)
        {
            using (var client = GetClientByHeaderAuthorization(request.Token))
            {
                var response = client.GetAsync(string.Format(UrlTemplates.GetApplicationDetailCurrentClientJKHUrl, request.Id)).Result;

                var content = JsonSerializer.Deserialize<GetApplicationDetailCurrentClientJKHResponse>(response.Content.ReadAsStringAsync().Result, optionsSerialize);
                content.StatusCode = response.StatusCode;

                return content;
            }
        }

        /// <inheritdoc />
        public GetApplicationsCurrentClientJKHResponse GetApplicationsCurrentClientJKH(RequestBase request)
        {
            using (var client = GetClientByHeaderAuthorization(request.Token))
            {
                var response = client.GetAsync(UrlTemplates.GetApplicationsCurrentClientJKHUrl).Result;

                ResponseBase message = new ResponseBase();
                ApplicationShortDto[] applicationShortDtos = null;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    applicationShortDtos = JsonSerializer.Deserialize<ApplicationShortDto[]>(response.Content.ReadAsStringAsync().Result, optionsSerialize);
                }
                else
                {
                    message = JsonSerializer.Deserialize<ResponseBase>(response.Content.ReadAsStringAsync().Result, optionsSerialize);
                }

                return new GetApplicationsCurrentClientJKHResponse
                {
                    Message = message.Message,
                    StatusCode = response.StatusCode,
                    Applications = applicationShortDtos
                };
            }
        }

        public ResponseBase PostApplication(PostApplicationRequest request)
        {
            using (var client = GetClientByHeaderAuthorization(request.Token))
            {
                var response = client.PostAsync(UrlTemplates.PostApplicationUrl, new StringContent(
                    JsonSerializer.Serialize(request),
                    Encoding.UTF8, "application/json")).Result;

                var content = JsonSerializer.Deserialize<ResponseBase>(response.Content.ReadAsStringAsync().Result, optionsSerialize);
                content.StatusCode = response.StatusCode;

                return content;
            }
        }

        /// <inheritdoc />
        public ResponseBase PostCommentApplication(PostCommentApplicationRequest request)
        {
            using (var client = GetClientByHeaderAuthorization(request.Token))
            {
                var response = client.PostAsync(UrlTemplates.PostCommentApplicationUrl, new StringContent(
                    JsonSerializer.Serialize(request),
                    Encoding.UTF8, "application/json")).Result;

                var content = JsonSerializer.Deserialize<ResponseBase>(response.Content.ReadAsStringAsync().Result, optionsSerialize);
                content.StatusCode = response.StatusCode;

                return content;
            }
        }
    }
}
