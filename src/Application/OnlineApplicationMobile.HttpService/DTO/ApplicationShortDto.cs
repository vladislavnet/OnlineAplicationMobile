using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineApplicationMobile.HttpService.DTO
{
    /// <summary>
    /// Заявка (сокращённая)
    /// </summary>
    public class ApplicationShortDto
    {
        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Статус заявки.
        /// </summary>
        public int StatusApplication { get; set; }

        /// <summary>
        /// Текст обращения.
        /// </summary>
        public string MessageText { get; set; }

        /// <summary>
        /// Организация.
        /// </summary>
        public OrganizationShortNotByServiceTypesDto Organization { get; set; } 

        /// <summary>
        /// Номер лицевого счёта которому предоставляет организация услуги.
        /// </summary>
        public OrganizationNumberAccountNotByOrganization OrganizationNumberAccount { get; set; }

        /// <summary>
        /// Дата создания.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Дата редактирования.
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Типы услуг указанные в заявке.
        /// </summary>
        public ServiceTypeDto[] ServiceTypes { get; set; }
    }
}
