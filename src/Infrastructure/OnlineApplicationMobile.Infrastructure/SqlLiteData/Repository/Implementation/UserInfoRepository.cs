using OnlineApplicationMobile.Infrastructure.SqlLiteData.Models;
using OnlineApplicationMobile.Infrastructure.SqlLiteData.Repository.Interfaces;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineApplicationMobile.Infrastructure.SqlLiteData.Repository.Implementation
{
    public class UserInfoRepository : IUserInfoRepository
    {
        private readonly ConfigurationSqlLite _configurationSqlLite;
        private readonly SQLiteConnection database;
        public UserInfoRepository(ConfigurationSqlLite configurationSqlLite)
        {
            _configurationSqlLite = configurationSqlLite;

            database = new SQLiteConnection(configurationSqlLite.DatabasePath);
            database.CreateTable<UserInfo>();
        }

        public string GetToken()
        {
            return database.Table<UserInfo>().FirstOrDefault(x => x.Id == 1)?.Token;
        }

        public void SaveToken(string token)
        {
            var userInfo = database.Table<UserInfo>().FirstOrDefault(x => x.Id == 1);

            if (userInfo == null)
            {
                userInfo = new UserInfo
                {
                    Id = 1,
                    Token = token
                };

                database.Insert(userInfo);

                return;
            }

            userInfo.Token = token;

            database.Update(userInfo);
        }
    }
}
