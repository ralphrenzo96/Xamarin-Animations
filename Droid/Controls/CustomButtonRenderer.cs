using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinAnimation.Controls;
using XamarinAnimation.Droid.Controls;

[assembly: ExportRenderer(typeof(CustomButton), typeof(CustomButtonRenderer))]
namespace XamarinAnimation.Droid.Controls
{
    public class CustomButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            Control.SetAllCaps(false);
        }

        protected override void OnDraw(Android.Graphics.Canvas canvas)
        {
            base.OnDraw(canvas);
        }
    }
}
