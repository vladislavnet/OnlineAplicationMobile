using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace OnlineApplicationMobile.UI.ModelView
{
    /// <summary>
    /// Типы сервисов предоставляемые организацией с флагом выбора
    /// </summary>
    public class ServiceTypeSelectionModelView : ServiceTypeModelView, INotifyPropertyChanged
    {
        private bool isSelect = false;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        /// <summary>
        /// Флаг выбора.
        /// </summary>
        public bool IsSelect 
        { 
            get => isSelect;
            set
            {
                isSelect = value;
                OnPropertyChanged(nameof(IsSelect));
            }
        }
    }
}
