using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineApplicationMobile.Infrastructure.RealmData.Models
{
    public class UserInfo : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Token { get; set; }
    }
}
