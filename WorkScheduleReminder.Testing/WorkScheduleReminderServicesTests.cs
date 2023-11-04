using Microsoft.Maui;
using Microsoft.Maui.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkScheduleReminder.SharedBusinessLogic.Services.Implementations;

namespace WorkScheduleReminder.Testing.ServicesTests
{
	[TestFixture]
	[Parallelizable]
	[FixtureLifeCycle(LifeCycle.SingleInstance)]
	public class ObservableDictionaryTransferServiceTests
	{
		[Test]
		[Parallelizable]
		public void InsertOrUpdate_Should_Insert_Key_And_Data_Into_DataDictionary()
		{
			/* --- ARRANGE --- */
			var service = new ObservableDictionaryTransferService();
			var key_ = "testKey_";
			var data = "testData";

			/* --- ACT --- */
			service.InsertOrUpdate(key_, data); /* <-- HERE <-- */

			/* --- ASSERT --- */
			service.Insert(key_, getData => Assert.AreEqual(getData, data));
		}

		[Test]
		[Parallelizable]
		public void InsertOrUpdate_Should_Update_Key_And_Data_Into_DataDictionary()
		{
			/* --- ARRANGE --- */
			var service = new ObservableDictionaryTransferService();
			var key_ = "testKey_";
			var data = "testData";
			var updatedData = "updatedData";

			/* --- ACT --- */
			service.InsertOrUpdate(key_, data);
			service.InsertOrUpdate(key_, updatedData); /* <-- HERE <-- */

			/* --- ASSERT --- */
			service.Insert(key_, getData => Assert.AreEqual(getData, updatedData));
		}

		[Test]
		[Parallelizable]
		public void InsertOrUpdate_Should_Raise_Event_By_Key_And_Data_Inserted_Or_Updated_Into_DataDictionary_If_Key_And_Event_Already_Existed_In_EventDictionary()
		{
			/* --- ARRANGE --- */
			var service = new ObservableDictionaryTransferService();
			var key_ = "testKey_";
			var data = "testData";
			var eventRaised = false;

			/* --- ACT --- */
			service.Insert(key_, _ => eventRaised = true);
			service.InsertOrUpdate(key_, data); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.IsTrue(eventRaised);
		}

		[Test]
		[Parallelizable]
		public void InsertOrUpdate_Should_Not_Raise_Event_By_Key_And_Data_Inserted_Or_Updated_Into_DataDictionary_If_Key_And_Event_Already_Existed_In_EventDictionary_But_Event_Be_Null()
		{
			/* --- ARRANGE --- */
			var service = new ObservableDictionaryTransferService();
			var key_ = "testKey_";
			var data = "testData";
			var eventRaised = false;

			/* --- ACT --- */
			service.Insert(key_, null!);
			service.InsertOrUpdate(key_, data); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.IsFalse(eventRaised);
		}

		[Test]
		[Parallelizable]
		public void InsertOrUpdate_Should_Raise_All_Events_Subscribed_To_The_Same_Key_In_EventDictionary()
		{
			/* --- ARRANGE --- */
			var service = new ObservableDictionaryTransferService();
			var key_ = "testKey_";
			var data = "testData";
			var eventRaised1 = false;
			var eventRaised2 = false;
			var eventRaised3 = false;
			Action<object?> eventHandler1 = _ => eventRaised1 = true;
			Action<object?> eventHandler2 = _ => eventRaised2 = true;
			Action<object?> eventHandler3 = _ => eventRaised3 = true;

			/* --- ACT --- */
			service.Insert(key_, eventHandler1);
			service.Insert(key_, eventHandler2);
			service.Insert(key_, eventHandler3);
			service.InsertOrUpdate(key_, data); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.IsTrue(eventRaised1);
			Assert.IsTrue(eventRaised2);
			Assert.IsTrue(eventRaised3);
		}

