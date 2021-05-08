using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineApplicationMobile.UI.ModelView
{
    /// <summary>
    /// Класс для отображения информации об организации.
    /// </summary>
    public class OrganizationModelView
    {
        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Email организации.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Телефон.
        /// </summary>
        public string Telephone { get; set; }

        /// <summary>
        /// Типы предоставляемых услуг организацией.
        /// </summary>
        public List<ServiceTypeModelView> ServiceTypes { get; set; }
    }
}
