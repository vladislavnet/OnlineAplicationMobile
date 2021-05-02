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
        public Guid Id { get; private set; }

        /// <summary>
        /// Email.
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string FirstName { get; private set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string LastName { get; private set; }

        /// <summary>
        /// Отчество.
        /// </summary>
        public string MiddleName { get; private set; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime? BirthDate { get; private set; }

        /// <summary>
        /// Телефон.
        /// </summary>
        public string Telephone { get; private set; }

        /// <summary>
        /// Является ли пользователем подтверждённым.
        /// </summary>
        public bool IsConfirmed { get; private set; }
    }
}
