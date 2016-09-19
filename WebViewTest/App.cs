using System;
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
			page.Children.Add(new LinePage(baseUrl));
			page.Children.Add(new WebPage());
			page.Children.Add(new PiePage(baseUrl));
			page.Children.Add(new LocalPage());
			page.Children.Add(new HybridPage());
			MainPage = page;
		}
	}
}

