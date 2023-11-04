using     WorkScheduleReminder.SharedBusinessLogic.Services.Abstractions___;

namespace WorkScheduleReminder.SharedBusinessLogic.Services.Implementations
{
	public class GotrueSessionPersistenceService : IGotrueSessionPersistenceService
	{
		public virtual string   CacheFileName => ".gotrue.cache";
		public virtual string   CacheFilePath => Path.Join(CacheDirectoryPath, CacheFileName);
		public virtual string AppDataDirectoryPath => FileSystem.AppDataDirectory;
		public virtual string   CacheDirectoryPath => FileSystem.  CacheDirectory;

		public void SaveSession(Supabase.Gotrue.Session gotrueSession)
		{
			try
			{
				Directory.CreateDirectory(CacheDirectoryPath);
				File.WriteAllText(CacheFilePath, Newtonsoft.Json.JsonConvert.SerializeObject(gotrueSession));
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
				Directory.CreateDirectory(CacheDirectoryPath);
				return Newtonsoft.Json.JsonConvert.DeserializeObject<Supabase.Gotrue.Session>(File.ReadAllText(CacheFilePath));
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
				Directory.CreateDirectory( CacheDirectoryPath);
				File.WriteAllText(CacheFilePath, string.Empty);
			}
			catch (Exception exception)
			{
				System.Diagnostics.Debug.WriteLine($"UNABLE TO CLEAR THE GOTRUE CACHE FILE: {exception.Message}");
			}
		}
	}
}
