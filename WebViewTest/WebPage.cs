using System;
using Xamarin.Forms;

namespace WebViewTest
{
	public class WebPage : ContentPage
	{
		public WebPage()
		{
			var browser = new WebView();

			browser.Source = "http://xamarin.com";

			base.Title = "Url";
			Content = browser;
		}
	}
}

