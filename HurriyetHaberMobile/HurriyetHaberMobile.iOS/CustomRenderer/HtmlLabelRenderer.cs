using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using HurriyetHaberMobile.CustomRenderer;
using HurriyetHaberMobile.iOS.CustomRenderer;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;

[assembly: Xamarin.Forms.ExportRenderer(typeof(HtmlLabel), typeof(HtmlLabelRenderer))]
namespace HurriyetHaberMobile.iOS.CustomRenderer
{
    public class HtmlLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            var element = (HtmlLabel)e.NewElement;
            if (element != null && Control != null)
            {
                var nsAttr = new NSAttributedStringDocumentAttributes()
                {
                    DocumentType = NSDocumentType.HTML
                };

                var html = NSData.FromString(element.Text, NSStringEncoding.Unicode);
                var nsError = new NSError();
                Control.AttributedText = new NSAttributedString(html, nsAttr, ref nsError);
            }
        }
    }
}