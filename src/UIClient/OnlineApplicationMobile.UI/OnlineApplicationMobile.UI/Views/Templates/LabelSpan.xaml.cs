using OnlineApplicationMobile.UI.Views.StyleOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OnlineApplicationMobile.UI.Views.Templates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LabelSpan : ContentView
    {
        public LabelSpan()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty HelpTextProperty =
            BindableProperty.Create(nameof(HelpText), typeof(string), typeof(LabelSpan), null, defaultBindingMode: BindingMode.TwoWay);

        public string HelpText
        {
            get { return (string)GetValue(HelpTextProperty); }
            set { SetValue(HelpTextProperty, value); }
        }

        public static readonly BindableProperty MainTextProperty =
            BindableProperty.Create(nameof(MainText), typeof(string), typeof(LabelSpan), null, defaultBindingMode: BindingMode.TwoWay);

        public string MainText
        {
            get { return (string)GetValue(MainTextProperty); }
            set { SetValue(MainTextProperty, value); }
        }

        public static readonly BindableProperty LineHeightProperty =
            BindableProperty.Create(nameof(LineHeight), typeof(double), typeof(LabelSpan), 5.0, defaultBindingMode: BindingMode.TwoWay);

        public double LineHeight
        {
            get { return (double)GetValue(LineHeightProperty); }
            set { SetValue(LineHeightProperty, value); }
        }

        public static readonly BindableProperty HelpTextColorProperty =
            BindableProperty.Create(nameof(HelpTextColor), typeof(Color), typeof(LabelSpan), ColorOptions.MainColor, defaultBindingMode: BindingMode.TwoWay);

        public Color HelpTextColor
        {
            get { return (Color)GetValue(HelpTextColorProperty); }
            set { SetValue(HelpTextColorProperty, value); }
        }

        public static readonly BindableProperty MainTextColorProperty =
            BindableProperty.Create(nameof(MainTextColor), typeof(Color), typeof(LabelSpan), ColorOptions.MainColor, defaultBindingMode: BindingMode.TwoWay);

        public Color MainTextColor
        {
            get { return (Color)GetValue(MainTextColorProperty); }
            set { SetValue(MainTextColorProperty, value); }
        }
    }
}