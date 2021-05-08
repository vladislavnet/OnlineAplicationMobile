using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineApplicationMobile.HttpService.Requests
{
    /// <summary>
    /// Запрос на добавления комментария заявки.
    /// </summary>
    public class PostCommentApplicationRequest : RequestBase
    {
        /// <summary>
        /// Уникальный идентификатор заявки.
        /// </summary>
        public Guid ApplicationId { get; set; }

        /// <summary>
        /// Комментарий для заявки.
        /// </summary>
        public string Comment { get; set; }
    }
}
