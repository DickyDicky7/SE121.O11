using Models =
          WorkScheduleReminder.SharedBusinessLogic
     .Models.Implementations;
using Supabase;
using Supabase.Realtime;
using Supabase.Realtime.PostgresChanges;

using System.Diagnostics;

namespace WorkScheduleReminder.SharedBlazorComponents.Services.Implementations
{
	public class SupabaseImplementModelStateProviderService : IDisposable
	{
	public       SupabaseImplementModelStateProviderService
		        (Supabase
		.Client  supabaseClient)
		{
			this.supabaseClient = 
		         supabaseClient ;
		}

		private readonly Supabase.Client supabaseClient;

		public bool OnFetching { get; private set; } = false;
		public List<Models.CustomView> CustomViews { get; private set; } = new();
		public List<Models.Board  > Board__s { get; private set; } = new();
		public List<Models.Member > Member_s { get; private set; } = new();
		public List<Models.Task   > Task___s { get; private set; } = new();
		public List<Models.Comment> Comments { get; private set; } = new();
		public List<Models.TagByBoard      > Tag____ByBoard__s { get; private set; } = new();
		public List<Models.TagByProfile    > Tag____ByProfiles { get; private set; } = new();
		public List<Models.TaggingByBoard  > TaggingByBoard__s { get; private set; } = new();
		public List<Models.TaggingByProfile> TaggingByProfiles { get; private set; } = new();
		public List<Models.SectionByBoard   > Section___ByBoards { get; private set; } = new();
		public List<Models.SectioningByBoard> SectioningByBoards { get; private set; } = new();

		public bool FetchingCustomViews { get; private set; } = true;
		public bool FetchingBoard__s { get; private set; } = true;
		public bool FetchingMember_s { get; private set; } = true;
		public bool FetchingTask___s { get; private set; } = true;
		public bool FetchingComments { get; private set; } = true;
		public bool FetchingTag____ByBoard__s { get; private set; } = true;
		public bool FetchingTag____ByProfiles { get; private set; } = true;
		public bool FetchingTaggingByBoard__s { get; private set; } = true;
		public bool FetchingTaggingByProfiles { get; private set; } = true;
		public bool FetchingSection___ByBoards { get; private set; } = true;
		public bool FetchingSectioningByBoards { get; private set; } = true;

		private RealtimeChannel realtimeChannelAllCustomViews = null!;
		private RealtimeChannel realtimeChannelAllBoard__s = null!;
		private RealtimeChannel realtimeChannelAllMember_s = null!;
		private RealtimeChannel realtimeChannelAllTask___s = null!;
		private RealtimeChannel realtimeChannelAllComments = null!;
		private RealtimeChannel realtimeChannelAllTag____ByBoard__s = null!;
		private RealtimeChannel realtimeChannelAllTag____ByProfiles = null!;
		private RealtimeChannel realtimeChannelAllTaggingByBoard__s = null!;
		private RealtimeChannel realtimeChannelAllTaggingByProfiles = null!;
		private RealtimeChannel realtimeChannelAllSection___ByBoards = null!;
		private RealtimeChannel realtimeChannelAllSectioningByBoards = null!;

		public event Action ChangedCustomViews = null!;
		public event Action ChangedBoard__s = null!;
		public event Action ChangedMember_s = null!;
		public event Action ChangedTask___s = null!;
		public event Action ChangedComments = null!;
		public event Action ChangedTag____ByBoard__s = null!;
		public event Action ChangedTag____ByProfiles = null!;
		public event Action ChangedTaggingByBoard__s = null!;
		public event Action ChangedTaggingByProfiles = null!;
		public event Action ChangedSection___ByBoards = null!;
		public event Action ChangedSectioningByBoards = null!;

