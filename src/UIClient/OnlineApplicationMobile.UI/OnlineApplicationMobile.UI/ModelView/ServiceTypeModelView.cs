using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineApplicationMobile.UI.ModelView
{
    /// <summary>
    /// Класс для отображения типа сервиса.
    /// </summary>
    public class ServiceTypeModelView
    {
        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование.
        /// </summary>
        public string Title { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
