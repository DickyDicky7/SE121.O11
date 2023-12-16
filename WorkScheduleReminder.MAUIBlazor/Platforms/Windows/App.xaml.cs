using Centvrio.Emoji;
using System.Text;
using H.NotifyIcon;
using Microsoft.UI.Xaml;
using Microsoft.Windows.AppLifecycle;
using System.Diagnostics;
using CommunityToolkit
      .WinUI.Notifications;
using WorkScheduleReminder.SharedBlazorComponents.Services.Implementations;
using MSMauiApplication = Microsoft.Maui.Controls.Application;
using System.Windows.Forms;
using Newtonsoft.Json;
using WorkScheduleReminder.SharedBlazorComponents;
using Models = WorkScheduleReminder.SharedBusinessLogic.Models.Implementations;

// Learn more about WinUI, see: http://aka.ms/winui-project-info.

namespace WorkScheduleReminder.MAUIBlazor.WinUI
{
	/// <summary> Provides application-specific behavior to supplement the default Application class. </summary>
	public partial class App : MauiWinUIApplication
	{
		/// <summary> Initializes the singleton application object. This is the first line of authored code executed, and as such is the logical equivalent of main() or WinMain(). </summary>
		public App()
		{
			AppInstance singleAppInstance =
			AppInstance.FindOrRegisterForKey("WorkScheduleReminderSingleAppInstance");
			if (!singleAppInstance.IsCurrent)
			{
				AppInstance currentAppInstance = AppInstance.GetCurrent();
				AppActivationArguments args = currentAppInstance .GetActivatedEventArgs ();
				singleAppInstance.RedirectActivationToAsync(args).GetAwaiter().GetResult();

				Process.GetCurrentProcess().Kill();
				return;
			}

			singleAppInstance.Activated += OnAppInstanceActivated;
			this.InitializeComponent();
			//ToastNotificationManagerCompat.Uninstall();

			timer = new(TimeSpan.FromHours(3));
			timer.AutoReset = true;
			timer.Elapsed  += Timer_Elapsed;
		}

		private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs elapsedEventArgs)
		{
			Supabase.Client supabaseClient = Application.Handler
					.MauiContext.Services.GetRequiredService<Supabase.Client>();
			Guid currentUserId = Guid.Parse(supabaseClient.Auth.CurrentUser.Id);
			SupabaseImplementModelStateProviderService supabaseImplementModelStateProviderService
			=  Application.Handler.MauiContext.Services.GetRequiredService<
			SupabaseImplementModelStateProviderService>();
			supabaseImplementModelStateProviderService.Task___s.ForEach(task =>
			{
				if (!task.IsBoardTask() || task.ProfileId == currentUserId)
				{
					if (task.ReminderRecurringMode != Models.Task.PossibleReminderRecurringMode.Empty.ToString())
					{
						Common.ReminderRecurringSettings reminderRecurringSettings = JsonConvert
						.DeserializeObject<Common.ReminderRecurringSettings>(task.ReminderRecurringSettings);
						DateOnly currentDateOnly = DateOnly.FromDateTime(DateTime.Now);
						TimeOnly currentTimeOnly = TimeOnly.FromDateTime(DateTime.Now);
						if ((currentDateOnly >  task.ReminderBeginDate
						&&   currentDateOnly <  task.ReminderCeaseDate)
						||  (currentDateOnly == task.ReminderBeginDate
						&&   currentTimeOnly >= task.ReminderBeginTime)
						||  (currentDateOnly == task.ReminderCeaseDate
						&&   currentTimeOnly <= task.ReminderCeaseTime)
						)
						{
							Models.Task.PossibleReminderRecurringMode reminderRecurringMode
							= Enum.Parse<Models.Task.PossibleReminderRecurringMode>(task.ReminderRecurringMode);
							switch (reminderRecurringMode)
							{
								case Models.Task.PossibleReminderRecurringMode.Daily:
									{
										if ((currentDateOnly.Day - task.ReminderBeginDate.Value.Day)
										   % (reminderRecurringSettings.Every * 1) == 0)
										{
											ShowNotification(
												$@"Daily Reminder",
												$@"Daily Reminder",
												DetermineTaskStatus(task,currentDateOnly)
											);
										}
									}
									break;

								case Models.Task.PossibleReminderRecurringMode.Weekly:
									{
										if ((currentDateOnly.Day - task.ReminderBeginDate.Value.Day)
										   % (reminderRecurringSettings.Every * 7) == 0)
										{
											ShowNotification(
												$@"Weekly Reminder",
												$@"Weekly Reminder",
												DetermineTaskStatus(task, currentDateOnly)
											);
										}
									}
									break;

								case Models.Task.PossibleReminderRecurringMode.Monthly:
									{
										if ((currentDateOnly.Month - task.ReminderBeginDate.Value.Month)
										      % reminderRecurringSettings.Every == 0)
										{
											ShowNotification(
												$@"Monthly Reminder",
												$@"Monthly Reminder",
												DetermineTaskStatus(task, currentDateOnly)
											);
										}
									}
									break;

								case Models.Task.PossibleReminderRecurringMode.Yearly:
									{
										if ((currentDateOnly.Year - task.ReminderBeginDate.Value.Year)
										     % reminderRecurringSettings.Every == 0)
										{
											ShowNotification(
												$@"Yearly Reminder",
												$@"Yearly Reminder",
												DetermineTaskStatus(task, currentDateOnly)
											);
										}
									}
									break;
							}
						}
					}
				}
			});
		}

