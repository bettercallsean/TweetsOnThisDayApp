using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using RestSharp;
using TweetsOnThisDay.Interfaces;
using TweetsOnThisDay.Services;

namespace TweetsOnThisDay;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();

		builder.Services.AddSingleton<IRestClient>(new RestClient(new HttpClient()))
			.AddSingleton<IHtmlToImageService, HtmlToImageService>();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
