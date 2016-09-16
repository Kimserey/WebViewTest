﻿using System;
using Xamarin.Forms;

namespace WebViewTest
{
	public class LocalPage: ContentPage
	{
		public LocalPage()
		{
			var webView = new WebView();
			var html = new HtmlWebViewSource();
			html.BaseUrl = DependencyService.Get<IBaseUrl>().Get();
			html.Html = 
				@"<html>
					<head>
					<link rel=""stylesheet"" href=""style.css"">
					</head>
					<body>
					<h1>Xamarin.Forms</h1>
					<p>The CSS and image are loaded from local files!</p>
					</body>
				</html>";
			webView.Source = html;
			Content = webView;
			Title = "Local page";
		}
	}
}

