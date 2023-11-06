using System.IO;
using WorkScheduleReminder.SharedBusinessLogic.Services.Abstractions___;
using WorkScheduleReminder.Testing.BEUnitTests.SharedBusinessLogicUnitTests.ServicesUnitTests;

namespace WorkScheduleReminder.Testing.MockDependencies
{
	public class MockGotrueSessionPersistenceService : BaseGotrueSessionPersistenceService
	{
		public MockGotrueSessionPersistenceService() : base()
		{
			instanceNumber = count++;
			MockGotrueSessionPersistenceServiceUnitTests.MockGotrueSessionPersistenceServices.Add(this);
		}

		private   static int count = 1;
		private readonly int instanceNumber;

		public override string AppDataDirectoryPath => Path.Join(Path.GetTempPath(), $"WorkScheduleReminderAppDa{instanceNumber}");
		public override string   CacheDirectoryPath => Path.Join(Path.GetTempPath(), $"WorkScheduleReminderCache{instanceNumber}");
		public override string   CacheFileName => $".mock.gotrue.{instanceNumber}.cache";
	}
}
