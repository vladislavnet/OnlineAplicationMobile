using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineApplicationMobile.HttpService.Templates
{
    public static class UrlTemplates
    {
        public static string BaseUrl = "https://online-applications.herokuapp.com/";
        public static string LoginUrl = BaseUrl + "auth/token/login/";
        public static string GetInfoCurrentClientJKHUrl = BaseUrl + "api/v1/client-jkh/info/";
        public static string PutInfoCurrentClientJKHUrl = BaseUrl + "api/v1/client-jkh/update/";
        public static string PostRegistrationClientJKHUrl = BaseUrl + "api/v1/client-jkh/register/";
        public static string GetTypesAddressingObjectUrl = BaseUrl + "api/v1/types-addressing-object/?level={0}";
        public static string GetSearchAddressingObjectsUrl = BaseUrl + "api/v1/addressing-object/search/?level={0}&name={1}";
        public static string GetApplicationDetailCurrentClientJKHUrl = BaseUrl + "api/v1/client-jkh/applications/{0}/";
        public static string GetApplicationsCurrentClientJKHUrl = BaseUrl + "api/v1/client-jkh/applications/";
        public static string PostApplicationUrl = BaseUrl + "api/v1/client-jkh/add-application/";
        public static string PostCommentApplicationUrl = BaseUrl + "api/v1/application/comment/";
        public static string GetOrganizationsByUserUrl = BaseUrl + "api/v1/client-jkh/organizations/";
        public static string GetSearchGlobalOrganizationsUrl = BaseUrl + "api/v1/organization/search/?searchText={0}";
        public static string PutRevokeApplicationUrl = BaseUrl + "api/v1/client-jkh/revoke-application/{0}/";
    }
}
