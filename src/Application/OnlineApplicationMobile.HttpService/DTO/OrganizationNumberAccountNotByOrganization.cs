using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineApplicationMobile.HttpService.DTO
{
    /// <summary>
    /// Номер счёта которому организация предоставляет услуги.
    /// </summary>
    public class OrganizationNumberAccountNotByOrganization
    {
        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Номер счёта.
        /// </summary>
        public string NumberAccount { get; set; }

        /// <summary>
        /// Имя отвественного плательщика.
        /// </summary>
        public string FirstNamePayer { get; set; }

        /// <summary>
        /// Фамилия отвественного плательщика.
        /// </summary>
        public string LastNamePayer { get; set; }

        /// <summary>
        /// Отчество отвественного плательщика.
        /// </summary>
        public string MiddleNamePayer { get; set; }
    }
}
