using OnlineApplicationMobile.HttpService.DTO;
using OnlineApplicationMobile.HttpService.Interfaces;
using OnlineApplicationMobile.HttpService.Requests;
using OnlineApplicationMobile.HttpService.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineApplicationMobile.HttpService.Implementation
{
    public class CommonHttpService : ICommonHttpService
    {
        public SearchAddressingObjectsResponse GetSearchAddressingObjects(SearchAddressingObjectsRequest request)
        {
            return new SearchAddressingObjectsResponse
            { 
                addressingObjectsShort = new AddressingObjectShortDto[3]
                {
                    new AddressingObjectShortDto { Name = "Test1" },
                    new AddressingObjectShortDto { Name = "Test2" },
                    new AddressingObjectShortDto { Name = "Test3" }
                },
            };
        }
    }
}