		public async Task BeginFetching()
		{
			try
			{
Debug.WriteLine("[Begin 1]");
				await supabaseClient.Realtime.ConnectAsync();
				if (!OnFetching)
				{
Debug.WriteLine("[Begin 2]");

                     OnFetching = true;

					await FetchAndNotifyChangedCustomViews();
					await FetchAndNotifyChangedBoard__s();
					await FetchAndNotifyChangedMember_s();
					await FetchAndNotifyChangedTask___s();
					await FetchAndNotifyChangedComments();
					await FetchAndNotifyChangedTag____ByBoard__s();
					await FetchAndNotifyChangedTag____ByProfiles();
					await FetchAndNotifyChangedTaggingByBoard__s();
					await FetchAndNotifyChangedTaggingByProfiles();
					await FetchAndNotifyChangedSection___ByBoards();
					await FetchAndNotifyChangedSectioningByBoards();

					realtimeChannelAllCustomViews =
					await supabaseClient.From<Models.CustomView>().On(PostgresChangesOptions.ListenType.All,
					async (sender, postgresChangesResponse) =>
					{
						await FetchAndNotifyChangedCustomViews();
					});
					realtimeChannelAllBoard__s =
					await supabaseClient.From<Models.Board  >().On(PostgresChangesOptions.ListenType.All,
					async (sender, postgresChangesResponse) =>
					{
						await FetchAndNotifyChangedBoard__s();
					});
					realtimeChannelAllMember_s =
					await supabaseClient.From<Models.Member >().On(PostgresChangesOptions.ListenType.All,
					async (sender, postgresChangesResponse) =>
					{
						await FetchAndNotifyChangedMember_s();
						await FetchAndNotifyChangedBoard__s();
						await FetchAndNotifyChangedCustomViews();
					});
					realtimeChannelAllTask___s =
					await supabaseClient.From<Models.Task   >().On(PostgresChangesOptions.ListenType.All,
					async (sender, postgresChangesResponse) =>
					{
						await FetchAndNotifyChangedTask___s();
					});
					realtimeChannelAllComments =
					await supabaseClient.From<Models.Comment>().On(PostgresChangesOptions.ListenType.All,
					async (sender, postgresChangesResponse) =>
					{
						await FetchAndNotifyChangedComments();
					});
					realtimeChannelAllTag____ByBoard__s = 
					await supabaseClient.From<Models.TagByBoard      >().On(PostgresChangesOptions.ListenType.All,
					async (sender, postgresChangesResponse) =>
					{
						await FetchAndNotifyChangedTag____ByBoard__s();
						await FetchAndNotifyChangedTaggingByBoard__s();
					});
					realtimeChannelAllTag____ByProfiles =
					await supabaseClient.From<Models.TagByProfile    >().On(PostgresChangesOptions.ListenType.All,
					async (sender, postgresChangesResponse) =>
					{
						await FetchAndNotifyChangedTag____ByProfiles();
						await FetchAndNotifyChangedTaggingByProfiles();
					});
					realtimeChannelAllTaggingByBoard__s =
					await supabaseClient.From<Models.TaggingByBoard  >().On(PostgresChangesOptions.ListenType.All,
					async (sender, postgresChangesResponse) =>
					{
						await FetchAndNotifyChangedTaggingByBoard__s();
					});
					realtimeChannelAllTaggingByProfiles =
					await supabaseClient.From<Models.TaggingByProfile>().On(PostgresChangesOptions.ListenType.All,
					async (sender, postgresChangesResponse) =>
					{
						await FetchAndNotifyChangedTaggingByProfiles();
					});
					realtimeChannelAllSection___ByBoards =
					await supabaseClient.From<Models.SectionByBoard   >().On(PostgresChangesOptions.ListenType.All,
					async (sender, postgresChangesResponse) =>
					{
						await FetchAndNotifyChangedSection___ByBoards();
					});
					realtimeChannelAllSectioningByBoards =
					await supabaseClient.From<Models.SectioningByBoard>().On(PostgresChangesOptions.ListenType.All,
					async (sender, postgresChangesResponse) =>
					{
						await FetchAndNotifyChangedSectioningByBoards();
					});

				}
			}
			catch (Exception exception) 
			{
Debug.WriteLine(exception.Message);
				if (exception is Supabase.Realtime.Exceptions.RealtimeException)
				{
					OnFetching = false;
				}
			}
		}

		public async Task CeaseFetching()
		{
			try
			{
Debug.WriteLine("[Cease 1]");
				if ( OnFetching)
				{
Debug.WriteLine("[Cease 2]");

                     OnFetching = false;

					if (realtimeChannelAllCustomViews != null)
						realtimeChannelAllCustomViews.Unsubscribe();
					if (realtimeChannelAllBoard__s != null)
						realtimeChannelAllBoard__s.Unsubscribe();
					if (realtimeChannelAllMember_s != null)
						realtimeChannelAllMember_s.Unsubscribe();
					if (realtimeChannelAllTask___s != null)
						realtimeChannelAllTask___s.Unsubscribe();
					if (realtimeChannelAllComments != null)
						realtimeChannelAllComments.Unsubscribe();
					if (realtimeChannelAllTag____ByBoard__s != null)
						realtimeChannelAllTag____ByBoard__s.Unsubscribe();
					if (realtimeChannelAllTag____ByProfiles != null)
						realtimeChannelAllTag____ByProfiles.Unsubscribe();
					if (realtimeChannelAllTaggingByBoard__s != null)
						realtimeChannelAllTaggingByBoard__s.Unsubscribe();
					if (realtimeChannelAllTaggingByProfiles != null)
						realtimeChannelAllTaggingByProfiles.Unsubscribe();
					if (realtimeChannelAllSection___ByBoards != null)
						realtimeChannelAllSection___ByBoards.Unsubscribe();
					if (realtimeChannelAllSectioningByBoards != null)
						realtimeChannelAllSectioningByBoards.Unsubscribe();

					realtimeChannelAllCustomViews = null!;
					realtimeChannelAllBoard__s = null!;
					realtimeChannelAllMember_s = null!;
					realtimeChannelAllTask___s = null!;
					realtimeChannelAllComments = null!;
					realtimeChannelAllTag____ByBoard__s = null!;
					realtimeChannelAllTag____ByProfiles = null!;
					realtimeChannelAllTaggingByBoard__s = null!;
					realtimeChannelAllTaggingByProfiles = null!;
					realtimeChannelAllSection___ByBoards = null!;
					realtimeChannelAllSectioningByBoards = null!;

				}
			}
			catch (Exception exception)
			{
Debug.WriteLine(exception.Message);
			}
		}

