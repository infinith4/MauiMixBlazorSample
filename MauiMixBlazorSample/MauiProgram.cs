using Microsoft.Extensions.Logging;
using MauiMixBlazorSample.Data;
using CommunityToolkit.Maui;
#if __ANDROID__ || __IOS__
using ZXing.Net.Maui.Controls;
#endif

namespace MauiMixBlazorSample;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
#if __ANDROID__ || __IOS__
            .UseBarcodeReader()
#endif
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		builder.Services.AddSingleton<WeatherForecastService>();

		return builder.Build();
	}
}
