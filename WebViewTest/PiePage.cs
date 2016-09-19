using System;
using Xamarin.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using WebViewTest;

namespace WebViewTest
{
	public class PiePage: ContentPage
	{
		public class Data
		{
			public string[] Labels { get; set; }
			public int[] Values { get; set; }
			public string Type { get; set; }
		}

		public PiePage(string baseUrl)
		{			
			var webView = new ResizableWebView(baseUrl);
			
			var data = new[] {
				new Data {
					Labels = new[] { "Residential", "Non-Residential", "Utility" },
					Values = new[] { 19, 26, 55 },
					Type = "pie",
				}
			};

			var meta = JsonConvert.SerializeObject(data, App.JSON_SETTINGS);

			var js =
				 @"(function() {
	            var data =
	                JSON.parse(
	                    document
	                    .querySelector(""meta[name='data']"")
	                    .getAttribute('content')
	                );

	            var plot =
	                Plotly.d3
	                .select('body')
	                .append('div')
	                .style({
	                    width: '100%',
	                    'margin-top': '5%',
	                    height: '90%',
						border: '1px solid black'
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
					height: 400,
  					width: 500
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
				+ "<meta id=\"data\" name=\"data\" content='" + meta + "'>"
				+ "</head>"
				+ "<body>"
				+ "<script>" + js + "</script>"
				+ "</body>"
				+ "</html>");

			Content = webView;
			Title = "Pie";
		}
	}
}
