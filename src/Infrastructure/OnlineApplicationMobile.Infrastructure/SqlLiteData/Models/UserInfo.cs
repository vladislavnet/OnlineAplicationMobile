using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineApplicationMobile.Infrastructure.SqlLiteData.Models
{
    [Table("UserInfo")]
    public class UserInfo 
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Token { get; set; }
    }
}
