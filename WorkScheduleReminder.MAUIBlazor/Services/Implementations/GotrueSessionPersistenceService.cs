using     WorkScheduleReminder.SharedBusinessLogic.Services.Abstractions___;

namespace WorkScheduleReminder.SharedBusinessLogic.Services.Implementations
{
	public class GotrueSessionPersistenceService : BaseGotrueSessionPersistenceService
	{
	public       GotrueSessionPersistenceService() : base() 
		{
		}

		public override string   CacheFileName => ".gotrue.cache";
		public override string   CacheDirectoryPath => FileSystem.  CacheDirectory;
		public override string AppDataDirectoryPath => FileSystem.AppDataDirectory;
	}
}
