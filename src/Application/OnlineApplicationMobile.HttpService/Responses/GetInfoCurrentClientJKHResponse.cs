using OnlineApplicationMobile.Domain.Entities;
using OnlineApplicationMobile.HttpService.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineApplicationMobile.HttpService.Responses
{
    /// <summary>
    /// Ответ сервера на запрос на получения текущей информации пользователя.
    /// </summary>
    public class GetInfoCurrentClientJKHResponse : ResponseBase
    {
        /// <summary>
        /// Пользователь.
        /// </summary>
        public UserDto User { get; set; }

        /// <summary>
        /// Номер лицевого счёта.
        /// </summary>
        public string NumberPersonalAccount { get; set; }

        /// <summary>
        /// Адрес.
        /// </summary>
        public AddressDto Address { get; set; }
    }
}
