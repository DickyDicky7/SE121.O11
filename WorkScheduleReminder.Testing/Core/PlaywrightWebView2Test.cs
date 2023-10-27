using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using System;

namespace WorkScheduleReminder.Testing.Core
{
	public class PlaywrightWebView2Test : PlaywrightTest
	{
		public IPage Page { get; internal set; } = null!;
		public IBrowser Browser { get; internal set; } = null!;
		public IBrowserContext Context { get; internal set; } = null!;

		private Process? _webView2Process = null;
		private string _userDataDirectory = null!;
		private string _executablePath = Path.Join(Directory.GetCurrentDirectory(), @"..\..\..\..\WorkScheduleReminder.MAUIBlazor\bin\Debug\net7.0-windows10.0.19041.0\win10-x64\WorkScheduleReminder.MAUIBlazor.exe");

		[SetUp]
		public async Task BrowserSetUp()
		{
			int cdpPort = 10000 + WorkerIndex;
			Assert.IsTrue(File.Exists(_executablePath), "Make sure that the executable exists, try to build the project which creates the executable again");
			_userDataDirectory = Path.Join(Path.GetTempPath(), $"PlaywrightWebView2Tests/UserDataDirectory-{NUnit.Framework.TestContext.CurrentContext.WorkerId}");
			if (Directory.Exists(_userDataDirectory))
				Directory.Delete(_userDataDirectory, true);

			_webView2Process = Process.Start(new ProcessStartInfo(_executablePath)
			{
				EnvironmentVariables =
				{
					["WEBVIEW2_ADDITIONAL_BROWSER_ARGUMENTS"] = $"--remote-debugging-port={cdpPort}",
					["WEBVIEW2_USER_DATA_FOLDER"] = _userDataDirectory,
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
			Browser = await Playwright.Chromium.ConnectOverCDPAsync(cdpAddress); Context = Browser.Contexts[0]; Page = Context.Pages[0];
		}

		[TearDown]
		public async Task BrowserTearDown()
		{
			_webView2Process!.Kill(true); await Browser.CloseAsync();
		}
	}
}
