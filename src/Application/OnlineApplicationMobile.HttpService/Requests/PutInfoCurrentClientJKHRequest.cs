using OnlineApplicationMobile.HttpService.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineApplicationMobile.HttpService.Requests
{
    /// <summary>
    /// Запрос на обновление информации текущего пользователя.
    /// </summary>
    public class PutInfoCurrentClientJKHRequest : RequestBase
    {
        /// <summary>
        /// Имя.
        /// </summary>
        public string FirstName { get; private set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string LastName { get; private set; }

        /// <summary>
        /// Отчество.
        /// </summary>
        public string MiddleName { get; private set; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime? BirthDate { get; private set; }

        /// <summary>
        /// Телефон.
        /// </summary>
        public string Telephone { get; private set; }

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
