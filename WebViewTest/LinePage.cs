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
					    <script>
					        (function() {
					            var d3 = Plotly.d3;

					            var gd3 = d3.select('body')
					                .append('div')
					                .style({
					                    width: '100%',
					                    'margin-top': '5%',
					                    height: '90%'
					                });

					            var gd = gd3.node();

					            var trace1 = {
					                x: ['2013-04-15', '2013-11-06', '2013-12-04', '2014-02-06'],
					                y: [2.4, 30, 34, 20.1],
					                type: 'scatter',
					                name: 'Supermarket'
					            };

					            var trace2 = {
					                x: ['2013-10-04', '2013-11-04', '2013-12-06'],
					                y: [1, 3, 6],
					                type: 'scatter',
					                name: 'Other'
					            };

					            var data = [trace1, trace2];

					            var layout = {
					                margin: {
					                    l: 20,
					                    r: 20,
					                    b: 30,
					                    t: 20,
					                    pad: 5
					                },
					                legend: {
					                    y: 1,
					                    orientation: 'h'
					                }
					            };

					            var config = {
					                displayModeBar: false
					            };

					            Plotly.plot(gd, data, layout, config);

					            window.onresize = function() {
					                Plotly.Plots.resize(gd);
					            };
					        })();
					    </script>
					</body>
				</html>";
			webView.Source = html;
			Content = webView;
			Title = "Local page";
		}
	}
}


