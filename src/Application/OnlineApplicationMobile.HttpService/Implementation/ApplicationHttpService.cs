using OnlineApplicationMobile.HttpService.DTO;
using OnlineApplicationMobile.HttpService.Interfaces;
using OnlineApplicationMobile.HttpService.Requests;
using OnlineApplicationMobile.HttpService.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineApplicationMobile.HttpService.Implementation
{
    public class ApplicationHttpService : IApplicationHttpService
    {
        /// <inheritdoc />
        public GetApplicationsCurrentClientJKHResponse GetApplicationsCurrentClientJKH(RequestBase request)
        {
            return new GetApplicationsCurrentClientJKHResponse()
            {
                Applications = new ApplicationShortDto[]
                {
                    new ApplicationShortDto
                    {
                        Id = Guid.NewGuid(),
                        StatusApplication = 1,
                        MessageText = "Test #1",
                        Organization = new OrganizationShortNotByServiceTypesDto
                        {
                            Id = Guid.NewGuid(),
                            Name = "Test org #1",
                            Description = "Test org description #1,",
                            Email = "Test1@common.com",
                            Telephone = "890000000000",
                        },
                        OrganizationNumberAccount = new OrganizationNumberAccountNotByOrganization
                        {
                            Id = 1,
                            NumberAccount = "1111111111",
                            FirstNamePayer = "Test Name FirstPayer #1",
                            LastNamePayer = "Test LastName Payer #1",
                            MiddleNamePayer = "Test LastName Payer #1",
                        },
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        ServiceTypes = new ServiceTypeDto[]
                        {
                            new ServiceTypeDto
                            {
                                Id = 1,
                                Title = "Test Type #1"
                            },
                            new ServiceTypeDto
                            {
                                Id = 2,
                                Title = "Test Type #2"
                            },
                        }
                    },
                    new ApplicationShortDto
                    {
                        Id = Guid.NewGuid(),
                        StatusApplication = 1,
                        MessageText = "Test #2",
                        Organization = new OrganizationShortNotByServiceTypesDto
                        {
                            Id = Guid.NewGuid(),
                            Name = "Test org #2",
                            Description = "Test org description #2,",
                            Email = "Test2@common.com",
                            Telephone = "890000000001",
                        },
                        OrganizationNumberAccount = new OrganizationNumberAccountNotByOrganization
                        {
                            Id = 1,
                            NumberAccount = "2222222222",
                            FirstNamePayer = "Test Name FirstPayer #2",
                            LastNamePayer = "Test LastName Payer #2",
                            MiddleNamePayer = "Test LastName Payer #2",
                        },
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        ServiceTypes = new ServiceTypeDto[]
                        {
                            new ServiceTypeDto
                            {
                                Id = 1,
                                Title = "Test Type #1"
                            },
                            new ServiceTypeDto
                            {
                                Id = 2,
                                Title = "Test Type #2"
                            },
                        }
                    },
                }
            };
        }
    }
}
