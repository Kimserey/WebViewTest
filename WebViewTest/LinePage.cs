using System;
using Xamarin.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WebViewTest
{
	public class ResizableWebView : WebView {}

	public class Data { 
		public string[] X { get; set; }
		public double[] Y { get; set; }
		public string Name { get; set; }
	}

	public class LinePage : ContentPage
	{
		public LinePage()
		{
			var webView = new ResizableWebView();
			var html = new HtmlWebViewSource();
			html.BaseUrl = DependencyService.Get<IBaseUrl>().Get();

			var jsonSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };

			var data = new[] { 
				new Data {
					X = new[] { "2013-04-15", "2013-11-06", "2013-12-04", "2014-02-06" },
					Y = new[] { 2.4, 30, 34, 20.1 },
					Name = "Supermarket" 
				},
				new Data {
					X = new[] { "2013-10-04", "2013-11-04", "2013-12-06" },
					Y = new[] { 1.0, 3.0, 6.0 },
					Name = "Leisure"
				}
			};

			var meta = JsonConvert.SerializeObject(data, jsonSettings);

			var js =
				 @"(function() {
		            var data =
		                JSON.parse(
		                    document
		                    .querySelector(""meta[name='line-data']"")
		                    .getAttribute('content')
		                );

		            var plot =
		                Plotly.d3
		                .select('body')
		                .append('div')
		                .style({
		                    width: '100%',
		                    'margin-top': '5%',
		                    height: '90%'
		                })
		                .node();

		            var layout = {
		                margin: {
		                    l: 30,
		                    r: 20,
		                    b: 30,
		                    t: 30,
							pad: 5
		                },  
		                showlegend: false
		            };

		            var config = {
		                displayModeBar: false
		            };

		            Plotly.plot(plot, data, layout, config);

		            window.onresize = function() {
		                Plotly.Plots.resize(plot);
		            };
		        })();";

			html.Html = 
				"<html>"
				+ "<head>"
		    	+ 	"<link rel=\"stylesheet\" href=\"style.css\">"
				+ 	"<script src=\"plotly-latest.min.js\"></script>"
				+ 	"<meta id=\"line-data\" name=\"line-data\" content='"+ meta + "'>"
				+ "</head>"
				+ "<body>"
			    + 	"<script>" + js + "</script>"       
				+ "</body>"
				+ "</html>";
			
			webView.Source = html;
			Content = webView;
			Title = "Line page";
		}
	}
}


