using OnlineApplicationMobile.HttpService.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineApplicationMobile.HttpService.Responses
{
    public class GetTypesAddressingObjectResponse : ResponseBase
    {
        public TypeAddressingObjectDto[] TypesAddressingObject { get; set; }
    }
}
