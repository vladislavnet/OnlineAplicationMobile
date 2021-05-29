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
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OnlineApplicationMobile.UI.ViewModel
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        private bool isRefreshing;
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


        /// <summary>
        /// Флаг обновления.
        /// </summary>
        public bool IsRefreshing
        {
            get => isRefreshing;
            set
            {
                isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
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

        public async void  GoToUserApplicationPage()
        {
            
        }

        public void ToNextAction(HttpStatusCode httpStatusCode, Action action, Action actionError)
        {
            switch (httpStatusCode)
            {
                case HttpStatusCode.Unauthorized:
                case HttpStatusCode.Forbidden:
                    NavigationGlobalObject.Dispatcher.BeginInvokeOnMainThread(() =>
                    {
                        IsRefreshing = false;
                        DisplayMessage("Авторизуруйтесь");
                        PushModalPage(new LoginPage());
                    });
                    break;
                case HttpStatusCode.BadRequest:
                case HttpStatusCode.NotFound:
                case HttpStatusCode.InternalServerError:
                case HttpStatusCode.MethodNotAllowed:
                case HttpStatusCode.NonAuthoritativeInformation:
                    NavigationGlobalObject.Dispatcher.BeginInvokeOnMainThread(() =>
                    {
                        actionError.Invoke();
                    });
                    break;
                case HttpStatusCode.Created:
                case HttpStatusCode.NoContent:
                case HttpStatusCode.Accepted:
                case HttpStatusCode.OK:
                    NavigationGlobalObject.Dispatcher.BeginInvokeOnMainThread(() =>
                    {
                        action.Invoke();
                    });
                    break;

                default:
                    NavigationGlobalObject.Dispatcher.BeginInvokeOnMainThread(() =>
                    {
                        DisplayMessage("Произошла ошибка на сервере");
                    });
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
