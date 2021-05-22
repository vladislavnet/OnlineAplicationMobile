using OnlineApplicationMobile.UI.Views.StyleOptions;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace OnlineApplicationMobile.UI.Views.Templates
{
    public class ExtendedViewCell : ViewCell
    {
        public static readonly BindableProperty SelectedBackgroundColorProperty =
        BindableProperty.Create("SelectedBackgroundColor",
                                typeof(Color),
                                typeof(ExtendedViewCell),
                                ColorOptions.MainColor);

        public Color SelectedBackgroundColor
        {
            get { return (Color)GetValue(SelectedBackgroundColorProperty); }
            set { SetValue(SelectedBackgroundColorProperty, value); }
        }
    }
}
