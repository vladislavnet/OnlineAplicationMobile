using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineApplicationMobile.HttpService.DTO
{
    /// <summary>
    /// Тип адресного объекта.
    /// </summary>
    public class TypeAddressingObjectDto
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
        public LevelAddressingObjectDto Level { get; set; }
    }
}
