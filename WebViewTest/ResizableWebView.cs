using System;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace WebViewTest
{
	public class ResizableWebView : WebView {
		public ResizableWebView(string baseUrl)
		{
			Source = new HtmlWebViewSource { BaseUrl = baseUrl };
		}

		public void SetHtml(string html)
		{
			var source = Source as HtmlWebViewSource;
			source.Html = html;
		}
	}
}
