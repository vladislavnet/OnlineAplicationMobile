using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineApplicationMobile.HttpService.DTO
{
    /// <summary>
    /// Комментарий.
    /// </summary>
    public class CommentDto
    {
        /// <summary>
        /// Автор комментария.
        /// </summary>
        public UserCommentInformationDto Author { get; set; }

        /// <summary>
        /// Комментарий.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Дата создания комментария.
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}
