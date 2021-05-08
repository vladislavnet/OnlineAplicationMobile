using OnlineApplicationMobile.HttpService.Requests;
using OnlineApplicationMobile.HttpService.Responses;

namespace OnlineApplicationMobile.HttpService.Interfaces
{
    public interface IApplicationHttpService
    {
        /// <summary>
        /// Получение заявок текущего клиента ЖКХ.
        /// </summary>
        /// <param name="request">Запрос.</param>
        /// <returns>Ответ.</returns>
        GetApplicationsCurrentClientJKHResponse GetApplicationsCurrentClientJKH(RequestBase request);

        /// <summary>
        /// Получение детильной информации заявки текущего клиента ЖКХ.
        /// </summary>
        /// <param name="request">Запрос.</param>
        /// <returns>Ответ.</returns>
        GetApplicationDetailCurrentClientJKHResponse GetApplicationDetailCurrentClientJKH(GetApplicationDetailCurrentClientJKHRequest request);

        /// <summary>
        /// Добавление комментария к заявке.
        /// </summary>
        /// <param name="request">Запрос.</param>
        /// <returns>Ответ.</returns>
        ResponseBase PostCommentApplication(PostCommentApplicationRequest request);
    }
}