		private readonly Uri appLogoImageUri = new
		(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, $@"my_app.scale-100.png"));

		private readonly System.Timers.Timer timer;

		private static string DetermineTaskStatus(Models.Task task, DateOnly currentDateOnly)
		{

			int daysDifference = Math.Abs
			(task.DueDate.Day - currentDateOnly.Day);
			int  yearsDifference = daysDifference / 360;
			daysDifference %= 360;
			int monthsDifference = daysDifference /  30;
			daysDifference %=  30;
			int  weeksDifference = daysDifference /   7;
			daysDifference %=   7;

			StringBuilder _ = new(string.Empty);
			if ( yearsDifference > 0)
				_.Append($@"{yearsDifference} year(s) ");
			if (monthsDifference > 0)
				_.Append($@"{monthsDifference} month(s) ");
			if ( weeksDifference > 0)
				_.Append($@"{weeksDifference} week(s) ");
			if (  daysDifference > 0)
				_.Append($@"{daysDifference} day(s) ");
			
			if (task.DueDate > currentDateOnly)
			{
				return $@"Task ""{task.Name}"" will be due on {task.DueDate:dd-MM-yyyy}. {_}left before deadline {Time.AlarmClock}.";
			}
			else
			if (task.DueDate < currentDateOnly)
			{
				return $@"Task ""{task.Name}"" was due on {task.DueDate:dd-MM-yyyy}. Overdue {_}ago {Time.AlarmClock}.";
			}
			else
			{
				return $@"Task ""{task.Name}"" is due today {Time.AlarmClock}.";
			}
		}

		private void ShowNotification(string notificationId, string notificationHeader, string notificationContent)
		{
			try
			{
				new ToastContentBuilder()
						.AddAppLogoOverride(appLogoImageUri)
						.AddHeader(notificationId, notificationHeader, string.Empty)
						.AddText(notificationContent)
						.Show();
			}
			catch (   Exception exception)
			{
				Debug.WriteLine(exception.Message);
			}
		}

		private void OnAppInstanceActivated(object sender, AppActivationArguments appActivationArguments)
		{
			ToastNotificationManagerCompat.History.Clear();
			var window = MSMauiApplication.Current.MainPage.Window;
				window.Show();
		}

		protected override void OnLaunched(LaunchActivatedEventArgs launchActivatedEventArgs)
		{
			base.OnLaunched(launchActivatedEventArgs);
			Task.Run(async () =>
			{
				SupabaseImplementModelStateProviderService supabaseImplementModelStateProviderService
				=  Application.Handler.MauiContext.Services.GetRequiredService<
				SupabaseImplementModelStateProviderService>();
				while (!supabaseImplementModelStateProviderService.OnFetching)
				{
					await Task.Delay(TimeSpan.FromSeconds(10));
				}
				Timer_Elapsed(null, null);
				timer.Start();
			});
		}

		protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
	}
}
