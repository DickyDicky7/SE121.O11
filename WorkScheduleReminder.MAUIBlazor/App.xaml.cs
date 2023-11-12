#if WINDOWS
using Microsoft.Maui.Platform;
#endif

namespace WorkScheduleReminder.MAUIBlazor
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new MainPage();

			Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping(nameof(IWindow), (handler, view) =>
			{
#if WINDOWS
				Microsoft.UI.Xaml.Window nativeWindow = handler.PlatformView;
				Microsoft.UI.Windowing.AppWindow appWindow = nativeWindow.GetAppWindow();
				if (appWindow != null)
				{
					appWindow.Resize(new Windows.Graphics.SizeInt32(windowW, windowH));
					Microsoft.UI.WindowId windowId = appWindow.Id;
					Microsoft.UI.Windowing.DisplayArea displayArea = Microsoft.UI.Windowing.DisplayArea.GetFromWindowId(windowId,
					Microsoft.UI.Windowing.DisplayAreaFallback.Nearest);
					if (displayArea != null)
					{
						Windows.Graphics.PointInt32 centeredPosition = new()
						{
							X = ((displayArea.WorkArea. Width - appWindow.Size. Width) / 2),
							Y = ((displayArea.WorkArea.Height - appWindow.Size.Height) / 2),
						};
						appWindow.Move(centeredPosition);
					}
				}
				nativeWindow.Activate();
#endif
			});
		}

		private const int windowW = 1280;
		private const int windowH =  720;

#if WINDOWS
		protected override Window CreateWindow(IActivationState activationState)
		{
			Window window =  base.CreateWindow( activationState);
			window.MinimumWidth  = windowW;
			window.MinimumHeight = windowH;
/*
			DisplayInfo displayInfo = DeviceDisplay.Current.MainDisplayInfo;
			window.X = (displayInfo. Width / displayInfo.Density - window. Width) / 2;
			window.Y = (displayInfo.Height / displayInfo.Density - window.Height) / 2;
*/
			return window;
		}
#endif
	}
}
