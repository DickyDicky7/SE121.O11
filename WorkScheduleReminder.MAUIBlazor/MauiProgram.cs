using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace WorkScheduleReminder.MAUIBlazor
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			//Environment.SetEnvironmentVariable("WEBVIEW2_BROWSER_EXECUTABLE_FOLDER", @"C:\Users\User\Downloads\Microsoft.WebView2.FixedVersionRuntime.118.0.2088.76.x64");

			AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

			MauiAppBuilder builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.UseMauiCommunityToolkit()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				});

#if DEBUG
			builder.Services.AddBlazorWebViewDeveloperTools(); builder.Logging.AddDebug();
#endif

			builder.Services.AddMauiBlazorWebView();
			builder.Services.AddServicesAndExtensionsMAUIBlazor();

			return builder.Build();
		}

		private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine((e.ExceptionObject as Exception).Message);
		}
	}
}
