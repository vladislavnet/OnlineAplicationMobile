using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using OnlineApplicationMobile.HttpService.Implementation;
using OnlineApplicationMobile.HttpService.Interfaces;
using OnlineApplicationMobile.Infrastructure.SqlLiteData;
using OnlineApplicationMobile.Infrastructure.SqlLiteData.Repository.Implementation;
using OnlineApplicationMobile.Infrastructure.SqlLiteData.Repository.Interfaces;
using OnlineApplicationMobile.UI.Views;

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
            services.AddTransient<IUserInfoRepository, UserInfoRepository>();
            services.AddSingleton<ConfigurationSqlLite>();

            services.AddSingleton<LoginPage>();
            services.AddSingleton<ProfilePage>();

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
