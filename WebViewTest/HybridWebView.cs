using System;
using Xamarin.Forms;

namespace WebViewTest
{
	public class HybridWebView : View
	{
		Action<string> _action;

		public static readonly BindableProperty UriProperty = BindableProperty.Create(
		  propertyName: "Uri",
		  returnType: typeof(string),
		  declaringType: typeof(HybridWebView),
		  defaultValue: default(string));

		public string Uri
		{
			get { return (string)GetValue(UriProperty); }
			set { SetValue(UriProperty, value); }
		}

		public void RegisterAction(Action<string> callback)
		{
			_action = callback;
		}

		public void Cleanup()
		{
			_action = null;
		}

		public void InvokeAction(string data)
		{
			if (_action == null || data == null)
			{
				return;
			}
			_action.Invoke(data);
		}
	}

	public class HybridPage : ContentPage
	{
		public HybridPage()
		{
			var hybridWebView = new HybridWebView
			{
				Uri = "hybrid.html",
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand
			};

    		hybridWebView.RegisterAction(
				data => 
         			DisplayAlert("Alert", "Hello " + data, "OK")
            );

			Title = "Hybrid";
			Padding = new Thickness(0, 20, 0, 0);
			Content = hybridWebView;
		}
	}
}