		[Test]
		[Parallelizable]
		public void InsertOrUpdate_Should_Raise_All_Events_Subscribed_To_The_Same_Key_In_EventDictionary_Except_The_One_Removed()
		{
			/* --- ARRANGE --- */
			var service = new ObservableDictionaryTransferService();
			var key_ = "testKey_";
			var data = "testData";
			var eventRaised1 = false;
			var eventRaised2 = false;
			var eventRaised3 = false;
			Action<object?> eventHandler1 = _ => eventRaised1 = true;
			Action<object?> eventHandler2 = _ => eventRaised2 = true;
			Action<object?> eventHandler3 = _ => eventRaised3 = true;

			/* --- ACT --- */
			service.Insert(key_, eventHandler1);
			service.Insert(key_, eventHandler2);
			service.Insert(key_, eventHandler3);
			service.Remove(key_, eventHandler3);
			service.InsertOrUpdate(key_, data); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.IsTrue(eventRaised1);
			Assert.IsTrue(eventRaised2);
			Assert.IsFalse(eventRaised3);
		}

		[Test]
		[Parallelizable]
		public void Insert_Should_Insert_Key_And_Event_Into_EventDictionary()
		{
			/* --- ARRANGE --- */
			var service = new ObservableDictionaryTransferService();
			var key_ = "testKey_";
			var data = "testData";
			var eventRaised = false;
			Action<object?> eventHandler = _ => eventRaised = true;

			/* --- ACT --- */
			service.Insert(key_, eventHandler); /* <-- HERE <-- */
			service.InsertOrUpdate(key_, data);

			/* --- ASSERT --- */
			Assert.IsTrue(eventRaised);
		}

		[Test]
		[Parallelizable]
		public void Insert_Should_Insert_More_Events_Into_EventDictionary_At_Key_If_Key_And_Maybe_Event_Already_Existed_In_EventDictionary()
		{
			/* --- ARRANGE --- */
			var service = new ObservableDictionaryTransferService();
			var key_ = "testKey_";
			var data = "testData";
			var eventRaised1 = false;
			var eventRaised2 = false;
			Action<object?> eventHandler1 = _ => eventRaised1 = true;
			Action<object?> eventHandler2 = _ => eventRaised2 = true;

			/* --- ACT --- */
			service.Insert(key_, null!); /* <-- HERE <-- */
			service.Insert(key_, eventHandler1); /* <-- HERE <-- */
			service.Insert(key_, eventHandler2); /* <-- HERE <-- */
			service.InsertOrUpdate(key_, data);

			/* --- ASSERT --- */
			Assert.IsTrue(eventRaised1);
			Assert.IsTrue(eventRaised2);
		}

		[Test]
		[Parallelizable]
		public void Insert_Should_Raise_Event_If_Key_And_Data_Already_Existed_In_DataDictionary()
		{
			/* --- ARRANGE --- */
			var service = new ObservableDictionaryTransferService();
			var key_ = "key_";
			var data = "data";
			var alreadyExistedKey_ = "key_";
			var eventRaised = false;
			Action<object?> eventHandler = _ => eventRaised = true;

			/* --- ACT --- */
			service.InsertOrUpdate(key_, data);
			service.Insert(alreadyExistedKey_, eventHandler); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.IsTrue(eventRaised);
		}

		[Test]
		[Parallelizable]
		public void Insert_Should_Not_Raise_Event_If_Key_And_Data_Not_Existed_Yet_In_DataDictionary()
		{
			/* --- ARRANGE --- */
			var service = new ObservableDictionaryTransferService();
			var nonExistentKey_ = "nonExistentKey_";
			var key_ = "key_";
			var data = "data";
			var eventRaised = false;
			Action<object?> eventHandler = _ => eventRaised = true;

			/* --- ACT --- */
			service.InsertOrUpdate(key_, data);
			service.Insert(nonExistentKey_, eventHandler); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.IsFalse(eventRaised);
		}

