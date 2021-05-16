using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineApplicationMobile.Infrastructure.SqlLiteData.Repository.Interfaces
{
    public interface IUserInfoRepository
    {
        string GetToken();
        void SaveToken(string token);
    }
}
