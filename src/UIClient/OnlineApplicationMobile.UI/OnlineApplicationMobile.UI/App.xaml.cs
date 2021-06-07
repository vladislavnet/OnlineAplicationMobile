using OnlineApplicationMobile.Infrastructure.Globals;
using OnlineApplicationMobile.Infrastructure.SqlLiteData;
using OnlineApplicationMobile.Infrastructure.SqlLiteData.Repository.Interfaces;
using OnlineApplicationMobile.UI.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OnlineApplicationMobile.UI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Startup.Init();
            var config = Startup.GetService<ConfigurationSqlLite>();
            config.SetDataBasePath(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            var userInfoRepository = Startup.GetService<IUserInfoRepository>();
            CurrentUser.SetToken(userInfoRepository.GetToken());

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
