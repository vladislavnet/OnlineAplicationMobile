using OnlineApplicationMobile.HttpService.Requests;
using OnlineApplicationMobile.HttpService.Responses;
using System.Threading.Tasks;

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

        /// <summary>
        /// Добавление заявки.
        /// </summary>
        /// <param name="request">Запрос.</param>
        /// <returns>Ответ.</returns>
        ResponseBase PostApplication(PostApplicationRequest request);


        /// <summary>
        /// Отозывание заявки.
        /// </summary>
        /// <param name="request">Запрос.</param>
        /// <returns>Ответ.</returns>
        ResponseBase PutRevokeApplication(PutRevokeApplicationRequest request);
    }
}
