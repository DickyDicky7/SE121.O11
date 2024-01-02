using CommunityToolkit.Maui;
using H.NotifyIcon;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;

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
				.UseMauiApp<App>().UseNotifyIcon()
				.UseMauiCommunityToolkit()
				.ConfigureLifecycleEvents(lifecycleEvents =>
				{
#if WINDOWS
					lifecycleEvents.AddWindows(windowsLifecycleBuilder =>
					{
						windowsLifecycleBuilder.OnWindowCreated(window =>
						{
							var windowHandle = WinRT.Interop.WindowNative.GetWindowHandle(window);
							var _idWindow = Microsoft.UI.Win32Interop    .GetWindowIdFromWindow(windowHandle);
							var appWindow = Microsoft.UI.Windowing
							   .AppWindow.GetFromWindowId(_idWindow);

							appWindow.Closing += async (sender, appWindow_ClosingEventArgs) =>
							{
							appWindow_ClosingEventArgs.Cancel = true;
							appWindow.Hide();
								await System.Threading.Tasks.Task.CompletedTask;
							};
						});   
					});
#endif
				})
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
