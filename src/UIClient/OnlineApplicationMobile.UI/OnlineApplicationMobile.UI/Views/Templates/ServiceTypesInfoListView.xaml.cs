using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OnlineApplicationMobile.UI.Views.Templates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ServiceTypesInfoListView : ContentView
    {
        public ServiceTypesInfoListView()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create(nameof(ItemsSource), typeof(IList), typeof(ServiceTypesInfoListView), null, defaultBindingMode: BindingMode.TwoWay);

        public IList ItemsSource
        {
            get { return (IList)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }
    }
}