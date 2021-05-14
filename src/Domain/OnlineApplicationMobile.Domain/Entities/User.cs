using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineApplicationMobile.Domain.Entities
{
    /// <summary>
    /// Модель пользователя.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Отчество.
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Телефон.
        /// </summary>
        public string Telephone { get; set; }

        /// <summary>
        /// Является ли пользователем подтверждённым.
        /// </summary>
        public bool IsConfirmed { get; set; }
    }
}
