using OnlineApplicationMobile.Infrastructure.Globals;
using OnlineApplicationMobile.Infrastructure.RealmData.Repository.Interfaces;
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
