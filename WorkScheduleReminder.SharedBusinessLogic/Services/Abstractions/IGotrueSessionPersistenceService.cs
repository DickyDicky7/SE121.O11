using Supabase.Gotrue;
using Supabase.Gotrue.Interfaces;

namespace WorkScheduleReminder.SharedBusinessLogic.Services.Abstractions___
{
	public interface IGotrueSessionPersistenceService : IGotrueSessionPersistence<Session>
	{
		string   CacheFileName { get; }
		string   CacheFilePath { get; }
		string AppDataDirectoryPath { get; }
		string   CacheDirectoryPath { get; }
	}
}
