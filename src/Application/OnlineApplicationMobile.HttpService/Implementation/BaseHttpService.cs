using OnlineApplicationMobile.HttpService.Templates;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Xamarin.Android.Net;

namespace OnlineApplicationMobile.HttpService.Implementation
{
    public abstract class BaseHttpService
    {
        /// <summary>
        /// Настройка для сериализации.
        /// </summary>
        protected JsonSerializerOptions optionsSerialize = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        /// <summary>
        /// Возвращает клиент HTTP;
        /// </summary>
        protected HttpClient GetClient()
        {
            HttpClient client = new HttpClient(new AndroidClientHandler());
            client.Timeout = TimeSpan.FromSeconds(30);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        /// <summary>
        /// Возвращает клиент HTTP;
        /// </summary>
        protected HttpClient GetClient(IDictionary<string, string> headers)
        {
            HttpClient client = new HttpClient(new AndroidClientHandler());
            client.Timeout = TimeSpan.FromSeconds(30);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            foreach (var header in headers)
            {
                client.DefaultRequestHeaders.Add(header.Key, header.Value);
            }
            return client;
        }

        /// <summary>
        /// Возвращает клиент HTTP вместе заголовком авторизации;
        /// </summary>
        protected HttpClient GetClientByHeaderAuthorization(string token)
        {
            var headers = new Dictionary<string, string>();
            headers.Add("Authorization", string.Format(HeaderTemplate.TokenHeader, token));
            return GetClient(headers);
        }
    }
}
