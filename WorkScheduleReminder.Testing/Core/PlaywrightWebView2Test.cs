using System;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace WorkScheduleReminder.Testing.Core
{
	public class PlaywrightWebView2Test : PlaywrightTest
	{
		public IPage           Page    { get; internal set; } = default!;
		public IBrowser        Browser { get; internal set; } = default!;
		public IBrowserContext Context { get; internal set; } = default!;

		private Process? webView2Process;
		private          string userDataDirectory = default!;
		private readonly string executablePath    = Path.Join(Directory.GetCurrentDirectory
		(), @"..\..\..\..\WorkScheduleReminder.MAUIBlazor\bin\Debug\net7.0-windows10.0.19041.0\win10-x64\WorkScheduleReminder.MAUIBlazor.exe");

		[SetUp]
		public async Task BrowserSetUp()
		{
			int cdpPort = 10000 + WorkerIndex;
			Assert.IsTrue(File.Exists(executablePath
			), "Make sure that the executable exists, try to build the project which creates the executable again");
			userDataDirectory =  Path.Join(Path.GetTempPath
			(), $"PlaywrightWebView2Tests/UserDataDirectory-{NUnit.Framework.TestContext.CurrentContext.WorkerId}");
			if (Directory.Exists(userDataDirectory))
				Directory.Delete(userDataDirectory, true);

			webView2Process = Process.Start(new ProcessStartInfo(executablePath)
			{
				EnvironmentVariables =
				{
					["WEBVIEW2_ADDITIONAL_BROWSER_ARGUMENTS"] = $"--remote-debugging-port={cdpPort}", ["WEBVIEW2_USER_DATA_FOLDER"]
					= userDataDirectory,
				},
				RedirectStandardOutput = true,
			});

			//while (!_webView2Process!.HasExited)
			//{
			//	string? output = await _webView2Process!.StandardOutput.ReadLineAsync();
			//	if (_webView2Process!.HasExited)
			//	{
			//		throw new Exception("WebView2 process exited unexpectedly, make sure the executable is openable");
			//	}
			//	if (output != null
			//	&&  output.Contains("WebView2 initialized"))
			//	{
			//		break;
			//	}
			//}

			await Task.Delay(TimeSpan.FromSeconds(10));

			string cdpAddress = $"http://127.0.0.1:{cdpPort}";
			Browser = await Playwright.Chromium.ConnectOverCDPAsync(cdpAddress);
			Context = Browser.Contexts[0]; 
			   Page = Context.Pages   [0];
		}

		[TearDown]
		public async Task BrowserTearDown()
		{
			webView2Process!.Kill(true); 
			await   Browser .CloseAsync();
		}
	}
}
