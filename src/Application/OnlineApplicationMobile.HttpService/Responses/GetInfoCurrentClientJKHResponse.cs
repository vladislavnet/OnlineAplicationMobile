using OnlineApplicationMobile.Domain.Entities;
using OnlineApplicationMobile.HttpService.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

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
        [JsonPropertyName("user")]
        public UserDto User { get; set; }

        /// <summary>
        /// Номер лицевого счёта.
        /// </summary>
        [JsonPropertyName("numberPersonalAccount")]
        public string NumberPersonalAccount { get; set; }

        /// <summary>
        /// Адрес.
        /// </summary>
        [JsonPropertyName("address")]
        public AddressDto Address { get; set; }
    }
}
