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
			Window window =  base.CreateWindow( activationState);
			window.MinimumWidth  = 1280;
			window.MinimumHeight =  720;
			DisplayInfo displayInfo = DeviceDisplay.Current.MainDisplayInfo;
			window.X = (displayInfo. Width / displayInfo.Density - window. Width) / 2;
			window.Y = (displayInfo.Height / displayInfo.Density - window.Height) / 2;
			return window;
		}
	}
}