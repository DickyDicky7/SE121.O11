using System;
using WorkScheduleReminder.SharedBusinessLogic.Services.Implementations;

namespace WorkScheduleReminder.Testing.BEUnitTests.SharedBusinessLogicUnitTests.ServicesUnitTests
{
	[TestFixture]
	[Parallelizable]
	[FixtureLifeCycle(LifeCycle.SingleInstance)]
	public class ObservableDictionaryTransferServiceUnitTests
	{
		[Test]
		[Parallelizable]
		public void InsertOrUpdate_MustInsertKeyAndDataIntoDataDictionary()
		{
			/* --- ARRANGE --- */
			var service = new ObservableDictionaryTransferService();
			var key_ = "testKey_";
			var data = "testData";

			/* --- ACT --- */
			service.InsertOrUpdate(key_, data); /* <-- HERE <-- */

			/* --- ASSERT --- */
			service.Insert(key_, getData => Assert.That(getData, Is.EqualTo(data)));
		}

		[Test]
		[Parallelizable]
		public void InsertOrUpdate_MustUpdateKeyAndDataIntoDataDictionary()
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
			service.Insert(key_, getData => Assert.That(getData, Is.EqualTo(updatedData)));
		}

		[Test]
		[Parallelizable]
		public void InsertOrUpdate_MustRaiseEventByKeyAndDataInsertedOrUpdatedIntoDataDictionaryIfKeyAndEventAlreadyExistedInEventDictionary()
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
			Assert.That(eventRaised, Is.True);
		}

		[Test]
		[Parallelizable]
		public void InsertOrUpdate_MustNotRaiseEventByKeyAndDataInsertedOrUpdatedIntoDataDictionaryIfKeyAndEventAlreadyExistedInEventDictionaryButEventBeNull()
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
			Assert.That(eventRaised, Is.False);
		}

		[Test]
		[Parallelizable]
		public void InsertOrUpdate_MustRaiseAllEventsSubscribedToTheSameKeyInEventDictionary()
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
			Assert.That(eventRaised1, Is.True);
			Assert.That(eventRaised2, Is.True);
			Assert.That(eventRaised3, Is.True);
		}

		[Test]
		[Parallelizable]
		public void InsertOrUpdate_MustRaiseAllEventsSubscribedToTheSameKeyInEventDictionaryExceptTheOneRemoved()
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
			Assert.That(eventRaised1, Is.True);
			Assert.That(eventRaised2, Is.True);
			Assert.That(eventRaised3, Is.False);
		}

		[Test]
		[Parallelizable]
		public void Insert_MustInsertKeyAndEventIntoEventDictionary()
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
			Assert.That(eventRaised, Is.True);
		}

		[Test]
		[Parallelizable]
		public void Insert_MustInsertMoreEventsIntoEventDictionaryAtKeyIfKeyAndMaybeEventAlreadyExistedInEventDictionary()
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
			Assert.That(eventRaised1, Is.True);
			Assert.That(eventRaised2, Is.True);
		}

		[Test]
		[Parallelizable]
		public void Insert_MustRaiseEventIfKeyAndDataAlreadyExistedInDataDictionary()
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
			Assert.That(eventRaised, Is.True);
		}

		[Test]
		[Parallelizable]
		public void Insert_MustNotRaiseEventIfKeyAndDataNotExistedYetInDataDictionary()
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
			Assert.That(eventRaised, Is.False);
		}

		[Test]
		[Parallelizable]
		public void Remove_MustRemoveKeyAndDataFromDataDictionary()
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
			Assert.That(eventRaised, Is.False);
		}

		[Test]
		[Parallelizable]
		public void Remove_MustRemoveEventFromEventDictionary()
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
			Assert.That(eventRaised, Is.False);
		}
	}
}