		[Test]
		[Parallelizable]
		public void Remove_Should_Remove_Key_And_Data_From_DataDictionary()
		{
			/* --- ARRANGE --- */
			var service = new ObservableDictionaryTransferService();
			var key_ = "testKey_";
			var data = "testData";
			var eventRaised = false;

			/* --- ACT --- */
			service.InsertOrUpdate(key_, data);
			service.Remove(key_); /* <-- HERE <-- */
			service.Insert(key_, _ => eventRaised = true);

			/* --- ASSERT --- */
			Assert.IsFalse(eventRaised);
		}

		[Test]
		[Parallelizable]
		public void Remove_Should_Remove_Event_From_EventDictionary()
		{
			/* --- ARRANGE --- */
			var service = new ObservableDictionaryTransferService();
			var key_ = "testKey_";
			var data = "testData";
			var eventRaised = false;
			Action<object?> eventHandler = _ => eventRaised = true;

			/* --- ACT --- */
			service.Insert(key_, eventHandler);
			service.Remove(key_, eventHandler); /* <-- HERE <-- */
			service.InsertOrUpdate(key_, data);

			/* --- ASSERT --- */
			Assert.IsFalse(eventRaised);
		}
	}

	public class MockGotrueSessionPersistenceService : GotrueSessionPersistenceService
	{
		public MockGotrueSessionPersistenceService() : base()
		{
			instanceNumber = count++;
			GotrueSessionPersistenceServiceTests.MockGotrueSessionPersistenceServices.Add(this);
		}

		private static int count = 1;
		private readonly int instanceNumber;

		public override string AppDataDirectoryPath => Path.GetTempPath();
		public override string CacheDirectoryPath => Path.GetTempPath();
		public override string CacheFileName => $".gotrue{instanceNumber}.cache";
	}

	[TestFixture]
	[Parallelizable]
	[FixtureLifeCycle(LifeCycle.SingleInstance)]
	public class GotrueSessionPersistenceServiceTests
	{
		public static List<MockGotrueSessionPersistenceService> MockGotrueSessionPersistenceServices { get; } = new();

		[OneTimeTearDown]
		public void CleanUpJustOnce()
		{
			foreach (var mockGotrueSessionPersistenceService in MockGotrueSessionPersistenceServices)
			{
				File.Delete(mockGotrueSessionPersistenceService.CacheFilePath);
			}
		}

		[Test]
		[Parallelizable]
		public void SaveSession_Should_Create_Cache_Directory()
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
		public void SaveSession_Should_Create_Cache_File()
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
		public async Task SaveSession_Should_Write_Serialized_Gotrue_Session_Into_Cache_File()
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
		public void LoadSession_Should_Create_Cache_Directory()
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
		public void LoadSession_Should_Return_Full_Session_If_Cache_File_Existed_And_Data_In_Cache_File_Has_Valid_Format()
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
		public async Task LoadSession_Should_Return_Null_Session_If_Cache_File_Existed_And_Data_In_Cache_File_Has_Invalid_Format(string content)
		{
			/* --- ARRANGE --- */
			var mockGotrueSessionPersistenceService = new MockGotrueSessionPersistenceService();

			/* --- ACT --- */
			await File.WriteAllTextAsync(mockGotrueSessionPersistenceService.CacheFilePath, content);
			var returnGotrueSession = mockGotrueSessionPersistenceService.LoadSession(); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(returnGotrueSession, Is.Null);
		}

		[Test]
		[Parallelizable]
		public void LoadSession_Should_Return_Null_Session_If_Cache_File_Not_Existed()
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
		public void DestroySession_Should_Create_Cache_Directory()
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
		public void DestroySession_Should_Create_Cache_File()
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
		public async Task DestroySession_Should_Create_Cache_File_Empty()
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
		public async Task DestroySession_Should_Make_Existed_Cache_File_Empty()
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
	}
}
