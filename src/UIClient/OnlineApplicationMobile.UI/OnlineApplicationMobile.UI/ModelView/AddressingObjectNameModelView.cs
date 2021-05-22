using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace OnlineApplicationMobile.UI.ModelView
{
    /// <summary>
    /// Класс для отображения имени адресного объекта.
    /// </summary>
    public class AddressingObjectNameModelView : INotifyPropertyChanged
    {
        private int id;
        private string name;
        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        public int Id 
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        /// <summary>
        /// Наименование адресного объекта.
        /// </summary>
        public string Name 
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