		private async Task FetchAndNotifyChangedCustomViews()
		{
			await FetchCustomViews();
			if (ChangedCustomViews != null)
				ChangedCustomViews.Invoke();
		}

		private async Task FetchAndNotifyChangedBoard__s()
		{
			await FetchBoard__s();
			if (ChangedBoard__s != null)
				ChangedBoard__s.Invoke();
		}

		private async Task FetchAndNotifyChangedMember_s()
		{
			await FetchMember_s();
			if (ChangedMember_s != null)
				ChangedMember_s.Invoke();
		}

		private async Task FetchAndNotifyChangedTask___s()
		{
			await FetchTask___s();
			if (ChangedTask___s != null)
				ChangedTask___s.Invoke();
		}

		private async Task FetchAndNotifyChangedComments()
		{
			await FetchComments();
			if (ChangedComments != null)
				ChangedComments.Invoke();
		}

		private async Task FetchAndNotifyChangedTag____ByBoard__s()
		{
			await FetchTag____ByBoard__s();
			if (ChangedTag____ByBoard__s  != null)
				ChangedTag____ByBoard__s.Invoke();
		}

		private async Task FetchAndNotifyChangedTag____ByProfiles()
		{
			await FetchTag____ByProfiles();
			if (ChangedTag____ByProfiles  != null)
				ChangedTag____ByProfiles.Invoke();
		}

		private async Task FetchAndNotifyChangedTaggingByBoard__s()
		{
			await FetchTaggingByBoard__s();
			if (ChangedTaggingByBoard__s != null)
				ChangedTaggingByBoard__s.Invoke();
		}

		private async Task FetchAndNotifyChangedTaggingByProfiles()
		{
			await FetchTaggingByProfiles();
			if (ChangedTaggingByProfiles != null)
				ChangedTaggingByProfiles.Invoke();
		}

		private async Task FetchAndNotifyChangedSection___ByBoards()
		{
			await FetchSection___ByBoards();
			if (ChangedSection___ByBoards != null)
				ChangedSection___ByBoards.Invoke();
		}

		private async Task FetchAndNotifyChangedSectioningByBoards()
		{
			await FetchSectioningByBoards();
			if (ChangedSectioningByBoards  != null)
				ChangedSectioningByBoards.Invoke();
		}

		private async Task FetchCustomViews()
		{
			FetchingCustomViews = !false;
			CustomViews = (await supabaseClient.From<Models.CustomView>().Get()).Models;
			FetchingCustomViews =  false;
		}

		private async Task FetchBoard__s()
		{
			FetchingBoard__s = !false;
			Board__s = (await supabaseClient.From<Models.Board  >().Get()).Models;
			FetchingBoard__s =  false;
		}

		private async Task FetchMember_s()
		{
			FetchingMember_s = !false;
			Member_s = (await supabaseClient.From<Models.Member >().Get()).Models;
			FetchingMember_s =  false;
		}

		private async Task FetchTask___s()
		{
			FetchingTask___s = !false;
			Task___s = (await supabaseClient.From<Models.Task   >().Get()).Models;
			FetchingTask___s =  false;
		}

		private async Task FetchComments()
		{
			FetchingComments = !false;
			Comments = (await supabaseClient.From<Models.Comment>().Get()).Models;
			FetchingComments =  false;
		}

		private async Task FetchTag____ByBoard__s()
		{
			FetchingTag____ByBoard__s = !false;
			Tag____ByBoard__s = (await supabaseClient.From<Models.TagByBoard      >().Get()).Models;
			FetchingTag____ByBoard__s =  false;
		}

		private async Task FetchTag____ByProfiles()
		{
			FetchingTag____ByProfiles = !false;
			Tag____ByProfiles = (await supabaseClient.From<Models.TagByProfile    >().Get()).Models;
			FetchingTag____ByProfiles =  false;
		}

		private async Task FetchTaggingByBoard__s()
		{
			FetchingTaggingByBoard__s = !false;
			TaggingByBoard__s = (await supabaseClient.From<Models.TaggingByBoard  >().Get()).Models;
			FetchingTaggingByBoard__s =  false;
		}

		private async Task FetchTaggingByProfiles()
		{
			FetchingTaggingByProfiles = !false;
			TaggingByProfiles = (await supabaseClient.From<Models.TaggingByProfile>().Get()).Models;
			FetchingTaggingByProfiles =  false;
		}

		private async Task FetchSection___ByBoards()
		{
			FetchingSection___ByBoards = !false;
			Section___ByBoards = (await supabaseClient.From<Models.SectionByBoard   >().Get()).Models;
			FetchingSection___ByBoards =  false;
		}

		private async Task FetchSectioningByBoards()
		{
			FetchingSectioningByBoards = !false;
			SectioningByBoards = (await supabaseClient.From<Models.SectioningByBoard>().Get()).Models;
			FetchingSectioningByBoards =  false;
		}

		public void Dispose()
		{
		      CeaseFetching().Wait();
		}
	}
}
