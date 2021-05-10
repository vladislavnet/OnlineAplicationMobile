using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace OnlineApplicationMobile.HttpService.DTO
{
    public class AddressDto
    {
        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Адресный объект.
        /// </summary>
        [JsonPropertyName("addressingObject")]
        public AddressingObjectDto AddressingObject { get; set; }

        /// <summary>
        /// Номер дома.
        /// </summary>
        [JsonPropertyName("houseNumber")]
        public string HouseNumber { get; set; }

        /// <summary>
        /// Номер квартиры.
        /// </summary>
        [JsonPropertyName("numberApartament")]
        public string NumberApartament { get; set; }
    }
}
