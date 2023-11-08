using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WorkScheduleReminder.Testing.MockDependencies;

namespace WorkScheduleReminder.Testing.BEUnitTests.SharedBusinessLogicUnitTests.ServicesUnitTests
{
	[TestFixture]
	[Parallelizable]
	[FixtureLifeCycle(LifeCycle.SingleInstance)]
	public class MockGotrueSessionPersistenceServiceUnitTests
	{
		public static List<MockGotrueSessionPersistenceService> MockGotrueSessionPersistenceServices { get; } = new();
		public static int TraceListenerIndex { get; set; } = -1;

		[OneTimeSetUp]
		public static void OnStartJustOnce()
		{
			TraceListenerIndex = Trace.Listeners.Add(new MockTraceListener(nameof(MockGotrueSessionPersistenceServiceUnitTests)));
		}

		[OneTimeTearDown]
		public static void CleanUpJustOnce()
		{
			Trace.Listeners.RemoveAt(TraceListenerIndex);
			foreach (var mockGotrueSessionPersistenceService in MockGotrueSessionPersistenceServices)
			{
				if (Directory.Exists(mockGotrueSessionPersistenceService.CacheDirectoryPath))
					Directory.Delete(mockGotrueSessionPersistenceService.CacheDirectoryPath, true);
				if (Directory.Exists(mockGotrueSessionPersistenceService.AppDataDirectoryPath))
					Directory.Delete(mockGotrueSessionPersistenceService.AppDataDirectoryPath, true);
			}
		}

		[Test]
		[Parallelizable]
		public void SaveSession_MustCreateCacheDirectory()
		{
			/* --- ARRANGE --- */
			var gotrueSession = new Supabase.Gotrue.Session();
			var mockGotrueSessionPersistenceService = new MockGotrueSessionPersistenceService();

			/* --- ACT --- */
			mockGotrueSessionPersistenceService.SaveSession(gotrueSession); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(Directory.Exists(mockGotrueSessionPersistenceService.CacheDirectoryPath), Is.True);
		}

		[Test]
		[Parallelizable]
		public void SaveSession_MustCreateCacheFile()
		{
			/* --- ARRANGE --- */
			var gotrueSession = new Supabase.Gotrue.Session();
			var mockGotrueSessionPersistenceService = new MockGotrueSessionPersistenceService();

			/* --- ACT --- */
			mockGotrueSessionPersistenceService.SaveSession(gotrueSession); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(Path.Exists(mockGotrueSessionPersistenceService.CacheFilePath), Is.True);
		}

		[Test]
		[Parallelizable]
		public async Task SaveSession_MustWriteSerializedGotrueSessionIntoCacheFile()
		{
			/* --- ARRANGE --- */
			var gotrueSession = new Supabase.Gotrue.Session();
			var gotrueSessionSerialized = Newtonsoft.Json.JsonConvert.SerializeObject(gotrueSession);
			var mockGotrueSessionPersistenceService = new MockGotrueSessionPersistenceService();

			/* --- ACT --- */
			mockGotrueSessionPersistenceService.SaveSession(gotrueSession); /* <-- HERE <-- */
			var gotrueSessionStoredInCacheFile = await File.ReadAllTextAsync(mockGotrueSessionPersistenceService.CacheFilePath);

			/* --- ASSERT --- */
			Assert.That(gotrueSessionSerialized, Is.EqualTo(gotrueSessionStoredInCacheFile));
		}

		[Test]
		[Parallelizable]
		public void LoadSession_MustCreateCacheDirectory()
		{
			/* --- ARRANGE --- */
			var mockGotrueSessionPersistenceService = new MockGotrueSessionPersistenceService();

			/* --- ACT --- */
			mockGotrueSessionPersistenceService.LoadSession(); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(Directory.Exists(mockGotrueSessionPersistenceService.CacheDirectoryPath), Is.True);
		}

		[Test]
		[Parallelizable]
		public void LoadSession_MustReturnFullSessionIfCacheFileExistedAndDataInCacheFileHasValidFormat()
		{
			/* --- ARRANGE --- */
			var gotrueSession = new Supabase.Gotrue.Session();
			var mockGotrueSessionPersistenceService = new MockGotrueSessionPersistenceService();

			/* --- ACT --- */
			mockGotrueSessionPersistenceService.SaveSession(gotrueSession);
			var returnGotrueSession = mockGotrueSessionPersistenceService.LoadSession(); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(returnGotrueSession, Is.Not.Null);
		}

		[Test]
		[Parallelizable]
		[TestCaseSource(sourceType: typeof(Helper), sourceName: nameof(Helper.GenerateAllPossibleStrings), methodParams: new object[] { 1 })]
		public async Task LoadSession_MustReturnNullSessionIfCacheFileExistedAndDataInCacheFileHasInvalidFormat(string content)
		{
			/* --- ARRANGE --- */
			var mockGotrueSessionPersistenceService = new MockGotrueSessionPersistenceService();

			/* --- ACT --- */
			Directory.CreateDirectory(mockGotrueSessionPersistenceService.CacheDirectoryPath);
			await File.WriteAllTextAsync(mockGotrueSessionPersistenceService.CacheFilePath, content);
			var returnGotrueSession = mockGotrueSessionPersistenceService.LoadSession(); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(returnGotrueSession, Is.Null);
		}

		[Test]
		[Parallelizable]
		public void LoadSession_MustReturnNullSessionIfCacheFileNotExisted()
		{
			/* --- ARRANGE --- */
			var mockGotrueSessionPersistenceService = new MockGotrueSessionPersistenceService();

			/* --- ACT --- */
			var returnGotrueSession = mockGotrueSessionPersistenceService.LoadSession(); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(returnGotrueSession, Is.Null);
		}

