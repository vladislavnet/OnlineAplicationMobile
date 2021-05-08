using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineApplicationMobile.HttpService.Requests
{
    /// <summary>
    /// Запрос получения детальной информации заявки текущего пользователя.
    /// </summary>
    public class GetApplicationDetailCurrentClientJKHRequest : RequestBase
    {
        /// <summary>
        /// Уникальный идентификатор заявки.
        /// </summary>
        public Guid Id { get; set; }
    }
}
