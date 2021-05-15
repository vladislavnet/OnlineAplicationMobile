using OnlineApplicationMobile.Domain.Entities;
using OnlineApplicationMobile.HttpService.Interfaces;
using OnlineApplicationMobile.HttpService.Requests;
using OnlineApplicationMobile.Infrastructure.Builders;
using OnlineApplicationMobile.Infrastructure.Globals;
using OnlineApplicationMobile.Infrastructure.Helpers;
using System;

namespace TestClient
{
    class Program
    {
        static IHttpService httpService = Startup.GetService<IHttpService>();
        static string Token = "d639c45da2ee3eba4095f3f048ea102822a75969";
        static RequestBase buildRequestBase()
        {
            return new RequestBase
            {
                Token = Token
            };
        }

        private static void printListOperations()
        {
            Console.WriteLine("1. Авторизация.");
            Console.WriteLine("2. Получение информации по текущему клиенту ЖКХ.");
            Console.WriteLine("3. Редактирование информации по текущему клиенту ЖКХ.");
        }
        static void Main(string[] args)
        {
            Startup.Init();
            string operation = null;

            do
            {
                printListOperations();
                operation = Console.ReadLine();
                Console.WriteLine("\n\n\n\n\n ***************************************************** \n\n\n\n\n");
                switch (operation)
                {
                    case "1":
                        Authorization();
                        break;
                    case "2":
                        GetInfoCurrentClientJKH();
                        break;
                    case "3":
                        GetInfoCurrentClientJKH();
                        PutInfoCurrentClientJKH();
                        break;
                    default:
                        operation = null;
                        break;        
                }
                Console.WriteLine("\n\n\n\n\n ***************************************************** \n\n\n\n\n");
            } 
            while (operation != null);

            Authorization();
            GetInfoCurrentClientJKH();
            Console.ReadKey();
        }

        static void Authorization()
        {
            var response = httpService.Authorization(new AuthorizationRequest
            {
                Username = "admin",
                Password = "1234"
            });

            Console.WriteLine(response.Token);
        }

        static void GetInfoCurrentClientJKH()
        {
            var response = httpService.GetInfoCurrentClientJKH(buildRequestBase());
            Console.WriteLine($"Статус код: {response.StatusCode}");
            CurrentUser.SetCurrentUser(new ClientJKH
            {
                User = new UserDomainBuilder().Build(response.User),
                NumberPersonalAccount = response.NumberPersonalAccount,
                Address = new AddressDomainBuilder().Build(response.Address)
            });

            Console.WriteLine(JsonSerializator.SerializeByFormatOptions(response));
        }

        static void PutInfoCurrentClientJKH()
        {
            var response = httpService.PutInfoCurrentClientJKH(new PutInfoCurrentClientJKHRequest
            {
                Token = Token,
                FirstName = CurrentUser.FirstName,
                LastName = CurrentUser.LastName,
                MiddleName = CurrentUser.MiddleName,
                BirthDate = DateTime.Now.ToString("yyyy-MM-dd"),
                Telephone = CurrentUser.Telephone,
                NumberPersonalAccount = CurrentUser.NumberPersonalAccount,
                Address = new AddressDomainBuilder().Rebuild(CurrentUser.Address)
            });

            Console.WriteLine($"Статус код: {response.StatusCode}");
            Console.WriteLine($"Сообщение: {response.Message}");
        }

    }
}
