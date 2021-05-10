using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace OnlineApplicationMobile.UI.Views
{
    public static class NavigationGlobalObject
    {
        private static INavigation navigation;
        private static AppShell currentShell;

        public static INavigation Navigation 
        {
            get => navigation;
            set
            {
                if (navigation != null)
                    return;

                navigation = value;
            }
        }

        public static AppShell CurrentShell
        {
            get => currentShell;
            set
            {
                if (currentShell != null)
                    return;

                currentShell = value;
            }
        }

        public static bool IsLoginStart { get; set; } = false;
    }
}
