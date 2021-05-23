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

[assembly: ResolutionGroupName("CubiSoft")]
[assembly: ExportEffect(typeof(DropShadowEffect), "DropShadowEffect")]
namespace OnlineApplicationMobile.UI.Droid.Renderers
{
    public class DropShadowEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                var control = Control ?? Container as Android.Views.View;

                var effect = (ViewShadowEffect)Element.Effects.FirstOrDefault(e => e is ViewShadowEffect);

                if (effect != null)
                {
                    float radius = effect.Radius;

                    control.Elevation = radius;
                    control.TranslationZ = (effect.DistanceX + effect.DistanceY) / 2;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot set property on attached control. Error: {0}", ex.Message);
            }
        }

        protected override void OnDetached()
        {
        }
    }
}