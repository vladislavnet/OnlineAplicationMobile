﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OnlineApplicationMobile.UI.Views.Templates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntryOutlined : ContentView
    {
        public EntryOutlined()
        {
            InitializeComponent();
            this.TextBox.PlaceholderColor = PlaceholderColor;
        }

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(EntryOutlined), null);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly BindableProperty PlaceholderProperty =
            BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(EntryOutlined), null);

        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        public static readonly BindableProperty PlaceholderColorProperty =
            BindableProperty.Create(nameof(PlaceholderColor), typeof(Color), typeof(EntryOutlined), Color.Blue);

        public Color PlaceholderColor
        {
            get { return (Color)GetValue(PlaceholderColorProperty); }
            set { SetValue(PlaceholderColorProperty, value); }
        }


        public static readonly BindableProperty ValidateMessageProperty =
            BindableProperty.Create(nameof(ValidateMessage), typeof(string), typeof(EntryOutlined), null);

        public string ValidateMessage
        {
            get { return (string)GetValue(ValidateMessageProperty); }
            set { SetValue(ValidateMessageProperty, value); }
        }

        public static readonly BindableProperty IsVisibleValidateMessageProperty =
            BindableProperty.Create(nameof(IsVisibleValidateMessage), typeof(bool), typeof(EntryOutlined), false);

        public bool IsVisibleValidateMessage
        {
            get { return (bool)GetValue(IsVisibleValidateMessageProperty); }
            set { SetValue(IsVisibleValidateMessageProperty, value); }
        }

        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(EntryOutlined), Color.Blue);

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        async void TextBox_Focused(object sender, FocusEventArgs e)
        {
            
        }

        async void TextBox_Unfocused(object sender, FocusEventArgs e)
        {
            
        }

        async Task TranslateLabelToTitle()
        {
            if (string.IsNullOrEmpty(this.Text))
            {
                var placeHolder = this.PlaceHolderLabel;
                var distance = GetPlaceholderDistance(placeHolder);
                await placeHolder.TranslateTo(0, -distance, 100);
            }

        }

        async Task TranslateLabelToPlaceHolder()
        {
            if (string.IsNullOrEmpty(this.Text))
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

        public event EventHandler<TextChangedEventArgs> TextChanged;

        public virtual void OnTextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            TextChanged?.Invoke(this, e);
        }
    }
}