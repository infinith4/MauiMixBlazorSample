using Microsoft.Extensions.Logging;
using MauiMixBlazorSample.Data;
using CommunityToolkit.Maui;
using Camera.MAUI;

//#if __ANDROID__ || __IOS__
//using ZXing.Net.Maui;
//using ZXing.Net.Maui.Controls;
//#endif

namespace MauiMixBlazorSample;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.UseMauiCameraView()
//#if __ANDROID__ || __IOS__
//            .UseBarcodeReader()
//#endif
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});
   //         #if __ANDROID__ || __IOS__
			//.ConfigureMauiHandlers(h =>
   //         {
   //             h.AddHandler(typeof(ZXing.Net.Maui.Controls.CameraBarcodeReaderView), typeof(CameraBarcodeReaderViewHandler));
   //             h.AddHandler(typeof(ZXing.Net.Maui.Controls.CameraView), typeof(CameraViewHandler));
   //             h.AddHandler(typeof(ZXing.Net.Maui.Controls.BarcodeGeneratorView), typeof(BarcodeGeneratorViewHandler));
   //         });
			//#endif

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		builder.Services.AddSingleton<WeatherForecastService>();

		return builder.Build();
	}
}
