using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineApplicationMobile.Domain.Entities
{
    /// <summary>
    /// Тип адресного объекта.
    /// </summary>
    public class TypeAddressingObject
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
        /// Короткое наименование.
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// Уровень объекта адресации.
        /// </summary>
        public LevelAddressingObject Level { get; set; }
    }
}
