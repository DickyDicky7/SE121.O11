using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using H.NotifyIcon.Core;
using Microsoft.Playwright;
using WorkScheduleReminder.SharedBlazorComponents;
using WorkScheduleReminder.SharedBlazorComponents.Desktop.MainContent;
using WorkScheduleReminder.SharedBlazorComponents.Desktop.PopupAndSubMenus;

namespace WorkScheduleReminder.Testing.AutomationTests
{
	internal class UserVerificationTests : WorkScheduleReminder.Testing.Core.PlaywrightWebView2Test
	{
		[SetUp]
		public async Task LogOut()
		{
			await Page.Mouse.ClickAsync(20, 20);
			ILocator temp = Page.GetByRole(AriaRole.Button, new() { Name = "My Profile" });
			if (await temp.IsVisibleAsync())
				await temp.ClickAsync();
			temp = Page.GetByRole(AriaRole.Button, new() { Name = "Sign Out" });
			await temp.ClickAsync();
		}
		[Parallelizable]
		[TestCase, Order(1)]
		public async Task CreateAccountSuccessfully(string email = "21521812@gm.uit.edu.vn", string password = "Ta27103$@#!")
		{
			await Page.GetByText("Sign up").ClickAsync();
			await Page.WaitForTimeoutAsync(2000);
			await Page.GetByPlaceholder("Enter password").FillAsync(password);
			await Page.GetByPlaceholder("Confirm password").FillAsync(password);
			await Page.GetByPlaceholder("Enter email").FillAsync(email);
			await Page.GetByRole(AriaRole.Button, new() { Name = "Sign up" }).ClickAsync();
			//assert
			await Expect(Page.GetByText(Message.Success.SUCCESSFULLY_SIGNING_UP(email))).ToBeVisibleAsync(
				new LocatorAssertionsToBeVisibleOptions() { Timeout = 10000 });
		}
		[Parallelizable]
		[TestCase("543dgSH")]
		[TestCase("4534@gJE")]
		[TestCase("435@hke.c")]
		[TestCase("123$?@ge.cold")]
		[TestCase("123@g%?.hot")]
		[TestCase("1233@456.#")]
		[TestCase("")]
		public async Task CreateAccountWrongEmailFormat(string email, string password = "123456")
		{
			//arrange
			string checkMessage = (!string.IsNullOrWhiteSpace(email)) ?
				Message.Error.CANNOT_SIGN_UP(Message.Error.WRONG_EMAIL_ADDRESS_FORMAT) :
				Message.Error.CANNOT_SIGN_UP(Message.Error.EMPTY_EMAIL_ADDRESS);
			//action
			await Page.GetByText("Sign up").ClickAsync();
			await Page.WaitForTimeoutAsync(2000);
			await Page.GetByPlaceholder("Enter email").FillAsync(email);
			await Page.GetByPlaceholder("Enter password").FillAsync(password);
			await Page.GetByPlaceholder("Confirm password").FillAsync(password);
			await Page.GetByRole(AriaRole.Button, new() { Name = "Sign up" }).ClickAsync();
			//assert
			await Expect(Page.GetByText(checkMessage)).ToBeVisibleAsync(
				new LocatorAssertionsToBeVisibleOptions() { Timeout = 10000 });
		}
		[Parallelizable]
		[TestCase("")]
		[TestCase("12345")]
		public async Task CreateAccountWrongPasswordFormat(string password, string email = "123@456.ok")
		{
			//arrange
			string checkMessage = Message.Error.CANNOT_SIGN_UP(Message.Error.EMPTY_PASSWORD);
			//action
			await Page.GetByText("Sign up").ClickAsync();
			await Page.WaitForTimeoutAsync(2000);
			await Page.GetByPlaceholder("Enter email").FillAsync(email);
			await Page.GetByPlaceholder("Enter password").FillAsync(password);
			await Page.GetByPlaceholder("Confirm password").FillAsync(password);
			await Page.GetByRole(AriaRole.Button, new() { Name = "Sign up" }).ClickAsync();
			//assert
			if (string.IsNullOrWhiteSpace(password))
				await Expect(Page.GetByText(checkMessage)).ToBeVisibleAsync(
					new LocatorAssertionsToBeVisibleOptions() { Timeout = 10000 });
			else
				await Expect(Page.GetByText(new Regex("Cannot sign up:.*"))).ToBeVisibleAsync();
		}
		[Parallelizable]
		[TestCase]
		public async Task CreateAccountPasswordNotMatchConfirmPassword(
			string email = "123@456.ok", string password = "123456", string confirm = "654321")
		{
			//arrange
			string checkMessage = Message.Error.CANNOT_SIGN_UP(Message.Error.PASSWORD_AND_PASSWORD_CONFIRMED_NOT_MATCH);
			//action
			await Page.GetByText("Sign up").ClickAsync();
			await Page.WaitForTimeoutAsync(2000);
			await Page.GetByPlaceholder("Enter email").FillAsync(email);
			await Page.GetByPlaceholder("Enter password").FillAsync(password);
			await Page.GetByPlaceholder("Confirm password").FillAsync(confirm);
			await Page.GetByRole(AriaRole.Button, new() { Name = "Sign up" }).ClickAsync();
			//assert
			await Expect(Page.GetByText(checkMessage)).ToBeVisibleAsync(
				new LocatorAssertionsToBeVisibleOptions() { Timeout = 10000 });
		}
		[Parallelizable]
		[TestCase]
		public async Task CreateAccountUserAlreadyExist(
			string email = "thienan27103@gmail.com", string password = "123456")
		{
			//arrange
			string checkMessage = Message.Error.CANNOT_SIGN_UP(Message.Error.USER_ALREADY_EXISTS(email));
			//action
			await Page.GetByText("Sign up").ClickAsync();
			await Page.WaitForTimeoutAsync(2000);
			await Page.GetByPlaceholder("Enter email").FillAsync(email);
			await Page.GetByPlaceholder("Enter password").FillAsync(password);
			await Page.GetByPlaceholder("Confirm password").FillAsync(password);
			await Page.GetByRole(AriaRole.Button, new() { Name = "Sign up" }).ClickAsync();
			//assert
			await Expect(Page.GetByText(checkMessage)).ToBeVisibleAsync(
				new LocatorAssertionsToBeVisibleOptions() { Timeout = 10000 });
		}
		[Parallelizable]
		[TestCase("thienan27103@gmail.com", "123456")]
		public async Task LogInWithCreatedAccountSuccessfully(string email, string password)
		{
			//arrange
			string checkMessage = Message.Success.SUCCESSFULLY_LOGGING_IN_;
			//action
			await Page.WaitForTimeoutAsync(1000);
			await Page.GetByPlaceholder("Enter email").FillAsync(email);
			await Page.GetByPlaceholder("Enter password").FillAsync(password);
			await Page.GetByRole(AriaRole.Button, new() { Name = "Log in" }).ClickAsync();
			//assert
			await Expect(Page.GetByText(checkMessage)).ToBeVisibleAsync(
				new LocatorAssertionsToBeVisibleOptions() { Timeout = 10000 });
			await Expect(Page.GetByText("My day")).ToBeVisibleAsync(
				new LocatorAssertionsToBeVisibleOptions() { Timeout = 10000 });
		}
		[Parallelizable]
		[TestCase("thienan")]
		[TestCase("thienan27103@gmail")]
		[TestCase("thienan27103@gmail.c")]
		[TestCase("thienan$?@gmail.com")]
		[TestCase("thienan27103@gmail%+.com")]
		[TestCase("thienan27103@gmail.com0930")]
		[TestCase("")]
		public async Task LogInWithCreatedAccountWrongEmailFormat(
			string email, string password = "Ta27103$@#!")
		{
			//arrange
			string checkMessage = string.IsNullOrWhiteSpace(email) ?
			Message.Error.CANNOT_LOG_IN_(Message.Error.EMPTY_EMAIL_ADDRESS) :
			Message.Error.CANNOT_LOG_IN_(Message.Error.WRONG_EMAIL_ADDRESS_FORMAT);
			//action
			await Page.WaitForTimeoutAsync(1000);
			await Page.GetByPlaceholder("Enter email").FillAsync(email);
			await Page.GetByPlaceholder("Enter password").FillAsync(password);
			await Page.GetByRole(AriaRole.Button, new() { Name = "Log in" }).ClickAsync();
			//assert
			await Expect(Page.GetByText(checkMessage)).ToBeVisibleAsync(
				new LocatorAssertionsToBeVisibleOptions() { Timeout = 10000 });
		}
		[Parallelizable]
		[TestCase("")]
		public async Task LogInWithCreateAccountWrongPasswordFormat(
			string password, string email = "thienan27103@gmail.com")
		{
			//arrange
			string checkMessage = Message.Error.CANNOT_LOG_IN_(Message.Error.EMPTY_PASSWORD);
			//action
			await Page.WaitForTimeoutAsync(1000);
			await Page.GetByPlaceholder("Enter email").FillAsync(email);
			await Page.GetByPlaceholder("Enter password").FillAsync(password);
			await Page.GetByRole(AriaRole.Button, new() { Name = "Log in" }).ClickAsync();
			//assert
			await Expect(Page.GetByText(checkMessage)).ToBeVisibleAsync(
				new LocatorAssertionsToBeVisibleOptions() { Timeout = 10000 });
		}
		[Parallelizable]
		[TestCase("thienan27103@gmail.com", "1234567")]
		public async Task LogInWithCreatedAccountEmailAndPasswordNotMatch(
			string email, string password)
		{
			//arrange

			//action
			await Page.WaitForTimeoutAsync(1000);
			await Page.GetByPlaceholder("Enter email").FillAsync(email);
			await Page.GetByPlaceholder("Enter password").FillAsync(password);
			await Page.GetByRole(AriaRole.Button, new() { Name = "Log in" }).ClickAsync();
			//assert
			await Expect(Page.GetByText(new Regex("Cannot log in:.*"))).ToBeVisibleAsync(
				new LocatorAssertionsToBeVisibleOptions() { Timeout = 10000 });
		}
		[Parallelizable]
		[TestCase]
		public async Task LogInWithCreatedAccountAccountNotExist(
			string email = "1fwsd%3@gm.com", string password = "123456")
		{
			//arrange

			//action
			await Page.WaitForTimeoutAsync(1000);
			await Page.GetByPlaceholder("Enter email").FillAsync(email);
			await Page.GetByPlaceholder("Enter password").FillAsync(password);
			await Page.GetByRole(AriaRole.Button, new() { Name = "Log in" }).ClickAsync();
			//assert
			await Expect(Page.GetByText(new Regex("Cannot log in:.*"))).ToBeVisibleAsync(
				new LocatorAssertionsToBeVisibleOptions() { Timeout = 10000 });
		}
		[Parallelizable]
		[TestCase, Order(2)]
		public async Task LogInWithCreatedAccountUnverifiedAccount(
			string email = "21521812@gm.uit.edu.vn", string password = "Ta27103$@#!")
		{
			//arrange

			//action
			await Page.WaitForTimeoutAsync(1000);
			await Page.GetByPlaceholder("Enter email").FillAsync(email);
			await Page.GetByPlaceholder("Enter password").FillAsync(password);
			await Page.GetByRole(AriaRole.Button, new() { Name = "Log in" }).ClickAsync();
			//assert
			await Expect(Page.GetByText(new Regex("Cannot log in:.*"))).ToBeVisibleAsync(
				new LocatorAssertionsToBeVisibleOptions() { Timeout = 10000 });
		}
		[Parallelizable]
		[TestCase]
		public async Task ResetPasswordSuccessfully(
			string email = "thienan27103@gmail.com", string newPassword = "123456")
		{
			//arrange
			string checkMessage = Message.Success.SUCCESSFULLY_RESET_PASSWORD(email);
			//action
			await Context.NewPageAsync();
			await Page.GetByText("Forgot password").ClickAsync();
			await Page.WaitForTimeoutAsync(1000);
			await Page.GetByPlaceholder("Enter email").FillAsync(email);
			await Page.GetByRole(AriaRole.Button, new() { Name = "Send password recovery code" }).ClickAsync();
			await Expect(Page.GetByText(Message.Success.SUCCESSFULLY_SEND_PASSWORD_RECOVERY_CODE_TO(email))).ToBeVisibleAsync();
			await Expect(Page.GetByPlaceholder("Enter password recovery code")).ToHaveValueAsync(
				new Regex("^.+$"), new LocatorAssertionsToHaveValueOptions() { Timeout = 30000 });
			await Page.GetByRole(AriaRole.Button, new() { Name = "Confirm" }).ClickAsync();
			await Expect(Page.GetByText(Message.Success.SUCCESSFULLY_LOGGING_IN_BY_PASSWORD_RECOVERY_CODE)).ToBeVisibleAsync(
				new LocatorAssertionsToBeVisibleOptions() { Timeout = 10000 });
			await Page.WaitForTimeoutAsync(1000);
			await Page.GetByPlaceholder("Enter new password").FillAsync(newPassword);
			await Page.GetByPlaceholder("Confirm new password").FillAsync(newPassword);
			await Page.GetByRole(AriaRole.Button, new() { Name = "Confirm reset password" }).ClickAsync();
			//assert
			await Expect(Page.GetByText(checkMessage)).ToBeVisibleAsync(
				new LocatorAssertionsToBeVisibleOptions() { Timeout = 10000 });
		}
		[Parallelizable]
		[TestCase]
		public async Task ResetPasswordWrongRecoveryCode(
			string email = "thienan27103@gmail.com")
		{
			//arrange
			string checkMessage = Message.Error.CANNOT_LOG_IN_(Message.Error.INVALID_PASSWORD_RECOVERY_CODE);
			//action
			await Context.NewPageAsync();
			await Page.GetByText("Forgot password").ClickAsync();
			await Page.WaitForTimeoutAsync(1000);
			await Page.GetByPlaceholder("Enter email").FillAsync(email);
			await Page.GetByRole(AriaRole.Button, new() { Name = "Send password recovery code" }).ClickAsync();
			await Expect(Page.GetByText(Message.Success.SUCCESSFULLY_SEND_PASSWORD_RECOVERY_CODE_TO(email))).ToBeVisibleAsync();
			await Page.GetByPlaceholder("Enter password recovery code").FillAsync("1234567890");
			await Page.GetByRole(AriaRole.Button, new() { Name = "Confirm" }).ClickAsync();
			//assert
			await Expect(Page.GetByText(checkMessage)).ToBeVisibleAsync(
				new LocatorAssertionsToBeVisibleOptions() { Timeout = 10000 });
		}
		[Parallelizable]
		[TestCase]
		public async Task ResetPasswordWrongPasswordFormat(
			string email = "thienan27103@gmail.com", string newPassword = "")
		{
			//arrange
			string checkMessage = Message.Error.CANNOT_RESET_PASSWORD(Message.Error.EMPTY_PASSWORD);
			//action
			await Context.NewPageAsync();
			await Page.GetByText("Forgot password").ClickAsync();
			await Page.WaitForTimeoutAsync(1000);
			await Page.GetByPlaceholder("Enter email").FillAsync(email);
			await Page.GetByRole(AriaRole.Button, new() { Name = "Send password recovery code" }).ClickAsync();
			await Expect(Page.GetByText(Message.Success.SUCCESSFULLY_SEND_PASSWORD_RECOVERY_CODE_TO(email))).ToBeVisibleAsync();
			await Expect(Page.GetByPlaceholder("Enter password recovery code")).ToHaveValueAsync(
				new Regex("^.+$"), new LocatorAssertionsToHaveValueOptions() { Timeout = 30000 });
			await Page.GetByRole(AriaRole.Button, new() { Name = "Confirm" }).ClickAsync();
			await Expect(Page.GetByText(Message.Success.SUCCESSFULLY_LOGGING_IN_BY_PASSWORD_RECOVERY_CODE)).ToBeVisibleAsync(
				new LocatorAssertionsToBeVisibleOptions() { Timeout = 10000 });
			await Page.WaitForTimeoutAsync(1000);
			await Page.GetByPlaceholder("Enter new password").FillAsync(newPassword);
			await Page.GetByPlaceholder("Confirm new password").FillAsync(newPassword);
			await Page.GetByRole(AriaRole.Button, new() { Name = "Confirm reset password" }).ClickAsync();
			//assert
			await Expect(Page.GetByText(checkMessage)).ToBeVisibleAsync(
				new LocatorAssertionsToBeVisibleOptions() { Timeout = 10000 });
		}
		[Parallelizable]
		[TestCase]
		public async Task ResetPasswordPasswordNotMatchConfirmPassword(
			string email = "thienan27103@gmail.com", string newPassword = "123456")
		{
			//arrange
			string checkMessage = Message.Error.CANNOT_RESET_PASSWORD(Message.Error.PASSWORD_AND_PASSWORD_CONFIRMED_NOT_MATCH);
			//action
			await Context.NewPageAsync();
			await Page.GetByText("Forgot password").ClickAsync();
			await Page.WaitForTimeoutAsync(1000);
			await Page.GetByPlaceholder("Enter email").FillAsync(email);
			await Page.GetByRole(AriaRole.Button, new() { Name = "Send password recovery code" }).ClickAsync();
			await Expect(Page.GetByText(Message.Success.SUCCESSFULLY_SEND_PASSWORD_RECOVERY_CODE_TO(email))).ToBeVisibleAsync();
			await Expect(Page.GetByPlaceholder("Enter password recovery code")).ToHaveValueAsync(
				new Regex("^.+$"), new LocatorAssertionsToHaveValueOptions() { Timeout = 30000 });
			await Page.GetByRole(AriaRole.Button, new() { Name = "Confirm" }).ClickAsync();
			await Expect(Page.GetByText(Message.Success.SUCCESSFULLY_LOGGING_IN_BY_PASSWORD_RECOVERY_CODE)).ToBeVisibleAsync(
				new LocatorAssertionsToBeVisibleOptions() { Timeout = 10000 });
			await Page.WaitForTimeoutAsync(1000);
			await Page.GetByPlaceholder("Enter new password").FillAsync(newPassword);
			await Page.GetByPlaceholder("Confirm new password").FillAsync(newPassword + newPassword);
			await Page.GetByRole(AriaRole.Button, new() { Name = "Confirm reset password" }).ClickAsync();
			//assert
			await Expect(Page.GetByText(checkMessage)).ToBeVisibleAsync(
				new LocatorAssertionsToBeVisibleOptions() { Timeout = 10000 });
		}
	}

}
