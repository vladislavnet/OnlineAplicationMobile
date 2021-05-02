using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineApplicationMobile.Domain.Entities
{
    /// <summary>
    /// Модель клиента ЖКХ.
    /// </summary>
    public class ClientJKH
    {
        /// <summary>
        /// Пользователь.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Номер лицевого счёта.
        /// </summary>
        public string NumberPersonalAccount { get; set; }

        /// <summary>
        /// Адрес.
        /// </summary>
        public Address Address { get; set; }
    }
}
