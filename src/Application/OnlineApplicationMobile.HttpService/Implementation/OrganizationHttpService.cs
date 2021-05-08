using OnlineApplicationMobile.HttpService.DTO;
using OnlineApplicationMobile.HttpService.Interfaces;
using OnlineApplicationMobile.HttpService.Requests;
using OnlineApplicationMobile.HttpService.Responses;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace OnlineApplicationMobile.HttpService.Implementation
{
    public class OrganizationHttpService : IOrganizationHttpService
    {
        /// <inheritdoc />
        public GetOrganizationsByUserResponse GetOrganizationsByUser(RequestBase request)
        {
            return new GetOrganizationsByUserResponse
            {
                StatusCode = HttpStatusCode.OK,
                Organizations = new OrganizationShortDto[]
                {
                    new OrganizationShortDto
                    {
                        Id = Guid.NewGuid(),
                        Name = "Test org #1",
                        Description = "Test org description #1,",
                        Email = "Test1@common.com",
                        Telephone = "890000000001",
                        ServiceTypes = new ServiceTypeDto[]
                        {
                            new ServiceTypeDto
                            {
                                Id = 1,
                                Title = "Test Service #1"
                            },
                            new ServiceTypeDto
                            {
                                Id = 2,
                                Title = "Test Service #2"
                            },
                        }
                    },
                    new OrganizationShortDto
                    {
                        Id = Guid.NewGuid(),
                        Name = "Test org #2",
                        Description = "Test org description #2,",
                        Email = "Test1@common.com",
                        Telephone = "890000000001",
                        ServiceTypes = new ServiceTypeDto[]
                        {
                            new ServiceTypeDto
                            {
                                Id = 1,
                                Title = "Test Service #1"
                            },
                            new ServiceTypeDto
                            {
                                Id = 2,
                                Title = "Test Service #2"
                            },
                        }
                    }
                }
            };
        }
    }
}
