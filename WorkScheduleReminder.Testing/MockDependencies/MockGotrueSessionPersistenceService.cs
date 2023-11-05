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

		public override string AppDataDirectoryPath => Path.GetTempPath();
		public override string   CacheDirectoryPath => Path.GetTempPath();
		public override string   CacheFileName => $".mock.gotrue.{instanceNumber}.cache";
	}
}
