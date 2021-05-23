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
    public partial class EditorOutline : ContentView
    {
        public EditorOutline()
        {
            InitializeComponent();
            this.TextBox.PlaceholderColor = PlaceholderColor;
        }

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(EditorOutline), null, defaultBindingMode: BindingMode.TwoWay);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }


        public static readonly BindableProperty PlaceholderProperty =
            BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(EditorOutline), null, defaultBindingMode: BindingMode.TwoWay);

        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        public static readonly BindableProperty PlaceholderColorProperty =
            BindableProperty.Create(nameof(PlaceholderColor), typeof(Color), typeof(EditorOutline), Color.Blue, defaultBindingMode: BindingMode.TwoWay);

        public Color PlaceholderColor
        {
            get { return (Color)GetValue(PlaceholderColorProperty); }
            set { SetValue(PlaceholderColorProperty, value); }
        }


        public static readonly BindableProperty ValidateMessageProperty =
            BindableProperty.Create(nameof(ValidateMessage), typeof(string), typeof(EditorOutline), null, defaultBindingMode: BindingMode.TwoWay);

        public string ValidateMessage
        {
            get { return (string)GetValue(ValidateMessageProperty); }
            set { SetValue(ValidateMessageProperty, value); }
        }

        public static readonly BindableProperty IsVisibleValidateMessageProperty =
            BindableProperty.Create(nameof(IsVisibleValidateMessage), typeof(bool), typeof(EditorOutline), false, defaultBindingMode: BindingMode.TwoWay);

        public bool IsVisibleValidateMessage
        {
            get { return (bool)GetValue(IsVisibleValidateMessageProperty); }
            set { SetValue(IsVisibleValidateMessageProperty, value); }
        }

        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(EditorOutline), Color.Blue, defaultBindingMode: BindingMode.TwoWay);

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public static readonly BindableProperty HeightEditorProperty =
            BindableProperty.Create(nameof(HeightEditor), typeof(double), typeof(EditorOutline), 100.0, defaultBindingMode: BindingMode.TwoWay);

        public double HeightEditor
        {
            get { return (double)GetValue(HeightEditorProperty); }
            set 
            { 
                SetValue(HeightEditorProperty, value);
                PlaceHolderLabel.Margin = new Thickness(10, -(value), 0, 0);
            }
        }

        public event EventHandler<FocusEventArgs> TextBoxFocused;
        public event EventHandler<FocusEventArgs> TextBoxUnfocused;
        public event EventHandler<TextChangedEventArgs> TextBoxTextChanged;

        async void TextBox_Focused(object sender, FocusEventArgs e)
        {
            if (this.TextBoxFocused != null)
                this.TextBoxFocused(this, e);
        }

        async void TextBox_Unfocused(object sender, FocusEventArgs e)
        {
            if (this.TextBoxUnfocused != null)
                this.TextBoxUnfocused(this, e);
        }

        public virtual void OnTextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            if (this.TextBoxTextChanged != null)
                this.TextBoxTextChanged(this, e);
        }

    }
}