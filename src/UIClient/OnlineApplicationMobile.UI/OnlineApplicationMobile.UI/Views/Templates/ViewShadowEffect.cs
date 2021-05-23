using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace OnlineApplicationMobile.UI.Views.Templates
{
    public class ViewShadowEffect : RoutingEffect
    {
        public float Radius { get; set; }

        public Color Color { get; set; }

        public float DistanceX { get; set; }

        public float DistanceY { get; set; }

        public ViewShadowEffect() : base("CubiSoft.DropShadowEffect")
        {
        }
    }
}
