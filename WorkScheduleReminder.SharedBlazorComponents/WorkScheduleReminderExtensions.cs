using MudBlazor.Services;
using MudExtensions.Services;

namespace Microsoft.Extensions.DependencyInjection
{
	public static partial class WorkScheduleReminderExtensions
	{
		public static IServiceCollection AddServicesAndExtensionsSharedBlazorComponents
				(this IServiceCollection    services) => services.AddMudServices().AddMudExtensions();
	}
}
