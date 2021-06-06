﻿using OnlineApplicationMobile.UI.Helpers;
using OnlineApplicationMobile.UI.ModelView;
using OnlineApplicationMobile.UI.ViewModel;
using OnlineApplicationMobile.UI.ViewModel.Interfaces;
using OnlineApplicationMobile.UI.Views.Interfaces;
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
    public partial class HistoryApplicationPage : ContentPage, IView
    {
        private readonly HistoryApplicationViewModel historyApplicationViewModel;
        public HistoryApplicationPage(IEnumerable<HistoryApplicationModelView> historyApplication)
        {
            InitializeComponent();
            historyApplicationViewModel = new HistoryApplicationViewModel(this, NavigationGlobalObject.Navigation, historyApplication);
        }

        public IViewModel ViewModel
        {
            get => BindingContext as IViewModel;
            set => BindingContext = value;
        }

        public async void DisplayAlertMessage(string message)
        {
            await DisplayAlert(AlertMessageTemplate.AlertTemplate, message, AlertMessageTemplate.OkTemplate);
        }

        public async void DisplayQuestionMessage(string title, string question, string accept, string cancel, Action action)
        {
            var result = await DisplayAlert(title, question, accept, cancel);
            if (result)
            {
                action.Invoke();
            }
        }
    }
}