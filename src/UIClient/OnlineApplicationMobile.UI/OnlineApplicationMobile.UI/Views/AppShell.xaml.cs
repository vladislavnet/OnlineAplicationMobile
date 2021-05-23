using OnlineApplicationMobile.Infrastructure.Globals;
using OnlineApplicationMobile.Infrastructure.SqlLiteData.Repository.Interfaces;
using OnlineApplicationMobile.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OnlineApplicationMobile.UI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        private readonly ProfilePage profilePage;
        private readonly UserApplicationsPage userApplicationsPage;
        private readonly int currentItemIndex = 5;

        public AppShell()
        {
            InitializeComponent();

            NavigationGlobalObject.Navigation = Navigation;
            NavigationGlobalObject.CurrentShell = this;
            NavigationGlobalObject.IsLoginStart = false;
            NavigationGlobalObject.IsStart = true;

            Items.Add(new FlyoutItem
            {
                IsVisible = false,
                Title = "Профиль",
                Items =
                {
                    new Tab
                    {
                        Items = { new ShellContent { Content = new ProfilePage() } }
                    }
                }
            });
            CurrentItem = Items[currentItemIndex];

            NavigationGlobalObject.IsStart = false;

            if (NavigationGlobalObject.IsLoginStart)
            {
                Navigation.PushModalAsync(new LoginPage());
                NavigationGlobalObject.IsLoginStart = false;
            }
        }

        private void profileMenuItem_Clicked(object sender, EventArgs e)
        {
            FlyoutIsPresented = false;
            Items[currentItemIndex] = new FlyoutItem
            {
                IsVisible=false,
                Title = "Профиль",
                Items =
                {
                    new Tab
                    {
                        Items = { new ShellContent { Content = new ProfilePage() } }
                    }
                }
            };
            CurrentItem = Items[currentItemIndex];
        }

        private void applicationsMenuItem_Clicked(object sender, EventArgs e)
        {
            FlyoutIsPresented = false;
            Items[currentItemIndex] = new FlyoutItem
            {
                IsVisible = false,
                Title = "Мои заявки",
                Items =
                {
                    new Tab
                    {
                        Items = { new ShellContent { Content = new UserApplicationsPage() } }
                    }
                }
            };
            CurrentItem = Items[currentItemIndex];
        }

        private void recomendedOrganizationsMenuItem_Clicked(object sender, EventArgs e)
        {
            FlyoutIsPresented = false;
            Items[currentItemIndex] = new FlyoutItem
            {
                IsVisible = false,
                Title = "Рекомендованные организации",
                Items =
                {
                    new Tab
                    {
                        Items = { new ShellContent { Content = new RecomendedOrganizationsPage() } }
                    }
                }
            };
            CurrentItem = Items[currentItemIndex];
        }

        private void searchOrganizationsMenuItem_Clicked(object sender, EventArgs e)
        {
            FlyoutIsPresented = false;
            Items[currentItemIndex] = new FlyoutItem
            {
                IsVisible = false,
                Title = "Поиск организации",
                Items =
                {
                    new Tab
                    {
                        Items = { new ShellContent { Content = new SearchOrganizationsPage() } }
                    }
                }
            };
            CurrentItem = Items[currentItemIndex];
        }

        private async void loqoutMenuItem_Clicked(object sender, EventArgs e)
        {
            var userInfoRepository = Startup.GetService<IUserInfoRepository>();
            userInfoRepository.ClearToken();
            CurrentUser.SetToken(null);

            await Navigation.PushModalAsync(new LoginPage());
        }
    }
}