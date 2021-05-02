﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OnlineApplicationMobile.UI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShellFlyout : ContentPage
    {
        public ListView ListView;

        public AppShellFlyout()
        {
            InitializeComponent();

            BindingContext = new AppShellFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class AppShellFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<AppShellFlyoutMenuItem> MenuItems { get; set; }

            public AppShellFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<AppShellFlyoutMenuItem>(new[]
                {
                    new AppShellFlyoutMenuItem { Id = 0, Title = "Page 1" },
                    new AppShellFlyoutMenuItem { Id = 1, Title = "Page 2" },
                    new AppShellFlyoutMenuItem { Id = 2, Title = "Page 3" },
                    new AppShellFlyoutMenuItem { Id = 3, Title = "Page 4" },
                    new AppShellFlyoutMenuItem { Id = 4, Title = "Page 5" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}