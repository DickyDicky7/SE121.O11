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

	[TestFixture]
	[Parallelizable]
	[FixtureLifeCycle(LifeCycle.SingleInstance)]
	public class GotrueSessionPersistenceServiceTests
	{
		protected GotrueSessionPersistenceService gotrueSessionPersistenceService = default!;
		protected string cacheFileName = default!;
		protected string cacheFilePath = default!;

		[OneTimeSetUp]
		public void OnStartJustOnce()
		{
			gotrueSessionPersistenceService = new();
			cacheFileName = ".gotrue.cache";
			cacheFilePath = Path.Join(FileSystem.CacheDirectory, cacheFileName);
		}

		[OneTimeTearDown]
		public void CleanUpJustOnce()
		{
		}

		[SetUp]
		public void OnStartBeforeEveryTestCase()
		{
			Directory.Delete(FileSystem.CacheDirectory, true);
		}

		[TearDown]
		public void CleanUpAfterEveryTestCase()
		{
			Directory.Delete(FileSystem.CacheDirectory, true);
		}

		[Test]
		[NonParallelizable]
		public void SaveSession_Should_Create_Cache_Directory()
		{
			/* --- ARRANGE --- */
			var gotrueSession = new Supabase.Gotrue.Session();

			/* --- ACT --- */
			gotrueSessionPersistenceService.SaveSession(gotrueSession); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.IsTrue(Directory.Exists(FileSystem.CacheDirectory));
		}

		[Test]
		[NonParallelizable]
		public void SaveSession_Should_Create_Cache_File_Path()
		{
			/* --- ARRANGE --- */
			var gotrueSession = new Supabase.Gotrue.Session();

			/* --- ACT --- */
			gotrueSessionPersistenceService.SaveSession(gotrueSession); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.IsTrue(Path.Exists(cacheFilePath));
		}

		[Test]
		[NonParallelizable]
		public async Task SaveSession_Should_Write_Serialized_Gotrue_Session_Into_Cache_File()
		{
			/* --- ARRANGE --- */
			var gotrueSession = new Supabase.Gotrue.Session();
			var gotrueSessionSerialized = Newtonsoft.Json.JsonConvert.SerializeObject(gotrueSession);

			/* --- ACT --- */
			gotrueSessionPersistenceService.SaveSession(gotrueSession); /* <-- HERE <-- */
			var gotrueSessionStoredInCacheFile = await File.ReadAllTextAsync(cacheFilePath);

			/* --- ASSERT --- */
			Assert.AreEqual(gotrueSessionSerialized, gotrueSessionStoredInCacheFile);
		}
	}
}
