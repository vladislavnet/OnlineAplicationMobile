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
    public class ApplicationHttpService : IApplicationHttpService
    {
        /// <inheritdoc />
        public GetApplicationDetailCurrentClientJKHResponse GetApplicationDetailCurrentClientJKH(GetApplicationDetailCurrentClientJKHRequest request)
        {
            return new GetApplicationDetailCurrentClientJKHResponse
            {
                StatusCode = HttpStatusCode.OK,
                Id = Guid.NewGuid(),
                StatusApplication = 1,
                MessageText = "Test #1",
                Organization = new OrganizationShortNotByServiceTypesDto
                {
                    Id = 1,
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
                },
                Comments = new CommentDto[] 
                {
                    new CommentDto
                    {
                        Author = new UserCommentInformationDto
                        {
                            Id = Guid.NewGuid(),
                            FirtsName = "FirstNameTestCommentUser#1",
                            LastName = "FirstNameTestCommentUser#1",
                        },
                        Comment = "Test Commentttttttttttttttttttttttttttttttttttttttttttttt #1",
                        CreatedAt = DateTime.Now,
                    },
                    new CommentDto
                    {
                        Author = new UserCommentInformationDto
                        {
                            Id = Guid.NewGuid(),
                            FirtsName = "FirstNameTestCommentUser#2",
                            LastName = "FirstNameTestCommentUser#2",
                        },
                        Comment = "Test Commentttttttttttttttttttttttttttttttttttttttttttttt #2",
                        CreatedAt = DateTime.Now,
                    }
                }
            };
        }

        /// <inheritdoc />
        public GetApplicationsCurrentClientJKHResponse GetApplicationsCurrentClientJKH(RequestBase request)
        {
            return new GetApplicationsCurrentClientJKHResponse()
            {
                StatusCode = HttpStatusCode.Forbidden,
                Applications = new ApplicationShortDto[]
                {
                    new ApplicationShortDto
                    {
                        Id = Guid.NewGuid(),
                        StatusApplication = 1,
                        MessageText = "Test #1",
                        Organization = new OrganizationShortNotByServiceTypesDto
                        {
                            Id = 1,
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
                            Id = 1,
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

        public ResponseBase PostApplication(PostApplicationRequest request)
        {
            return new ResponseBase { StatusCode = HttpStatusCode.OK };
        }

        /// <inheritdoc />
        public ResponseBase PostCommentApplication(PostCommentApplicationRequest request)
        {
            return new ResponseBase { StatusCode = HttpStatusCode.OK };
        }
    }
}
