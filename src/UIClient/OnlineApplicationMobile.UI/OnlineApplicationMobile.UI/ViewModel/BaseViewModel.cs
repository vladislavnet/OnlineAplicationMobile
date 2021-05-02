using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace OnlineApplicationMobile.UI.ViewModel
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public INavigation Navigation { get; protected set; }

        public BaseViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public async void PopModalPage()
        {
            await Navigation.PopModalAsync();
        }

        public async void PopPage()
        {
            await Navigation.PopAsync();
        }

        public async void PushModalPage(Page page)
        {
            await Navigation.PushModalAsync(page);
        }

        public async void PushPage(Page page)
        {
            await Navigation.PushAsync(page);
        }

        public Page GetNavigatedPage(Page page)
        {
            return new NavigationPage(page);
        }
    }
}
