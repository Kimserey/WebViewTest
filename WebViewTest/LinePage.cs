using System;
using Xamarin.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WebViewTest
{
	public class LineShape { 
		public string Shape { get; set; }
	} 

	public class Data { 
		public string[] X { get; set; }
		public double[] Y { get; set; }
		public LineShape Line { get; set; }
		public string Name { get; set; }
	}

	public class LinePage : ContentPage
	{
		public LinePage(string baseUrl)
		{
			var webView = new ResizableWebView(baseUrl);

			var data = new[] { 
				new Data {
					X = new[] { "2013-04-15", "2013-11-06", "2013-12-04", "2014-02-06" },
					Y = new[] { 2.4, 30, 34, 20.1 },
					Line = new LineShape { Shape = "spline" },
					Name = "Supermarket" 
				},
				new Data {
					X = new[] { "2013-10-04", "2013-11-04", "2013-12-06" },
					Y = new[] { 1.0, 3.0, 6.0 },
					Line = new LineShape { Shape = "spline" },
					Name = "Leisure"
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
		                    l: 40,
		                    r: 20,
		                    b: 40,
		                    t: 30,
							pad: 5
		                },
						font: {
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
		    	+ 	"<link rel=\"stylesheet\" href=\"style.css\">"
				+ 	"<script src=\"plotly-latest.min.js\"></script>"
				+ 	"<meta id=\"line-data\" name=\"line-data\" content='"+ meta + "'>"
				+ "</head>"
				+ "<body>"
			    + 	"<script>" + js + "</script>"       
				+ "</body>"
			                + "</html>");
			
			Content = webView;
			Title = "Line";
		}
	}
}


