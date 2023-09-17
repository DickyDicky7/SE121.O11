using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using MudBlazor.Services;
using MudExtensions.Services;

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

			builder.Services.AddMauiBlazorWebView();
			builder.Services.AddMudServices();
			builder.Services.AddMudExtensions();

#if DEBUG
			builder.Services.AddBlazorWebViewDeveloperTools(); builder.Logging.AddDebug();
#endif

			return builder.Build();
		}
	}
}