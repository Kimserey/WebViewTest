using System;
using Xamarin.Forms;

namespace WebViewTest
{
	public class ResizableWebView : WebView {}

	public class LinePage : ContentPage
	{
		public LinePage()
		{
			var webView = new ResizableWebView();
			var html = new HtmlWebViewSource();
			html.BaseUrl = DependencyService.Get<IBaseUrl>().Get();
			html.Html = 
				@"<html>
					<head>
					    <link rel=""stylesheet"" href=""style.css"">
					    <script src=""plotly-latest.min.js""></script>
					</head>

					<body>
					    <div id=""myDiv"" style=""width: 100%; height: 400px;"">
					    <script>
					        var trace1 = {
					            x: [1, 2, 3, 4],
					            y: [10, 15, 13, 17],
					            type: 'scatter'
					        };

					        var trace2 = {
					            x: [1, 2, 3, 4],
					            y: [16, 5, 11, 9],
					            type: 'scatter'
					        };

					        var data = [trace1, trace2];

					        var layout = {
					            margin: {
					                l: 20,
					                r: 20,
					                b: 20,
					                t: 20,
					                pad: 5
					            }
					        };

					        Plotly.newPlot('myDiv', data, layout, {
					            displayModeBar: false
					        });
					    </script>
					</body>
				</html>";
			webView.Source = html;
			Content = webView;
			Title = "Local page";
		}
	}
}

