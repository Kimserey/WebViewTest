using System;
using UIKit;
using WebViewTest;
using WebViewTest.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ResizableWebView), typeof(ResizableWebViewRenderer))]
namespace WebViewTest.iOS
{
	public class ResizableWebViewRenderer : WebViewRenderer
	{
		protected override void OnElementChanged(VisualElementChangedEventArgs e)
		{
			base.OnElementChanged(e);
			this.ScalesPageToFit = true;
			this.AutoresizingMask = UIViewAutoresizing.FlexibleDimensions;
		}
	}
}
