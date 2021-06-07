using CoreGraphics;
using Foundation;
using OnlineApplicationMobile.UI.iOS.Renderers;
using OnlineApplicationMobile.UI.Views.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("CubiSoft")]
[assembly: ExportEffect(typeof(DropShadowEffect), "DropShadowEffect")]
namespace OnlineApplicationMobile.UI.iOS.Renderers
{
    public class DropShadowEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                var effect = (ViewShadowEffect)Element.Effects.FirstOrDefault(e => e is ViewShadowEffect);

                if (effect != null)
                {
                    Container.Layer.CornerRadius = effect.Radius;
                    Container.Layer.ShadowColor = effect.Color.ToCGColor();
                    Container.Layer.ShadowOffset = new CGSize(effect.DistanceX, effect.DistanceY);
                    Container.Layer.ShadowOpacity = 0.5f;
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