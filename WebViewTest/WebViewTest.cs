using System;

using Xamarin.Forms;

namespace WebViewTest
{
	public interface IBaseUrl { string Get(); }

	public class BaseUrlWebView : WebView { }

	public class App : Application
	{
		public App()
		{
			//var webView = new BaseUrlWebView();
			//var html = new HtmlWebViewSource();
			//html.BaseUrl = DependencyService.Get<IBaseUrl>().Get();
			//html.Html = 
			//	@"<html>
			//		<head>
			//		<link rel=""stylesheet"" href=""default.css"">
			//		</head>
			//		<body>
			//		<h1>Xamarin.Forms</h1>
			//		<p>The CSS and image are loaded from local files!</p>
			//		</body>
			//	</html>";
			//webView.Source = html;

			var page = new TabbedPage();
			page.Children.Add(new WebPage());


			MainPage = page;
		}
	}


}

