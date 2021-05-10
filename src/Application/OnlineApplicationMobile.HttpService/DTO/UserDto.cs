using System;
using System.Text.Json.Serialization;

namespace OnlineApplicationMobile.HttpService.DTO
{
    public class UserDto
    {
        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        [JsonPropertyName("id")]
        public Guid Id { get; private set; }

        /// <summary>
        /// Email.
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; private set; }

        /// <summary>
        /// Имя.
        /// </summary>
        [JsonPropertyName("firstName")]
        public string FirstName { get; private set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        [JsonPropertyName("lastName")]
        public string LastName { get; private set; }

        /// <summary>
        /// Отчество.
        /// </summary>
        [JsonPropertyName("middleName")]
        public string MiddleName { get; private set; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        [JsonPropertyName("birthDate")]
        public DateTime? BirthDate { get; private set; }

        /// <summary>
        /// Телефон.
        /// </summary>
        [JsonPropertyName("telephone")]
        public string Telephone { get; private set; }
    }
}
