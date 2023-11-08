using System.Diagnostics;
using Supabase.Gotrue;
using Supabase.Gotrue.Interfaces;
using Newtonsoft.Json;

namespace WorkScheduleReminder.SharedBusinessLogic.Services.Abstractions___
{
	public abstract class BaseGotrueSessionPersistenceService   : IGotrueSessionPersistence<Session>
	{
	public                BaseGotrueSessionPersistenceService() : base()
		{
		}

		public abstract string   CacheFileName { get; }
		public virtual  string   CacheFilePath { get => Path.Join(CacheDirectoryPath, CacheFileName); }
		public abstract string   CacheDirectoryPath { get; }
		public abstract string AppDataDirectoryPath { get; }

		public virtual void SaveSession(Session gotrueSession)
		{
			try
			{
				Directory.CreateDirectory(CacheDirectoryPath);
				File.WriteAllText(CacheFilePath, JsonConvert.SerializeObject(gotrueSession));
			}
			catch (Exception exception)
			{
				Debug.WriteLine($"UNABLE TO WRITE THE GOTRUE CACHE FILE: {exception.Message}");
			}
		}

		public virtual Session? LoadSession()
		{
			try
			{
				Directory.CreateDirectory(CacheDirectoryPath);
				return JsonConvert.DeserializeObject<Session>(File.ReadAllText(CacheFilePath));
			}
			catch (Exception exception)
			{
				Debug.WriteLine($"UNABLE TO @READ THE GOTRUE CACHE FILE: {exception.Message}");
				return null;
			}
		}

		public virtual void DestroySession()
		{
			try
			{
				Directory.CreateDirectory( CacheDirectoryPath);
				File.WriteAllText(CacheFilePath, string.Empty);
			}
			catch (Exception exception)
			{
				Debug.WriteLine($"UNABLE TO CLEAR THE GOTRUE CACHE FILE: {exception.Message}");
			}
		}
	}
}
