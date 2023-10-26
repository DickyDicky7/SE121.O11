using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace WorkScheduleReminder.MAUIBlazor
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
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
	}
}
