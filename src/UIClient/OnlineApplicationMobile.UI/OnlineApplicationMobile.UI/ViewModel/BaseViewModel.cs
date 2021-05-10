using OnlineApplicationMobile.HttpService.DTO;
using OnlineApplicationMobile.HttpService.Requests;
using OnlineApplicationMobile.Infrastructure.Globals;
using OnlineApplicationMobile.UI.ModelView;
using OnlineApplicationMobile.UI.Views;
using OnlineApplicationMobile.UI.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace OnlineApplicationMobile.UI.ViewModel
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public BaseViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }

        /// <summary>
        /// Предаствление.
        /// </summary>
        public IView View { get; set; }

        /// <summary>
        /// Навигация.
        /// </summary>
        public INavigation Navigation { get; protected set; }

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

        public async void  GoToUserApplicationPage()
        {
            
        }

        public void ToNextAction(HttpStatusCode httpStatusCode, Action action, Action actionError)
        {
            switch (httpStatusCode)
            {
                case HttpStatusCode.Forbidden:
                    if (!NavigationGlobalObject.IsLoginStart)
                    {
                        DisplayMessage("Авторизуруйтесь");
                        PushModalPage(new LoginPage());
                    }
                    break;
                case HttpStatusCode.InternalServerError:
                    actionError.Invoke();
                    break;
                case HttpStatusCode.OK:
                    action.Invoke();
                    break;
            }                  
        }

        public void DisplayMessage(string message)
        {
            View.DisplayAlertMessage(message);
        }

        public RequestBase BuildRequestBase()
        {
            return new RequestBase { Token = CurrentUser.Token };
        }

        public string GetUserToken()
        {
            return CurrentUser.Token;
        }

        public ServiceTypeModelView MapServiceType(ServiceTypeDto serviceType)
        {
            return new ServiceTypeModelView
            {
                Id = serviceType.Id,
                Title = serviceType.Title
            };
        }
    }
}
