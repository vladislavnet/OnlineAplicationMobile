using OnlineApplicationMobile.Domain.Enums;
using OnlineApplicationMobile.HttpService.DTO;
using OnlineApplicationMobile.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineApplicationMobile.UI.ModelView
{
    /// <summary>
    /// Модель для отображения Истории заявки.
    /// </summary>
    public class HistoryApplicationModelView
    {
        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string FirtsName { get; set; }

        /// <summary>
        /// Фамилия пользователя.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Отчество пользователя.
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Статус заявка.
        /// </summary>
        public StatusApplication Status { get; set; }

        /// <summary>
        /// Дата создания.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Статус заявки ввиде строки.
        /// </summary>
        public string GetStatusString
        {
            get => StatusApplicationHelper.GetStatusApplicationString(Status);
        }


        public static IEnumerable<HistoryApplicationModelView> mapHistoryApplication(IEnumerable<HistoryApplicationDto> historyApplicationDtos)
        {
            if (historyApplicationDtos == null)
                return null;

            return historyApplicationDtos.Select(x => new HistoryApplicationModelView 
            {
                FirtsName = x.User?.FirtsName,
                LastName = x.User?.LastName,
                MiddleName = x.User?.MiddleName,
                Status = StatusApplicationHelper.GetStatusApplicationByInteger(x.StatusApplication),
                CreatedAt = x.CreatedAt
            });
        }

        public static DateTime? GetUpdatedAt(IEnumerable<HistoryApplicationModelView> historyApplication)
        {
            return historyApplication?.OrderByDescending(x => x.CreatedAt).FirstOrDefault()?.CreatedAt;
        }
    }
}
