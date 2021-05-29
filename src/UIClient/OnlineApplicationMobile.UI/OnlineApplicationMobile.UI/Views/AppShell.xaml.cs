using OnlineApplicationMobile.Infrastructure.Globals;
using OnlineApplicationMobile.Infrastructure.SqlLiteData.Repository.Interfaces;
using OnlineApplicationMobile.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OnlineApplicationMobile.UI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        private readonly int currentItemIndex = 5;

        public AppShell()
        {
            InitializeComponent();

            NavigationGlobalObject.Navigation = Navigation;
            NavigationGlobalObject.CurrentShell = this;

            NavigationGlobalObject.GoToProfilePage += profileMenuItem_Clicked;
            NavigationGlobalObject.GoToUserApplicationsPage += applicationsMenuItem_Clicked;
            NavigationGlobalObject.GoToRecomendedOrganizationsPage += recomendedOrganizationsMenuItem_Clicked;
            NavigationGlobalObject.GoToSearchOrganizationsPage += searchOrganizationsMenuItem_Clicked;

            NavigationGlobalObject.Dispatcher = Dispatcher;

            Items.Add(new FlyoutItem
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
            });
            CurrentItem = Items[currentItemIndex];
        }

        private void profileMenuItem_Clicked(object sender, EventArgs e)
        {
            CheckoutPage("Профиль", new ProfilePage());
        }

        private void applicationsMenuItem_Clicked(object sender, EventArgs e)
        {
            CheckoutPage("Мои заявки", new UserApplicationsPage());
        }

        private void recomendedOrganizationsMenuItem_Clicked(object sender, EventArgs e)
        {
            CheckoutPage("организации с подтверждённым лицевым счётом", new RecomendedOrganizationsPage());
        }

        private void searchOrganizationsMenuItem_Clicked(object sender, EventArgs e)
        {
            CheckoutPage("Поиск организации", new SearchOrganizationsPage());
        }

        private async void loqoutMenuItem_Clicked(object sender, EventArgs e)
        {
            if (!CurrentUser.IsCheckToken)
            {
                await Navigation.PushModalAsync(new LoginPage());
                return;
            }

            bool result = await DisplayAlert("Подтвердить действие", "Вы уверены, что хотите выйти?", "Да", "Нет");

            if (result)
            {
                var userInfoRepository = Startup.GetService<IUserInfoRepository>();
                userInfoRepository.ClearToken();
                CurrentUser.SetToken(null);
                setLoginOrLoqoutMenuItemTitle();

                await Navigation.PushModalAsync(new LoginPage());
            }
        }

        private void setLoginOrLoqoutMenuItemTitle()
        {
            if (CurrentUser.IsCheckToken)
            {
                loqoutMenuItem.Text = "Выйти";
            }
            else
            {
                loqoutMenuItem.Text = "Войти";
            }
        }

        private void CheckoutPage(string title, ContentPage page)
        {
            FlyoutIsPresented = false;
            Items[currentItemIndex] = new FlyoutItem
            {
                IsVisible = false,
                Title = title,
                Items =
                {
                    new Tab
                    {
                        Items = { new ShellContent { Content = page } }
                    }
                }
            };
            CurrentItem = Items[currentItemIndex];
            setLoginOrLoqoutMenuItemTitle();
        }
    }
}