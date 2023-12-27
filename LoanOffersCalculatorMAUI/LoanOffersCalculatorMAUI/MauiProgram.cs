using Microsoft.AspNetCore.Components.WebView.Maui;
using LoanOffersCalculatorMAUI.Data;
using MetroLog.MicrosoftExtensions;
using Microsoft.Extensions.Logging;
using LoanOffersCalculatorMAUI.Services;
using Microsoft.Extensions.DependencyInjection;
using LoanOffersCalculatorMAUI.ViewModel;
using Microsoft.Extensions.Http;

namespace LoanOffersCalculatorMAUI;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();
		#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif

        builder.Logging
     .SetMinimumLevel(LogLevel.Trace) // IMPORTANT: set your minimum log level, here Trace
     .AddTraceLogger(
         options =>
         {
             options.MinLevel = LogLevel.Trace;
             options.MaxLevel = LogLevel.Critical;
         }) // Will write to the Debug Output
     .AddConsoleLogger(
         options =>
         {
             options.MinLevel = LogLevel.Information;
             options.MaxLevel = LogLevel.Critical;
         }) // Will write to the Console Output (logcat for android)
     .AddInMemoryLogger(
         options =>
         {
             options.MaxLines = 1024;
             options.MinLevel = LogLevel.Debug;
             options.MaxLevel = LogLevel.Critical;
         })
     .AddStreamingFileLogger(
         options =>
         {
             options.RetainDays = 2;
             options.FolderPath = Path.Combine(
                 "D:\\LoggingDemo\\",
                 "MetroLogs");
         });

		builder.Services.AddSingleton<WeatherForecastService>();


        builder.Services.AddHttpClient<IAppService<ToDoModel>, AppService<ToDoModel>>();
        builder.Services.AddSingleton<HttpClient>();

        return builder.Build();
	}
}
