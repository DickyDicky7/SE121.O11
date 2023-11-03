namespace WorkScheduleReminder.MAUIBlazor
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new MainPage();
		}
		protected override Window CreateWindow(IActivationState activationState)
		{
			Window window = base.CreateWindow(activationState);
			window.MinimumHeight = 400;
			window.MinimumWidth = 1000;
			return window;
		}
	}
}