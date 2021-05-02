using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using OnlineApplicationMobile.HttpService.Implementation;
using OnlineApplicationMobile.HttpService.Interfaces;

namespace OnlineApplicationMobile.UI
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
            services.AddSingleton<IHttpService, HttpService.Implementation.HttpService>();
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
    }
}
