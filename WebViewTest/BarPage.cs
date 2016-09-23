using System;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace WebViewTest
{
	public class BarPage : ContentPage
	{
		public class Data
		{
			public string[] X { get; set; }
			public double[] Y { get; set; }
			public string Type { get; set; }
			public string Orientation { get; set; }
		}

		public BarPage(string baseUrl)
		{
			var webView = new ResizableWebView(baseUrl);

			var data = new[] {
				new Data {
					X = new[] { "Dog", "Cat", "Fish" },
					Y = new[] { 24.0, 30.0, 34.0 },
					Orientation = "v",
					Type = "bar"
				},
				new Data {
					X = new[] { "Dog", "Cat", "Fish" },
					Y = new[] { 10.0, 30.0, 60.0 },
					Orientation = "v",
					Type = "bar"
				}
			};

			var meta = JsonConvert.SerializeObject(data, App.JSON_SETTINGS);

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
		                    l: 150,
		                    r: 20,
		                    b: 40,
		                    t: 30,
							pad: 5
		                },
						font: {
							size: 25
						},
						marker: {
							size: 25
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

			webView.SetHtml(
				"<html>"
				+ "<head>"
				+ "<link rel=\"stylesheet\" href=\"style.css\">"
				+ "<script src=\"plotly-latest.min.js\"></script>"
				+ "<meta id=\"line-data\" name=\"line-data\" content='" + meta + "'>"
				+ "</head>"
				+ "<body>"
				+ "<script>" + js + "</script>"
				+ "</body>"
							+ "</html>");

			Content = webView;
			Title = "Bar";
		}
	}
}
