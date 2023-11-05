using Moq;
using System.IO;
using System.Threading.Tasks;
using WorkScheduleReminder.SharedBusinessLogic.Services.Abstractions___;

namespace WorkScheduleReminder.Testing.BEUnitTests.SharedBusinessLogicUnitTests.ServicesUnitTests
{
	[TestFixture]
	[Parallelizable]
	[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
	public class BaseGotrueSessionPersistenceServiceUnitTests
	{
		public BaseGotrueSessionPersistenceServiceUnitTests()
		{
			instanceNumber = count++;
			cacheFileName = $".base.gotrue.{instanceNumber}.cache";
			baseGotrueSessionPersistenceService = Mock.Of<BaseGotrueSessionPersistenceService>(
			setup => setup.AppDataDirectoryPath == Path.GetTempPath() &&
			setup.CacheDirectoryPath == Path.GetTempPath() &&
			setup.CacheFileName == cacheFileName &&
			setup.CacheFilePath == Path.Join(Path.GetTempPath(), cacheFileName));
		}

		private static int count = 1;
		private readonly int instanceNumber;
		private readonly string cacheFileName;
		private readonly BaseGotrueSessionPersistenceService baseGotrueSessionPersistenceService;

		[TearDown]
		public void CleanUpAfterEachTest()
		{
			if (Path.Exists(baseGotrueSessionPersistenceService.CacheFilePath))
				File.Delete(baseGotrueSessionPersistenceService.CacheFilePath);
		}

		[Test]
		[Parallelizable]
		public void AppDataDirectoryPath_MustReturnTempPath()
		{
			/* --- ARRANGE --- */

			/* --- ACT --- */
			var appDataDirectoryPath = baseGotrueSessionPersistenceService.AppDataDirectoryPath; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(appDataDirectoryPath, Is.EqualTo(Path.GetTempPath()));
		}

		[Test]
		[Parallelizable]
		public void CacheDirectoryPath_MustReturnTempPath()
		{
			/* --- ARRANGE --- */

			/* --- ACT --- */
			var cacheDirectoryPath = baseGotrueSessionPersistenceService.CacheDirectoryPath; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(cacheDirectoryPath, Is.EqualTo(Path.GetTempPath()));
		}

		[Test]
		[Parallelizable]
		public void CacheFileName_MustReturnCorrectFormatNameForATestInstance()
		{
			/* --- ARRANGE --- */

			/* --- ACT --- */
			var cacheFileName = baseGotrueSessionPersistenceService.CacheFileName; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(cacheFileName, Is.EqualTo($".base.gotrue.{instanceNumber}.cache"));
		}

		[Test]
		[Parallelizable]
		public void CacheFilePath_MustReturnJoinPathOfCacheDirectoryPathAndCacheFileName()
		{
			/* --- ARRANGE --- */

			/* --- ACT --- */
			var cacheFilePath = baseGotrueSessionPersistenceService.CacheFilePath; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(cacheFilePath, Is.EqualTo(Path.Join(Path.GetTempPath(), $".base.gotrue.{instanceNumber}.cache")));
			Assert.That(cacheFilePath, Is.EqualTo(Path.Join(baseGotrueSessionPersistenceService.CacheDirectoryPath, baseGotrueSessionPersistenceService.CacheFileName)));
		}

		[Test]
		[Parallelizable]
		public void SaveSession_MustCreateCacheDirectory()
		{
			/* --- ARRANGE --- */
			var gotrueSession = new Supabase.Gotrue.Session();

			/* --- ACT --- */
			baseGotrueSessionPersistenceService.SaveSession(gotrueSession); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(Directory.Exists(baseGotrueSessionPersistenceService.CacheDirectoryPath), Is.True);
		}

		[Test]
		[Parallelizable]
		public void SaveSession_MustCreateCacheFile()
		{
			/* --- ARRANGE --- */
			var gotrueSession = new Supabase.Gotrue.Session();

			/* --- ACT --- */
			baseGotrueSessionPersistenceService.SaveSession(gotrueSession); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(Path.Exists(baseGotrueSessionPersistenceService.CacheFilePath), Is.True);
		}

		[Test]
		[Parallelizable]
		public async Task SaveSession_MustWriteSerializedGotrueSessionIntoCacheFile()
		{
			/* --- ARRANGE --- */
			var gotrueSession = new Supabase.Gotrue.Session();
			var gotrueSessionSerialized = Newtonsoft.Json.JsonConvert.SerializeObject(gotrueSession);

			/* --- ACT --- */
			baseGotrueSessionPersistenceService.SaveSession(gotrueSession); /* <-- HERE <-- */
			var gotrueSessionStoredInCacheFile = await File.ReadAllTextAsync(baseGotrueSessionPersistenceService.CacheFilePath);

			/* --- ASSERT --- */
			Assert.That(gotrueSessionSerialized, Is.EqualTo(gotrueSessionStoredInCacheFile));
		}

		[Test]
		[Parallelizable]
		public void LoadSession_MustCreateCacheDirectory()
		{
			/* --- ARRANGE --- */

			/* --- ACT --- */
			baseGotrueSessionPersistenceService.LoadSession(); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(Directory.Exists(baseGotrueSessionPersistenceService.CacheDirectoryPath), Is.True);
		}

		[Test]
		[Parallelizable]
		public void LoadSession_MustReturnFullSessionIfCacheFileExistedAndDataInCacheFileHasValidFormat()
		{
			/* --- ARRANGE --- */
			var gotrueSession = new Supabase.Gotrue.Session();

			/* --- ACT --- */
			baseGotrueSessionPersistenceService.SaveSession(gotrueSession);
			var returnGotrueSession = baseGotrueSessionPersistenceService.LoadSession(); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(returnGotrueSession, Is.Not.Null);
		}

		[Test]
		[Parallelizable]
		[TestCaseSource(sourceType: typeof(Helper), sourceName: nameof(Helper.GenerateAllPossibleStrings), methodParams: new object[] { 1 })]
		public async Task LoadSession_MustReturnNullSessionIfCacheFileExistedAndDataInCacheFileHasInvalidFormat(string content)
		{
			/* --- ARRANGE --- */

			/* --- ACT --- */
			await File.WriteAllTextAsync(baseGotrueSessionPersistenceService.CacheFilePath, content);
			var returnGotrueSession = baseGotrueSessionPersistenceService.LoadSession(); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(returnGotrueSession, Is.Null);
		}

		[Test]
		[Parallelizable]
		public void LoadSession_MustReturnNullSessionIfCacheFileNotExisted()
		{
			/* --- ARRANGE --- */

			/* --- ACT --- */
			var returnGotrueSession = baseGotrueSessionPersistenceService.LoadSession(); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(returnGotrueSession, Is.Null);
		}

		[Test]
		[Parallelizable]
		public void DestroySession_MustCreateCacheDirectory()
		{
			/* --- ARRANGE --- */

			/* --- ACT --- */
			baseGotrueSessionPersistenceService.DestroySession(); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(Directory.Exists(baseGotrueSessionPersistenceService.CacheDirectoryPath), Is.True);
		}

		[Test]
		[Parallelizable]
		public void DestroySession_MustCreateCacheFile()
		{
			/* --- ARRANGE --- */

			/* --- ACT --- */
			baseGotrueSessionPersistenceService.DestroySession(); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(Path.Exists(baseGotrueSessionPersistenceService.CacheFilePath), Is.True);
		}

		[Test]
		[Parallelizable]
		public async Task DestroySession_MustCreateCacheFileEmpty()
		{
			/* --- ARRANGE --- */

			/* --- ACT --- */
			baseGotrueSessionPersistenceService.DestroySession(); /* <-- HERE <-- */
			var content = await File.ReadAllTextAsync(baseGotrueSessionPersistenceService.CacheFilePath);

			/* --- ASSERT --- */
			Assert.That(content, Is.Empty);
		}

		[Test]
		[Parallelizable]
		public async Task DestroySession_MustMakeExistedCacheFileEmpty()
		{
			/* --- ARRANGE --- */
			var gotrueSession = new Supabase.Gotrue.Session();

			/* --- ACT --- */
			baseGotrueSessionPersistenceService.SaveSession(gotrueSession);
			baseGotrueSessionPersistenceService.DestroySession(); /* <-- HERE <-- */
			var content = await File.ReadAllTextAsync(baseGotrueSessionPersistenceService.CacheFilePath);

			/* --- ASSERT --- */
			Assert.That(content, Is.Empty);
		}
	}
}
