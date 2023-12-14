using System.Threading.Tasks; using Microsoft.Playwright.NUnit;

namespace WorkScheduleReminder.Testing
{
	[Parallelizable(ParallelScope.Self)]
	public class PlaywrightAutomatedFunctionalTestSample : WorkScheduleReminder.Testing.Core.PlaywrightWebView2Test
	{
		[Test]
		public async Task TheContentOfTheAppShouldNotBeEmpty()
		{
			string content = await Page.ContentAsync();
			Assert.That(!string.IsNullOrWhiteSpace(content), Is.True);
		}
	}
}
