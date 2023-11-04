using     WorkScheduleReminder.SharedBusinessLogic.Services.Abstractions___;

namespace WorkScheduleReminder.SharedBusinessLogic.Services.Implementations
{
	public class GotrueSessionPersistenceService : IGotrueSessionPersistenceService
	{
		public void SaveSession(Supabase.Gotrue.Session gotrueSession)
		{
			try
			{
				string cacheFileName = ".gotrue.cache";
				Directory.CreateDirectory       (FileSystem.CacheDirectory               );
				string cacheFilePath = Path.Join(FileSystem.CacheDirectory, cacheFileName);
				     File.WriteAllText(cacheFilePath, Newtonsoft.Json.JsonConvert.SerializeObject(gotrueSession));
			}
			catch (Exception exception)
			{
				System.Diagnostics.Debug.WriteLine($"UNABLE TO WRITE THE GOTRUE CACHE FILE: {exception.Message}");
			}
		}

		public Supabase.Gotrue.Session? LoadSession()
		{
			try
			{
				string cacheFileName = ".gotrue.cache";
				Directory.CreateDirectory       (FileSystem.CacheDirectory               );
				string cacheFilePath = Path.Join(FileSystem.CacheDirectory, cacheFileName);
				return Newtonsoft.Json.JsonConvert.DeserializeObject<Supabase.Gotrue.Session>(File.ReadAllText(cacheFilePath));
			}
			catch (Exception exception)
			{
				System.Diagnostics.Debug.WriteLine($"UNABLE TO @READ THE GOTRUE CACHE FILE: {exception.Message}");
				return null;
			}
		}

		public void DestroySession()
		{
			try
			{
				string cacheFileName = ".gotrue.cache";
				Directory.CreateDirectory       (FileSystem.CacheDirectory               );
				string cacheFilePath = Path.Join(FileSystem.CacheDirectory, cacheFileName);
				     File.WriteAllText(cacheFilePath, string.Empty);
			}
			catch (Exception exception)
			{
				System.Diagnostics.Debug.WriteLine($"UNABLE TO CLEAR THE GOTRUE CACHE FILE: {exception.Message}");
			}
		}
	}
}
