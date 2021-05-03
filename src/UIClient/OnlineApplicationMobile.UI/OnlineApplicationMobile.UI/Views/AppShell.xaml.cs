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
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(RoutingTemplate.LoginTemplate, typeof(LoginPage));
            Routing.RegisterRoute(RoutingTemplate.ProfileTemplate, typeof(ProfilePage));

            NavigationGlobalObject.Navigation = Navigation;

            profile.Content = new ProfilePage();
            CurrentItem = profile;

        }

    }
}