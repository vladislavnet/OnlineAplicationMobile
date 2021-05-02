using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineApplicationMobile.Domain.Entities
{
    /// <summary>
    /// Модель уровня объекта адреации.
    /// </summary>
    public class LevelAddressingObject
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
        /// Уровень.
        /// </summary>
        public int Level { get; set; }
    }
}
