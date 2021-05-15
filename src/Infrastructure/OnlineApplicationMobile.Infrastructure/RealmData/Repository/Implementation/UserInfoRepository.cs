using OnlineApplicationMobile.Infrastructure.RealmData.Models;
using OnlineApplicationMobile.Infrastructure.RealmData.Repository.Interfaces;
using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineApplicationMobile.Infrastructure.RealmData.Repository.Implementation
{
    public class UserInfoRepository : IUserInfoRepository
    {
        private readonly Realm _realm;
        public UserInfoRepository()
        {
            Realm.GetInstance();
        }

        public string GetToken()
        {
            return _realm.Find<UserInfo>(1).Token;
        }

        public void SaveToken(string token)
        {
            var userInfo = _realm.Find<UserInfo>(1);

            if (userInfo == null)
            {
                userInfo = new UserInfo
                {
                    Id = 1,
                    Token = token
                };

                _realm.Write(() => _realm.Add(userInfo));

                return;
            }

            _realm.Write(() => userInfo.Token = token);
        }
    }
}
