using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using HurriyetHaberMobile.CustomRenderer;
using HurriyetHaberMobile.Droid.CustomRenderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Text;

[assembly: Xamarin.Forms.ExportRenderer(typeof(HtmlLabel), typeof(HtmlLabelRenderer))]
namespace HurriyetHaberMobile.Droid.CustomRenderer
{
    public class HtmlLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            var element = (HtmlLabel)e.NewElement;
            if (element != null && Control != null)
            {
                Control.SetText(Html.FromHtml(element.Text), TextView.BufferType.Spannable);
            }
        }
    }
}