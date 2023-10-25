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
			builder.Services.AddServicesAndExtensionsMAUIBlazor(
				onGotrueSessionSave: OnGotrueSessionSave,
				onGotrueSessionLoad: OnGotrueSessionLoad,
				onGotrueSessionDestroy: OnGotrueSessionDestroy
			);

			return builder.Build();
		}

		public static async Task OnGotrueSessionSave(Supabase.Gotrue.Session gotrueSession) 
		{
			try
			{
				string cacheFileName = ".gotrue.cache";
				Directory.CreateDirectory       (FileSystem.CacheDirectory);
				string cacheFilePath = Path.Join(FileSystem.CacheDirectory, cacheFileName);
			await    File.WriteAllTextAsync(cacheFilePath, Newtonsoft.Json.JsonConvert.SerializeObject(gotrueSession));
			}
			catch (Exception exception)
			{
				System.Diagnostics.Debug.WriteLine($"UNABLE TO WRITE THE GOTRUE CACHE FILE: {exception.Message}");
			}
		}

#nullable enable
		public static async Task OnGotrueSessionDestroy()
		{
			try
			{
				string cacheFileName = ".gotrue.cache";
				Directory.CreateDirectory       (FileSystem.CacheDirectory);
				string cacheFilePath = Path.Join(FileSystem.CacheDirectory, cacheFileName);
			await	 File.WriteAllTextAsync(cacheFilePath,  string.Empty  );
			}
			catch (Exception exception)
			{
				System.Diagnostics.Debug.WriteLine($"UNABLE TO CLEAR THE GOTRUE CACHE FILE: {exception.Message}");
			}
		}

		public static Task<Supabase.Gotrue.Session?> OnGotrueSessionLoad()
		{
			try
			{
				string cacheFileName = ".gotrue.cache";
				Directory.CreateDirectory       (FileSystem.CacheDirectory);
				string cacheFilePath = Path.Join(FileSystem.CacheDirectory, cacheFileName);
			    return Task
				.FromResult(Newtonsoft.Json.JsonConvert.DeserializeObject<Supabase.Gotrue.Session>(File.ReadAllText(cacheFilePath)));
			}
			catch (Exception exception)
			{
				System.Diagnostics.Debug.WriteLine($"UNABLE TO @READ THE GOTRUE CACHE FILE: {exception.Message}");
				return Task.FromResult<Supabase.Gotrue.Session?>(null);
			}
		}
	}
}
