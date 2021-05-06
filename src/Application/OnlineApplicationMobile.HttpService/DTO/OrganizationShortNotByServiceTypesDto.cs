﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineApplicationMobile.HttpService.DTO
{
    /// <summary>
    /// Организация (Сокращённая) без типов сервисов которые она предоставляет.
    /// </summary>
    public class OrganizationShortNotByServiceTypesDto
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
        /// Email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Телефон.
        /// </summary>
        public string Telephone { get; set; }
    }
}
