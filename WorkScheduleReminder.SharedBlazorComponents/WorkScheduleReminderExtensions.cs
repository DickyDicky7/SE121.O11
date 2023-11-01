using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using MudBlazor.Services;
using MudExtensions.Services;
using WorkScheduleReminder.SharedBlazorComponents.Services.Implementations;

namespace Microsoft.Extensions.DependencyInjection
{
	public static partial class WorkScheduleReminderExtensions
	{
		public static IServiceCollection AddServicesAndExtensionsSharedBlazorComponents
				(this IServiceCollection    services) => services
			.AddMudServices(configuration =>
			{
				configuration.SnackbarConfiguration.PreventDuplicates = true;
				configuration.SnackbarConfiguration.VisibleStateDuration = 10000;
				configuration.SnackbarConfiguration.HideTransitionDuration = 500;
				configuration.SnackbarConfiguration.ShowTransitionDuration = 500;
				configuration.SnackbarConfiguration.ShowCloseIcon = true;
				configuration.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomCenter;
				
			})
			.AddMudExtensions()
			.AddSingleton<
				  SupabaseAuthenticationStateProviderService>
			(serviceProvider =>
			{
				Supabase.Client supabaseClient = serviceProvider.GetRequiredService<
				Supabase.Client>();
				return new(supabaseClient);
			})
			.AddSingleton<AuthenticationStateProvider,
				  SupabaseAuthenticationStateProviderService>
			(serviceProvider =>
			{
				SupabaseAuthenticationStateProviderService
				supabaseAuthenticationStateProviderService = serviceProvider.GetRequiredService<
				SupabaseAuthenticationStateProviderService>();
				return
				supabaseAuthenticationStateProviderService;
			})
			.AddAuthorizationCore()
			.AddServicesAndExtensionsSharedBusinessLogic();
	}
}
