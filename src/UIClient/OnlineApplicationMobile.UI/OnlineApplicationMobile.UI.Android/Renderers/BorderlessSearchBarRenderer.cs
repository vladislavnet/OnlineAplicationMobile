using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using OnlineApplicationMobile.UI.Droid.Renderers;
using OnlineApplicationMobile.UI.Views.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(BorderlessSearchBar), typeof(BorderlessSearchBarRenderer))]
namespace OnlineApplicationMobile.UI.Droid.Renderers
{
    public class BorderlessSearchBarRenderer : SearchBarRenderer
    {
        public BorderlessSearchBarRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);

            //Configure native control (TextBox)
            if (Control != null)
            {
                Control.Background = null;
            }

            // Configure Entry properties
            if (e.NewElement != null)
            {

            }
        }
    }
}