using System;
using WebViewTest.iOS;
using Xamarin.Forms;
using Foundation;
using UIKit;

[assembly: Dependency(typeof(BaseUrl_iOS))]
namespace WebViewTest.iOS
{
	public class BaseUrl_iOS : IBaseUrl
	{
		public string Get()
		{
			return NSBundle.MainBundle.BundlePath;
		}
	}
}
