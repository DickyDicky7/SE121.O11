using Supabase.Gotrue;
using Supabase.Gotrue.Interfaces;

namespace WorkScheduleReminder.SharedBusinessLogic
{
	public class CustomGotrueSessionPersistence : IGotrueSessionPersistence<Session>
	{
	public       CustomGotrueSessionPersistence
		(Func<Session?, Task> onGotrueSessionSave,
		 Func<Task<Session?>> onGotrueSessionLoad,
		 Func<Task> onGotrueSessionDestroy)
		{
			this.onGotrueSessionSave = onGotrueSessionSave;
			this.onGotrueSessionLoad = onGotrueSessionLoad;
			this.onGotrueSessionDestroy = onGotrueSessionDestroy;
		}

		private readonly Func<Session?, Task> onGotrueSessionSave;
		private readonly Func<Task<Session?>> onGotrueSessionLoad;
		private readonly Func<Task> onGotrueSessionDestroy;

		public async void SaveSession(Session gotrueSession)
		{      await  onGotrueSessionSave    (gotrueSession);
		}

		public Session?   LoadSession    ()
		{      return onGotrueSessionLoad().Result;
		}

		public async void DestroySession       ()
		{      await     onGotrueSessionDestroy();
		}

		~        CustomGotrueSessionPersistence()
		{

		}
	}
}
