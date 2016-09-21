using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Xamarin.Forms;

namespace WebViewTest
{
	public interface IBaseUrl { string Get(); }

	public class App : Application
	{
		public static readonly JsonSerializerSettings JSON_SETTINGS = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };

		public App()
		{
			var baseUrl = DependencyService.Get<IBaseUrl>().Get();
			
			var page = new TabbedPage();

			var layout = new StackLayout { Padding = new Thickness(10, 50) };
			layout.Children.Add(new Label { Text = "Must put something here other than webpage for overview" });
			page.Children.Add(new ContentPage { Title = "Overview", Content = layout });
			page.Children.Add(new PiePage(baseUrl));
			page.Children.Add(new LinePage(baseUrl));
			page.Children.Add(new WebPage());
			page.Children.Add(new LocalPage());
			page.Children.Add(new HybridPage());
			MainPage = page;
		}
	}
}

