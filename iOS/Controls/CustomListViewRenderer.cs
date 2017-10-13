using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamarinAnimation.Controls;
using XamarinAnimation.iOS.Controls;

[assembly: ExportRenderer(typeof(CustomListView), typeof(CustomListViewRenderer))]
namespace XamarinAnimation.iOS.Controls
{
    public class CustomListViewRenderer : ListViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
        {
            base.OnElementChanged(e);

            Control.ShowsVerticalScrollIndicator = false;
        }
    }
}
