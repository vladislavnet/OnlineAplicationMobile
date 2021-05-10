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
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(RoutingTemplate.LoginTemplate, typeof(LoginPage));
            Routing.RegisterRoute(RoutingTemplate.ProfileTemplate, typeof(ProfilePage));
            Routing.RegisterRoute(RoutingTemplate.UserApplicationsTemplate, typeof(UserApplicationsPage));
            Routing.RegisterRoute(RoutingTemplate.RecomendedOrganizationsTemplate, typeof(RecomendedOrganizationsPage));
            Routing.RegisterRoute(RoutingTemplate.SearchOrganizationsTemplate, typeof(SearchOrganizationsPage));
            
            
            NavigationGlobalObject.Navigation = Navigation;
            NavigationGlobalObject.CurrentShell = this;

            profilePage = new ProfilePage();
            //userApplicationsPage = new UserApplicationsPage();

            profile.Content = profilePage;
            applications.Content = new UserApplicationsPage();
            recomendedOrganizations.Content = new RecomendedOrganizationsPage();
            searchOrganizations.Content = new SearchOrganizationsPage();

            CurrentItem = profile;

        }


        //private void applicationsMenuItem_Clicked(object sender, EventArgs e)
        //{
        //    //setShellContent(applications, new UserApplicationsPage());
        //    CurrentItem = applications;
        //    userApplicationsPage.Refresh();
        //    FlyoutIsPresented = false;
        //}

        //private void recomendedOrganizationsMenuItem_Clicked(object sender, EventArgs e)
        //{
        //    setShellContent(recomendedOrganizations, new RecomendedOrganizationsPage());
        //}

        //private void searchOrganizationsMenuItem_Clicked(object sender, EventArgs e)
        //{
        //    setShellContent(searchOrganizations, new UserApplicationsPage());
        //}

        //private void setShellContent(ShellContent shellContent, Page page)
        //{
        //    shellContent.Content = page;
        //    CurrentItem = shellContent;
        //    FlyoutIsPresented = false;
        //}
    }
}