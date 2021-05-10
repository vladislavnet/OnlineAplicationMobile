using Microsoft.Extensions.DependencyInjection;
using OnlineApplicationMobile.HttpService.Implementation;
using OnlineApplicationMobile.HttpService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestClient
{
    public static class Startup
    {
        public static IServiceProvider ServiceProvider { get; set; }

        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddSingleton<IUserHttpService, UserHttpService>();
            services.AddSingleton<IApplicationHttpService, ApplicationHttpService>();
            services.AddSingleton<IOrganizationHttpService, OrganizationHttpService>();
            services.AddSingleton<ICommonHttpService, CommonHttpService>();
            services.AddSingleton<IHttpService, HttpService>();

            return services;
        }

        public static IServiceProvider Init()
        {
            var serviceProvider =
                new ServiceCollection()
                    .ConfigureServices()
                    .BuildServiceProvider();
            ServiceProvider = serviceProvider;

            return serviceProvider;
        }

        public static T GetService<T>()
        {
            return ServiceProvider.GetService<T>();
        }
    }
}
