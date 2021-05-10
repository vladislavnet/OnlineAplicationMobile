using OnlineApplicationMobile.HttpService.Interfaces;
using OnlineApplicationMobile.HttpService.Requests;
using System;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Startup.Init();
            Authorization();

            Console.ReadKey();
        }

        static void Authorization()
        {
            var httpService = Startup.GetService<IHttpService>();

            var response = httpService.Authorization(new AuthorizationRequest
            {
                Username = "admin",
                Password = "1234"
            }).Result;

            Console.WriteLine(response.Token);
        }
    }
}
