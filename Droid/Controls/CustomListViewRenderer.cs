using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinAnimation.Controls;
using XamarinAnimation.Droid.Controls;

[assembly: ExportRenderer(typeof(CustomListView), typeof(CustomListViewRenderer))]
namespace XamarinAnimation.Droid.Controls
{
    public class CustomListViewRenderer : ListViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
        {
            base.OnElementChanged(e);
            Control.VerticalScrollBarEnabled = false;
        }
    }
}
