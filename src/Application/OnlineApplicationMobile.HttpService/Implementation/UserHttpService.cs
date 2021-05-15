using OnlineApplicationMobile.HttpService.DTO;
using OnlineApplicationMobile.HttpService.Interfaces;
using OnlineApplicationMobile.HttpService.Requests;
using OnlineApplicationMobile.HttpService.Responses;
using OnlineApplicationMobile.HttpService.Templates;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineApplicationMobile.HttpService.Implementation
{
    public class UserHttpService : BaseHttpService, IUserHttpService
    {
        /// <inheritdoc />
        public AuthorizationResponse Authorization(AuthorizationRequest request)
        {
            using (var client = GetClient())
            {
                var response = client.PostAsync(UrlTemplates.LoginUrl, new StringContent(
                    JsonSerializer.Serialize(request),
                    Encoding.UTF8, "application/json")).Result;

                if (response.StatusCode != HttpStatusCode.OK)
                    return new AuthorizationResponse { StatusCode = response.StatusCode, Message = "Email или пароль введен неверно." };

                var authToken = JsonSerializer.Deserialize<AuthTokenDto>(response.Content.ReadAsStringAsync().Result, optionsSerialize);

                return new AuthorizationResponse
                {
                    StatusCode = response.StatusCode,
                    Token = authToken?.auth_token
                };
            }
        }

        /// <inheritdoc />
        public GetInfoCurrentClientJKHResponse GetInfoCurrentClientJKH(RequestBase request)
        {
            using (var client = GetClientByHeaderAuthorization(request.Token))
            {
                var response =  client.GetAsync(UrlTemplates.GetInfoCurrentClientJKHUrl).Result;

                var content = JsonSerializer.Deserialize<GetInfoCurrentClientJKHResponse>(response.Content.ReadAsStringAsync().Result, optionsSerialize);
                content.StatusCode = response.StatusCode;

                return content;
            }
        }

        /// <inheritdoc />
        public ResponseBase PutInfoCurrentClientJKH(PutInfoCurrentClientJKHRequest request)
        {
            using (var client = GetClientByHeaderAuthorization(request.Token))
            {
                var response = client.PutAsync(UrlTemplates.PutInfoCurrentClientJKHUrl, new StringContent(
                    JsonSerializer.Serialize(request),
                    Encoding.UTF8, "application/json")).Result;

                var content = JsonSerializer.Deserialize<ResponseBase>(response.Content.ReadAsStringAsync().Result, optionsSerialize);
                content.StatusCode = response.StatusCode;

                return content;
            }
        }

        /// <inheritdoc />
        public ResponseBase PostRegistrationClientJKH(PostRegistrationClientJKHRequest request)
        {
            using (var client = GetClient())
            {
                var response = client.PostAsync(UrlTemplates.PostRegistrationClientJKHUrl, new StringContent(
                    JsonSerializer.Serialize(request),
                    Encoding.UTF8, "application/json")).Result;

                var content = JsonSerializer.Deserialize<ResponseBase>(response.Content.ReadAsStringAsync().Result, optionsSerialize);
                content.StatusCode = response.StatusCode;

                return content;
            }
        }
    }
}
