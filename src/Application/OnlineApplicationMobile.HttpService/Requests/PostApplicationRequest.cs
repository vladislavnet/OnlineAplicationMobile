using OnlineApplicationMobile.HttpService.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineApplicationMobile.HttpService.Requests
{
    /// <summary>
    /// Запрос на добавление заявки.
    /// </summary>
    public class PostApplicationRequest : RequestBase
    {
        /// <summary>
        /// Текст обращения.
        /// </summary>
        public string MessageText { get; set; }

        /// <summary>
        /// Номер счёта.
        /// </summary>
        public string NumberAccount { get; set; }

        /// <summary>
        /// Имя ответсвенного плательщика.
        /// </summary>
        public string FirstNamePayer { get; set; }

        /// <summary>
        /// Фамилия ответсвенного плательщика.
        /// </summary>
        public string LastNamePayer { get; set; }

        /// <summary>
        /// Отчество ответсвенного плательщика.
        /// </summary>
        public string MiddleNamePayer { get; set; }

        /// <summary>
        /// Уникальный идентификатор организации.
        /// </summary>
        public int OrganizationId { get; set; }

        /// <summary>
        /// Выбранные типы услуг.
        /// </summary>
        public ServiceTypeDto[] ServiseTypes { get; set; }
    }
}
