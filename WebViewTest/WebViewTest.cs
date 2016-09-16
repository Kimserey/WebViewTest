﻿using System;

using Xamarin.Forms;

namespace WebViewTest
{
	public interface IBaseUrl { string Get(); }

	public class BaseUrlWebView : WebView { }

	public class App : Application
	{
		public App()
		{
			var page = new TabbedPage();
			page.Children.Add(new WebPage());
			page.Children.Add(new LocalPage());
			MainPage = page;
		}
	}


}

