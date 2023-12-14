using Microsoft.UI.Xaml ;
using Microsoft.Windows.AppLifecycle;
using System.Diagnostics;
using CommunityToolkit
      .WinUI.Notifications;
using WorkScheduleReminder.SharedBlazorComponents.Services.Implementations;

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
			ToastNotificationManagerCompat.Uninstall();
		}

		private void OnAppInstanceActivated(object sender, AppActivationArguments appActivationArguments)
		{
		}

		protected override void OnLaunched(LaunchActivatedEventArgs launchActivatedEventArgs)
		{
			base.OnLaunched(launchActivatedEventArgs);
			SupabaseImplementModelStateProviderService supabaseImplementModelStateProviderService
			=  Application.Handler.MauiContext.Services.GetRequiredService<
			SupabaseImplementModelStateProviderService>();
			Task.Run(() =>
			{

			});
		}

		protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
	}
}
