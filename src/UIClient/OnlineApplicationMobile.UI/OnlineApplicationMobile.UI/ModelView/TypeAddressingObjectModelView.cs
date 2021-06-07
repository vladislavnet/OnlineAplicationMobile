using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineApplicationMobile.UI.ModelView
{
    /// <summary>
    /// Модель для отображения типа адресного объекта.
    /// </summary>
    public class TypeAddressingObjectModelView
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

        public override string ToString()
        {
            return ShortName;
        }
    }
}
