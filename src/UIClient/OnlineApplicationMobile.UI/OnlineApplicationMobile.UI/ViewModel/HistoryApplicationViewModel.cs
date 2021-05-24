using OnlineApplicationMobile.UI.ModelView;
using OnlineApplicationMobile.UI.ViewModel.Interfaces;
using OnlineApplicationMobile.UI.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace OnlineApplicationMobile.UI.ViewModel
{
    public class HistoryApplicationViewModel : BaseViewModel, IViewModel
    {
        private List<HistoryApplicationModelView> historyApplication;

        public HistoryApplicationViewModel(IView view, INavigation navigation, IEnumerable<HistoryApplicationModelView> historyApplication) : base(navigation)
        {
            View = view;
            View.ViewModel = this;
            HistoryApplication = historyApplication.ToList();
        }

        /// <summary>
        /// История заявки.
        /// </summary>
        public List<HistoryApplicationModelView> HistoryApplication
        {
            get => historyApplication;
            set
            {
                historyApplication = value;
                OnPropertyChanged(nameof(HistoryApplication));
            }
        }
    }
}
