using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineApplicationMobile.HttpService.DTO
{
    /// <summary>
    /// Адресный объект (Сокращенный).
    /// </summary>
    public class AddressingObjectShortDto
    {
        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Тип адресного объекта.
        /// </summary>
        public TypeAddressingObjectDto Type { get; set; }
    }
}
