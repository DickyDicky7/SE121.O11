namespace WorkScheduleReminder.SharedBusinessLogic.Services.Implementations
{
	public class ObservableDictionaryTransferService
	{
	public       ObservableDictionaryTransferService() 
		{
		}

		private readonly Dictionary<object, object?> dataDictionary = new();
		private readonly Dictionary<object, Action<object?>> eventDictionary = new();

		public void InsertOrUpdate(object key, object? data)
		{
			dataDictionary[key] = data;
			if (eventDictionary.ContainsKey(key) 
			&&  eventDictionary[key] != null)
				eventDictionary[key]   (data);
		}

		public void Remove(object key)
		{
			dataDictionary.Remove(key);
		}

		public void Insert(object key, Action<object?> @event)
		{
			if (eventDictionary.ContainsKey(key))
				eventDictionary[key] += @event;
		   else eventDictionary[key]  = @event;
			if ( dataDictionary.ContainsKey(key))      @event
               ( dataDictionary[key]            );
		}

		public void Remove(object key, Action<object?> @event)
		{
			if (eventDictionary.ContainsKey(key) 
			&&  eventDictionary[key] != null)
				eventDictionary[key] -= @event;
		}
	}
}
