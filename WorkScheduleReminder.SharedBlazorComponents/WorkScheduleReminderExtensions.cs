using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor.Services;
using MudExtensions.Services;
using WorkScheduleReminder.SharedBlazorComponents.Services.Implementations;

namespace Microsoft.Extensions.DependencyInjection
{
	public static partial class WorkScheduleReminderExtensions
	{
		public static IServiceCollection AddServicesAndExtensionsSharedBlazorComponents
				(this IServiceCollection    services) => services.AddMudServices().AddMudExtensions()
			.AddSingleton<AuthenticationStateProvider,
				  SupabaseAuthenticationStateProviderService>
			(serviceProvider =>
			{
				Supabase.Client supabaseClient = serviceProvider.GetRequiredService<
				Supabase.Client>();
				return new(supabaseClient);
			})
			.AddAuthorizationCore()
			.AddServicesAndExtensionsSharedBusinessLogic();
	}
}
