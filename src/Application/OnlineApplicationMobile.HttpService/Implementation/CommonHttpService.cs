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
    public class CommonHttpService : BaseHttpService, ICommonHttpService
    {
        /// <inheritdoc />
        public SearchAddressingObjectsResponse GetSearchAddressingObjects(SearchAddressingObjectsRequest request)
        {
            using (var client = GetClientByHeaderAuthorization(request.Token))
            {
                var response = client.GetAsync(string.Format(UrlTemplates.GetSearchAddressingObjectsUrl, request.Name, request.Level)).Result;

                ResponseBase message = new ResponseBase();
                AddressingObjectShortDto[] addressingObjectShortDtos = null;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    addressingObjectShortDtos = JsonSerializer.Deserialize<AddressingObjectShortDto[]>(response.Content.ReadAsStringAsync().Result, optionsSerialize);
                }
                else
                {
                    message = JsonSerializer.Deserialize<ResponseBase>(response.Content.ReadAsStringAsync().Result, optionsSerialize);
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
        public GetTypesAddressingObjectResponse GetTypesAddressingObject(GetTypesAddressingObjectRequest request)
        {
            using (var client = GetClientByHeaderAuthorization(request.Token))
            {
                var response = client.GetAsync(string.Format(UrlTemplates.GetTypesAddressingObjectUrl, request.Level)).Result;

                ResponseBase message = new ResponseBase();
                TypeAddressingObjectDto[] typeAddressingObjectDtos = null;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    typeAddressingObjectDtos = JsonSerializer.Deserialize<TypeAddressingObjectDto[]>(response.Content.ReadAsStringAsync().Result, optionsSerialize);
                }
                else
                {
                    message = JsonSerializer.Deserialize<ResponseBase>(response.Content.ReadAsStringAsync().Result, optionsSerialize);
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
