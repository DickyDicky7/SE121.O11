using WorkScheduleReminder.SharedBusinessLogic.Services.Abstractions___;
using WorkScheduleReminder.SharedBusinessLogic.Services.Implementations;

namespace Microsoft.Extensions.DependencyInjection
{
	public static partial class WorkScheduleReminderExtensions
	{
		public static IServiceCollection AddServicesAndExtensionsMAUIBlazor
				(this IServiceCollection    services)
		=> services.AddSingleton<IGotrueSessionPersistenceService,
								  GotrueSessionPersistenceService>().AddServicesAndExtensionsSharedBusinessLogic()
				   .AddServicesAndExtensionsSharedBlazorComponents();
	}
}
