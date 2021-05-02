using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineApplicationMobile.HttpService.DTO
{
    /// <summary>
    /// Уровень адресного объекта.
    /// </summary>
    public class LevelAddressingObjectDto
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
