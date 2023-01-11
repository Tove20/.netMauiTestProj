using Microsoft.AspNetCore.Components.WebView.Maui;
using MauiBlazorApp1.Data;
using Microsoft.Extensions.Configuration;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Popups;
using MauiBlazorApp1.NativeControls;
using Microsoft.Maui.Controls.Compatibility.Hosting;

//using ZXing.Net.Maui;

namespace MauiBlazorApp1;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCompatibility() //MAUI Compatibility for Android WebView
            // .UseBarcodeReader()
            .ConfigureFonts(fonts =>
			{
                fonts.AddFont("Roboto-Medium.ttf", "RobotoMedium");
                fonts.AddFont("Roboto-Regular.ttf", "Roboto");
            }).ConfigureMauiHandlers((handlers) =>
            {



#if ANDROID
                handlers.AddCompatibilityRenderer(typeof(HybridWebView), typeof(Platforms.Android.Renderers.HybridWebViewRenderer));
#elif IOS
                handlers.AddCompatibilityRenderer(typeof(HybridWebView), typeof(Platforms.iOS.Renderers.HybridWebViewRenderer));
#elif MACCATALYST
                handlers.AddCompatibilityRenderer(typeof(HybridWebView), typeof(Platforms.MacCatalyst.Renderers.HybridWebViewRenderer));
#endif
            });

        builder.Services.AddMauiBlazorWebView();
		#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		#endif

		//Syncfusion-Stuff
        builder.Services.AddSyncfusionBlazor();
        builder.Services.AddSingleton<SfDialogService>();

        builder.Services.AddMemoryCache();

        builder.Services.AddSingleton<WeatherForecastService>();
        var app = builder.Build();


        //Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense
        //(
        //   app.Configuration.GetValue<string>("LicenseKey")
        //);


        //Test 1
        //Test 2
        //Test 3

        return app;
    }
}