		[Test]
		[Parallelizable]
		public void DestroySession_MustCreateCacheDirectory()
		{
			/* --- ARRANGE --- */
			var mockGotrueSessionPersistenceService = new MockGotrueSessionPersistenceService();

			/* --- ACT --- */
			mockGotrueSessionPersistenceService.DestroySession(); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(Directory.Exists(mockGotrueSessionPersistenceService.CacheDirectoryPath), Is.True);
		}

		[Test]
		[Parallelizable]
		public void DestroySession_MustCreateCacheFile()
		{
			/* --- ARRANGE --- */
			var mockGotrueSessionPersistenceService = new MockGotrueSessionPersistenceService();

			/* --- ACT --- */
			mockGotrueSessionPersistenceService.DestroySession(); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(Path.Exists(mockGotrueSessionPersistenceService.CacheFilePath), Is.True);
		}

		[Test]
		[Parallelizable]
		public async Task DestroySession_MustCreateCacheFileEmpty()
		{
			/* --- ARRANGE --- */
			var mockGotrueSessionPersistenceService = new MockGotrueSessionPersistenceService();

			/* --- ACT --- */
			mockGotrueSessionPersistenceService.DestroySession(); /* <-- HERE <-- */
			var content = await File.ReadAllTextAsync(mockGotrueSessionPersistenceService.CacheFilePath);

			/* --- ASSERT --- */
			Assert.That(content, Is.Empty);
		}

		[Test]
		[Parallelizable]
		public async Task DestroySession_MustMakeExistedCacheFileEmpty()
		{
			/* --- ARRANGE --- */
			var gotrueSession = new Supabase.Gotrue.Session();
			var mockGotrueSessionPersistenceService = new MockGotrueSessionPersistenceService();

			/* --- ACT --- */
			mockGotrueSessionPersistenceService.SaveSession(gotrueSession);
			mockGotrueSessionPersistenceService.DestroySession(); /* <-- HERE <-- */
			var content = await File.ReadAllTextAsync(mockGotrueSessionPersistenceService.CacheFilePath);

			/* --- ASSERT --- */
			Assert.That(content, Is.Empty);
		}

		[Test]
		[Parallelizable]
		public void SaveSession_MustDebugUnableToWriteTheGotrueCacheFileIfAnyErrorsOccurred()
		{
			/* --- ARRANGE --- */
			var traceListener = Trace.Listeners[TraceListenerIndex] as MockTraceListener;
			var gotrueSession = new Supabase.Gotrue.Session();
			var mockGotrueSessionPersistenceService = new MockGotrueSessionPersistenceService();

			/* --- ACT --- */
			Directory.CreateDirectory(mockGotrueSessionPersistenceService.CacheDirectoryPath);
			File.Create(mockGotrueSessionPersistenceService.CacheFilePath).Close();
			using (var __ = File.Open(mockGotrueSessionPersistenceService.CacheFilePath, FileMode.Open))
			{
				mockGotrueSessionPersistenceService.SaveSession(gotrueSession); /* <-- HERE <-- */
			}

			/* --- ASSERT --- */
			Assert.That(traceListener, Is.Not.Null);
			Assert.That(traceListener?.DebugOutputs.Any(debugOutput => debugOutput.StartsWith($"{Environment.CurrentManagedThreadId}: UNABLE TO WRITE THE GOTRUE CACHE FILE:")), Is.True);
		}

		[Test]
		[Parallelizable]
		public void LoadSession_MustDebugUnableTo_ReadTheGotrueCacheFileIfAnyErrorsOccurred()
		{
			/* --- ARRANGE --- */
			var traceListener = Trace.Listeners[TraceListenerIndex] as MockTraceListener;
			var mockGotrueSessionPersistenceService = new MockGotrueSessionPersistenceService();

			/* --- ACT --- */
			Directory.CreateDirectory(mockGotrueSessionPersistenceService.CacheDirectoryPath);
			File.Create(mockGotrueSessionPersistenceService.CacheFilePath).Close();
			using (var __ = File.Open(mockGotrueSessionPersistenceService.CacheFilePath, FileMode.Open))
			{
				mockGotrueSessionPersistenceService.LoadSession(); /* <-- HERE <-- */
			}

			/* --- ASSERT --- */
			Assert.That(traceListener, Is.Not.Null);
			Assert.That(traceListener?.DebugOutputs.Any(debugOutput => debugOutput.StartsWith($"{Environment.CurrentManagedThreadId}: UNABLE TO @READ THE GOTRUE CACHE FILE:")), Is.True);
		}

		[Test]
		[Parallelizable]
		public void DestroySession_MustDebugUnableToClearTheGotrueCacheFileIfAnyErrorsOccurred()
		{
			/* --- ARRANGE --- */
			var traceListener = Trace.Listeners[TraceListenerIndex] as MockTraceListener;
			var mockGotrueSessionPersistenceService = new MockGotrueSessionPersistenceService();

			/* --- ACT --- */
			Directory.CreateDirectory(mockGotrueSessionPersistenceService.CacheDirectoryPath);
			File.Create(mockGotrueSessionPersistenceService.CacheFilePath).Close();
			using (var __ = File.Open(mockGotrueSessionPersistenceService.CacheFilePath, FileMode.Open))
			{
				mockGotrueSessionPersistenceService.DestroySession(); /* <-- HERE <-- */
			}

			/* --- ASSERT --- */
			Assert.That(traceListener, Is.Not.Null);
			Assert.That(traceListener?.DebugOutputs.Any(debugOutput => debugOutput.StartsWith($"{Environment.CurrentManagedThreadId}: UNABLE TO CLEAR THE GOTRUE CACHE FILE:")), Is.True);
		}
	}
}
