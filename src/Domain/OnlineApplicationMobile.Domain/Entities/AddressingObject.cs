using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineApplicationMobile.Domain.Entities
{
    /// <summary>
    /// Модель адресного объекта.
    /// </summary>
    public class AddressingObject
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
        /// Родитель.
        /// </summary>
        public AddressingObject Parent { get; set; }

        /// <summary>
        /// Тип адресного объекта.
        /// </summary>
        public TypeAddressingObject Type { get; set; }
    }
}
