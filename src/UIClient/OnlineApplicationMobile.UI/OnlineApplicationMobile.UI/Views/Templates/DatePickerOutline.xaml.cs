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
    public partial class DatePickerOutline : ContentView
    {
        public DatePickerOutline()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(DatePickerOutline), Color.Blue, defaultBindingMode: BindingMode.TwoWay);

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public static readonly BindableProperty PlaceholderProperty =
            BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(DatePickerOutline), null, defaultBindingMode: BindingMode.TwoWay);

        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        public static readonly BindableProperty PlaceholderColorProperty =
            BindableProperty.Create(nameof(PlaceholderColor), typeof(Color), typeof(DatePickerOutline), Color.Blue, defaultBindingMode: BindingMode.TwoWay);

        public Color PlaceholderColor
        {
            get { return (Color)GetValue(PlaceholderColorProperty); }
            set { SetValue(PlaceholderColorProperty, value); }
        }

        public static readonly BindableProperty DateProperty =
            BindableProperty.Create(nameof(Date), typeof(DateTime?), typeof(DatePickerOutline), null, defaultBindingMode: BindingMode.TwoWay);

        public DateTime? Date
        {
            get { return (DateTime?)GetValue(DateProperty); }
            set { SetValue(DateProperty, value); }
        }


        public static readonly BindableProperty ValidateMessageProperty =
            BindableProperty.Create(nameof(ValidateMessage), typeof(string), typeof(DatePickerOutline), null, defaultBindingMode: BindingMode.TwoWay);

        public string ValidateMessage
        {
            get { return (string)GetValue(ValidateMessageProperty); }
            set { SetValue(ValidateMessageProperty, value); }
        }

        public static readonly BindableProperty IsVisibleValidateMessageProperty =
            BindableProperty.Create(nameof(IsVisibleValidateMessage), typeof(bool), typeof(DatePickerOutline), false, defaultBindingMode: BindingMode.TwoWay);

        public bool IsVisibleValidateMessage
        {
            get { return (bool)GetValue(IsVisibleValidateMessageProperty); }
            set { SetValue(IsVisibleValidateMessageProperty, value); }
        }

        async void DatePicker_Focused(object sender, FocusEventArgs e)
        {
        }

        async void DatePicker_Unfocused(object sender, FocusEventArgs e)
        {
        }

        async Task TranslateLabelToTitle()
        {
            if (this.Date == null)
            {
                var placeHolder = this.PlaceHolderLabel;
                var distance = GetPlaceholderDistance(placeHolder);
                await placeHolder.TranslateTo(0, -distance, 100);
            }

        }

        async Task TranslateLabelToPlaceHolder()
        {
            if (this.Date == null)
            {
                await this.PlaceHolderLabel.TranslateTo(0, 0, 100);
            }
        }

        double GetPlaceholderDistance(Label control)
        {
            // In Android we need to move the label slightly up so it's centered in the border frame.
            var distance = 0d;
            if (Device.RuntimePlatform == Device.iOS) distance = 0;
            else distance = 5;

            distance = control.Height + distance;
            return distance;
        }
    }
}