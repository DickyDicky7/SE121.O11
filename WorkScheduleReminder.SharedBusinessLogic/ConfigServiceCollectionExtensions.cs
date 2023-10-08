using Microsoft.Extensions.DependencyInjection;

namespace WorkScheduleReminder.SharedBusinessLogic
{
	public static class ConfigServiceCollectionExtensions
	{
		public static IServiceCollection AddSharedBusinessLogicServices(this IServiceCollection services)
		{
			return services;
		}
	}
}
