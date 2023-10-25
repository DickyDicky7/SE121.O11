#nullable enable
using Supabase.Gotrue;

namespace Microsoft.Extensions.DependencyInjection
{
	public static partial class WorkScheduleReminderExtensions
	{
		public static IServiceCollection AddServicesAndExtensionsMAUIBlazor
				(this IServiceCollection    services,
				 Func<Session?, Task> onGotrueSessionSave,
				 Func<Task<Session?>> onGotrueSessionLoad,
				 Func<Task> onGotrueSessionDestroy)
        => services.AddServicesAndExtensionsSharedBusinessLogic(
		         onGotrueSessionSave: onGotrueSessionSave,
		         onGotrueSessionLoad: onGotrueSessionLoad,
		         onGotrueSessionDestroy: onGotrueSessionDestroy).AddServicesAndExtensionsSharedBlazorComponents();
	}
}
