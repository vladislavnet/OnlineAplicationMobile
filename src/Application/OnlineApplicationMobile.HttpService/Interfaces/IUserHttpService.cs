using OnlineApplicationMobile.HttpService.Requests;
using OnlineApplicationMobile.HttpService.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineApplicationMobile.HttpService.Interfaces
{
    public interface IUserHttpService
    {
        /// <summary>
        /// Получение информации по текущему клиенту ЖКХ.
        /// </summary>
        /// <param name="request">Запрос на получение информации.</param>
        /// <returns>Ответ на получение информации.</returns>
        GetInfoCurrentClientJKHResponse GetInfoCurrentClientJKH(RequestBase request);

        /// <summary>
        /// Авторизация пользователя.
        /// </summary>
        /// <param name="request">Запрос на авторизацию.</param>
        /// <returns>Ответ на авторизацию.</returns>
        AuthorizationResponse Authorization(AuthorizationRequest request);

        /// <summary>
        /// Обновление информации текущего пользователя.
        /// </summary>
        /// <param name="request">Запрос.</param>
        /// <returns>Ответ.</returns>
        ResponseBase PutInfoCurrentClientJKH(PutInfoCurrentClientJKHRequest request);

        /// <summary>
        /// Регистрация клиента ЖКХ.
        /// </summary>
        /// <param name="request">Запрос.</param>
        /// <returns>Ответ.</returns>
        ResponseBase PostRegistrationClientJKH(PostRegistrationClientJKHRequest request);
    }
}
