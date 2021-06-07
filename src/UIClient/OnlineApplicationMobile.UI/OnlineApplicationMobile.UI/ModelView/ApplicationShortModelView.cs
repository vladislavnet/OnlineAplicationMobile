using OnlineApplicationMobile.Domain.Enums;
using OnlineApplicationMobile.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineApplicationMobile.UI.ModelView
{
    /// <summary>
    /// Модель для отображения типа заявки (сокращенная).
    /// </summary>
    public class ApplicationShortModelView
    {
        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование организации.
        /// </summary>
        public string OrganizationName { get; set; }

        /// <summary>
        /// Текст обращения.
        /// </summary>
        public string MessageText { get; set; }

        /// <summary>
        /// Дата создания.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Дата обновления.
        /// </summary>
        public DateTime? UpdatedAt 
        {
            get => HistoryApplicationModelView.GetUpdatedAt(HistoryApplication);
        }

        /// <summary>
        /// Статус заявка.
        /// </summary>
        public StatusApplication Status { get; set; }

        /// <summary>
        /// История заявки.
        /// </summary>
        public IEnumerable<HistoryApplicationModelView> HistoryApplication { get; set; }

        /// <summary>
        /// Статус заявки ввиде строки.
        /// </summary>
        public string GetStatusString
        {
            get => StatusApplicationHelper.GetStatusApplicationString(Status);
        }
    }
}
