using System;

namespace OnlineApplicationMobile.UI.ModelView
{
    /// <summary>
    /// Класс для отображения комментария заявки.
    /// </summary>
    public class CommentApplicationModelView
    {
        /// <summary>
        /// Имя автора.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия автора.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Комментарий.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Дата и время создания комментария.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Полное имя пользователя.
        /// </summary>
        public string FullName => $"{LastName} {FirstName}";
    }
}
