using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineApplicationMobile.HttpService.Templates
{
    public static class UrlTemplates
    {
        public static string BaseUrl = "http://127.0.0.1:8000/";
        public static string LoginUrl = BaseUrl + "auth/token/login/";
        public static string GetInfoCurrentClientJKHUrl = BaseUrl + "api/v1/client-jkh/info/";
    }
}
