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
using System.Threading.Tasks;

namespace OnlineApplicationMobile.HttpService.Implementation
{
    public class UserHttpService : BaseHttpService, IUserHttpService
    {
        /// <inheritdoc />
        public async Task<AuthorizationResponse> Authorization(AuthorizationRequest request)
        {
            using (var client = GetClient())
            {
                var response = await client.PostAsync(UrlTemplates.LoginUrl, new StringContent(
                    JsonSerializer.Serialize(request),
                    Encoding.UTF8, "application/json"));

                if (response.StatusCode != HttpStatusCode.OK)
                    return new AuthorizationResponse { StatusCode = response.StatusCode, Message = "Email или пароль введен неверно." };

                var authToken = JsonSerializer.Deserialize<AuthTokenDto>(await response.Content.ReadAsStringAsync(), optionsSerialize);

                return new AuthorizationResponse
                {
                    StatusCode = response.StatusCode,
                    Token = authToken?.auth_token
                };
            }
        }

        /// <inheritdoc />
        public async Task<GetInfoCurrentClientJKHResponse> GetInfoCurrentClientJKH(RequestBase request)
        {
            using (var client = GetClientByHeaderAuthorization(request.Token))
            {
                var response = await client.GetAsync(UrlTemplates.GetInfoCurrentClientJKHUrl);

                var content = JsonSerializer.Deserialize<GetInfoCurrentClientJKHResponse>(await response.Content.ReadAsStringAsync(), optionsSerialize);
                content.StatusCode = response.StatusCode;

                return content;
            }
        }

        /// <inheritdoc />
        public async Task<ResponseBase> PutInfoCurrentClientJKH(PutInfoCurrentClientJKHRequest request)
        {
            using (var client = GetClientByHeaderAuthorization(request.Token))
            {
                var response = await client.PutAsync(UrlTemplates.PutInfoCurrentClientJKHUrl, new StringContent(
                    JsonSerializer.Serialize(request),
                    Encoding.UTF8, "application/json"));

                var content = JsonSerializer.Deserialize<ResponseBase>(await response.Content.ReadAsStringAsync(), optionsSerialize);
                content.StatusCode = response.StatusCode;

                return content;
            }
        }

        /// <inheritdoc />
        public async Task<ResponseBase> PostRegistrationClientJKH(PostRegistrationClientJKHRequest request)
        {
            using (var client = GetClientByHeaderAuthorization(request.Token))
            {
                var response = await client.PostAsync(UrlTemplates.PostRegistrationClientJKHUrl, new StringContent(
                    JsonSerializer.Serialize(request),
                    Encoding.UTF8, "application/json"));

                var content = JsonSerializer.Deserialize<ResponseBase>(await response.Content.ReadAsStringAsync(), optionsSerialize);
                content.StatusCode = response.StatusCode;

                return content;
            }
        }
    }
}
