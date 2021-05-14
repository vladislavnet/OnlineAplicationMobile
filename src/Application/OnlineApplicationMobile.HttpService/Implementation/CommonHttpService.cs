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
    public class CommonHttpService : BaseHttpService, ICommonHttpService
    {
        /// <inheritdoc />
        public async Task<SearchAddressingObjectsResponse> GetSearchAddressingObjects(SearchAddressingObjectsRequest request)
        {
            using (var client = GetClientByHeaderAuthorization(request.Token))
            {
                var response = await client.GetAsync(UrlTemplates.GetInfoCurrentClientJKHUrl);

                ResponseBase message = new ResponseBase();
                AddressingObjectShortDto[] addressingObjectShortDtos = null;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    addressingObjectShortDtos = JsonSerializer.Deserialize<AddressingObjectShortDto[]>(await response.Content.ReadAsStringAsync(), optionsSerialize);
                }
                else
                {
                    message = JsonSerializer.Deserialize<ResponseBase>(await response.Content.ReadAsStringAsync(), optionsSerialize);
                }

                return new SearchAddressingObjectsResponse 
                {
                    Message = message.Message,
                    StatusCode = response.StatusCode,
                    addressingObjectsShort = addressingObjectShortDtos
                };
            }
        }

        /// <inheritdoc />
        public async Task<GetTypesAddressingObjectResponse> GetTypesAddressingObject(GetTypesAddressingObjectRequest request)
        {
            using (var client = GetClientByHeaderAuthorization(request.Token))
            {
                var response = await client.GetAsync(UrlTemplates.GetInfoCurrentClientJKHUrl);

                ResponseBase message = new ResponseBase();
                TypeAddressingObjectDto[] typeAddressingObjectDtos = null;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    typeAddressingObjectDtos = JsonSerializer.Deserialize<TypeAddressingObjectDto[]>(await response.Content.ReadAsStringAsync(), optionsSerialize);
                }
                else
                {
                    message = JsonSerializer.Deserialize<ResponseBase>(await response.Content.ReadAsStringAsync(), optionsSerialize);
                }

                return new GetTypesAddressingObjectResponse
                {
                    Message = message.Message,
                    StatusCode = response.StatusCode,
                    TypesAddressingObject = typeAddressingObjectDtos
                };
            }
        }
    }
}
