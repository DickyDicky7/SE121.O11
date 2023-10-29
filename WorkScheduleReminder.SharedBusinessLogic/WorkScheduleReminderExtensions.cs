using Supabase;
using WorkScheduleReminder.SharedBusinessLogic.Services.Abstractions___;
using WorkScheduleReminder.SharedBusinessLogic.Services.Implementations;

namespace Microsoft.Extensions.DependencyInjection
{
	public static partial class WorkScheduleReminderExtensions
	{
		public static IServiceCollection AddServicesAndExtensionsSharedBusinessLogic
				(this IServiceCollection    services)
		{
			string SUPABASE_URL = "https://cklxrwkqemlsayifnnvn.supabase.co";
			string SUPABASE_KEY = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.ey" +
			"Jpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImNrbHhyd2txZW1sc2F5aWZubnZuIiw" +
			"icm9sZSI6ImFub24iLCJpYXQiOjE2OTUyMTM2ODMsImV4cCI6MjAxMDc4OTY4" +
			"M30.HuP4n3fN3TPGnkoKcJOm4fM9awVeYw0WXBY4SjKA99w";
			Environment.SetEnvironmentVariable("SUPABASE_URL", SUPABASE_URL, EnvironmentVariableTarget.Process);
			Environment.SetEnvironmentVariable("SUPABASE_KEY", SUPABASE_KEY, EnvironmentVariableTarget.Process);
			return services.AddSingleton<Supabase.Client>(serviceProvider =>
			{
				IGotrueSessionPersistenceService gotrueSessionPersistenceService = serviceProvider.GetRequiredService<
				IGotrueSessionPersistenceService>();
				return new(SUPABASE_URL, SUPABASE_KEY, new SupabaseOptions()
				{
					SessionHandler =
					gotrueSessionPersistenceService,
					AutoRefreshToken = true, AutoConnectRealtime 
									 = true,
				});
			})             .AddSingleton<ObservableDictionaryTransferService>();
		}
	}
}
