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
    public partial class PickerOutline : ContentView
    {
        public PickerOutline()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty BorderColorProperty =
           BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(PickerOutline), Color.Blue, defaultBindingMode: BindingMode.TwoWay);

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public static readonly BindableProperty PlaceholderProperty =
            BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(PickerOutline), null, defaultBindingMode: BindingMode.TwoWay);

        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        public static readonly BindableProperty PlaceholderColorProperty =
            BindableProperty.Create(nameof(PlaceholderColor), typeof(Color), typeof(PickerOutline), Color.Blue, defaultBindingMode: BindingMode.TwoWay);

        public Color PlaceholderColor
        {
            get { return (Color)GetValue(PlaceholderColorProperty); }
            set { SetValue(PlaceholderColorProperty, value); }
        }

        public static readonly BindableProperty ValidateMessageProperty =
            BindableProperty.Create(nameof(ValidateMessage), typeof(string), typeof(PickerOutline), null, defaultBindingMode: BindingMode.TwoWay);

        public string ValidateMessage
        {
            get { return (string)GetValue(ValidateMessageProperty); }
            set { SetValue(ValidateMessageProperty, value); }
        }

        public static readonly BindableProperty IsVisibleValidateMessageProperty =
            BindableProperty.Create(nameof(IsVisibleValidateMessage), typeof(bool), typeof(PickerOutline), false, defaultBindingMode: BindingMode.TwoWay);

        public bool IsVisibleValidateMessage
        {
            get { return (bool)GetValue(IsVisibleValidateMessageProperty); }
            set { SetValue(IsVisibleValidateMessageProperty, value); }
        }

        public static readonly BindableProperty SelectedItemProperty =
            BindableProperty.Create(nameof(SelectedItem), typeof(object), typeof(PickerOutline), null, defaultBindingMode: BindingMode.TwoWay);

        public object SelectedItem
        {
            get { return (object)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create(nameof(ItemsSource), typeof(IList), typeof(PickerOutline), null, defaultBindingMode: BindingMode.TwoWay);

        public IList ItemsSource
        {
            get { return (IList)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly BindableProperty HorizontalTextAlignmentProperty =
            BindableProperty.Create(nameof(HorizontalTextAlignment), typeof(TextAlignment), typeof(PickerOutline), TextAlignment.Start, defaultBindingMode: BindingMode.TwoWay);

        public TextAlignment HorizontalTextAlignment
        {
            get { return (TextAlignment)GetValue(HorizontalTextAlignmentProperty); }
            set { SetValue(HorizontalTextAlignmentProperty, value); }
        }

        private void PickerList_Focused(object sender, FocusEventArgs e)
        {

        }

        private void PickerList_Unfocused(object sender, FocusEventArgs e)
        {

        }
    }
}