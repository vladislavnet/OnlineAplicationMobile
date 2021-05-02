using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineApplicationMobile.HttpService.DTO
{
    public class AddressDto
    {
        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Адресный объект.
        /// </summary>
        public AddressingObjectDto AddressingObject { get; set; }

        /// <summary>
        /// Номер дома.
        /// </summary>
        public string HouseNumber { get; set; }

        /// <summary>
        /// Номер квартиры.
        /// </summary>
        public string NumberApartament { get; set; }
    }
}
