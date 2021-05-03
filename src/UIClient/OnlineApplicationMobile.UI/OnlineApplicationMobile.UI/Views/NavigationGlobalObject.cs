using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace OnlineApplicationMobile.UI.Views
{
    public static class NavigationGlobalObject
    {
        private static INavigation navigation;
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
    }
}
