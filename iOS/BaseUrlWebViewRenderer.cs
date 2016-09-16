using System;
using Foundation;
using WebViewTest;
using WebViewTest.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(BaseUrlWebView), typeof(BaseUrlWebViewRenderer))]
namespace WebViewTest.iOS
{
	public class BaseUrlWebViewRenderer : WebViewRenderer
	{
		public override void LoadHtmlString(string s, NSUrl baseUrl)
		{
			baseUrl = new NSUrl(NSBundle.MainBundle.BundlePath, true);
			base.LoadHtmlString(s, baseUrl);
		}
	}
}
