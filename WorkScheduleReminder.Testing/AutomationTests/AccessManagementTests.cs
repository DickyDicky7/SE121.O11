using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WorkScheduleReminder.SharedBlazorComponents;

namespace WorkScheduleReminder.Testing.AutomationTests
{
    internal class AccessManagementTests : WorkScheduleReminder.Testing.Core.PlaywrightWebView2Test
    {
        [SetUp]
        public async Task LogIn()
        {
            ILocator temp = Page.GetByRole(AriaRole.Button, new() { Name = "Log in" });
            if (await temp.IsVisibleAsync())
            {
                await Page.GetByPlaceholder("Enter email").FillAsync("thienan27103@gmail.com");
                await Page.GetByPlaceholder("Enter password").FillAsync("123456");
                await temp.ClickAsync();
            }
            await Page.GetByRole(AriaRole.Button, new() { Name = "👨 A"   }).ClickAsync();
            await Page.GetByRole(AriaRole.Button, new() { Name = "Member" }).ClickAsync();
        }
        [TestCase("tuan.pham.21.01.2003")]
        [TestCase("tuan.pham.21.01.2003@gmail")]
        [TestCase("tuan.pham.21.01.2003@gmail.c")]
        [TestCase("tuan.pham.$?@gmail.com")]
        [TestCase("tuan.pham.21.01.2003@%?.com")]
        [TestCase("tuan.pham.21.01.2003@gmail.com#$%7")]
        [TestCase("")]
        public async Task InviteToBoardWrongEmailFormat(string email)
        {
            //arrange
            string checkMessage = (string.IsNullOrWhiteSpace(email)) ?
                Message.Error.CANNOT_INVITE_MEMBER(Message.Error.WRONG_EMAIL_ADDRESS_FORMAT) :
                Message.Error.CANNOT_INVITE_MEMBER(Message.Error.EMPTY_EMAIL_ADDRESS);
            //action
            await Page.WaitForTimeoutAsync(1000);
            await Page.GetByPlaceholder("Enter email").FillAsync(email);
            await Page.GetByRole(AriaRole.Button, new() { Name = "INVITE" }).ClickAsync();
            //assert
            await Expect(Page.GetByText(checkMessage)).ToBeVisibleAsync(
                new LocatorAssertionsToBeVisibleOptions() { Timeout = 10000 });
        }
        [TestCase("1234@gmail.com")]
        public async Task InviteToBoardUserNotExist(string email)
        {
            //arrange
            string checkMessage = Message.Error.CANNOT_INVITE_MEMBER(Message.Error.USER_DOESNOT_EXIST_(email));
            //action
            await Page.WaitForTimeoutAsync(1000);
            await Page.GetByPlaceholder("Enter email").FillAsync(email);
            await Page.GetByRole(AriaRole.Button, new() { Name = "INVITE" }).ClickAsync();
            //assert
            await Expect(Page.GetByText(checkMessage)).ToBeVisibleAsync(
                new LocatorAssertionsToBeVisibleOptions() { Timeout = 10000 });
        }
        [TestCase("tuan.pham.21.01.2003@gmail.com")]
        [Order(1)]
        public async Task InviteToBoardSuccessfully(string email)
        {
            //arrange
            string checkMessage = Message.Success.SUCCESSFULLY_INVITE_MEMBER;
            //action
            await Page.WaitForTimeoutAsync(1000);
            await Page.GetByRole(AriaRole.Textbox, new() { Name = "Enter email" }).FillAsync(email);
            await Page.GetByRole(AriaRole.Button, new() { Name = "INVITE" }).ClickAsync();
            //assert
            await Expect(Page.GetByText(checkMessage)).ToBeVisibleAsync(
                new LocatorAssertionsToBeVisibleOptions() { Timeout = 10000 });
            ILocator temp = Page.Locator("div", new PageLocatorOptions() { Has = Page.GetByText(email) }).Last;
            await Expect(temp.GetByText("Viewer")).ToBeVisibleAsync(
                new LocatorAssertionsToBeVisibleOptions() { Timeout = 10000 });
        }
        [TestCase("tuan.pham.21.01.2003@gmail.com")]
        [Order(2)]
        public async Task InviteToBoardUserAlreadyInvited(string email)
        {
            //arrange
            string checkMessage = Message.Error.CANNOT_INVITE_MEMBER(Message.Error.USER_ALREADY_EXISTS(email));
            //action
            await Page.WaitForTimeoutAsync(1000);
            await Page.GetByPlaceholder("Enter email").FillAsync(email);
            await Page.GetByRole(AriaRole.Button, new() { Name = "INVITE" }).ClickAsync();
            //assert
            await Expect(Page.GetByText(checkMessage)).ToBeVisibleAsync(
                new LocatorAssertionsToBeVisibleOptions() { Timeout = 10000 });
        }
        [TestCase("tuan.pham.21.01.2003@gmail.com")]
        [Order(3)]
        public async Task DeleteMemberFromBoard(string email, string currentRole = "Viewer")
        {
            //arrange
            string checkMessage = Message.Success.SUCCESSFULLY_REMOVE_MEMBER;
            //action
            await Page.WaitForTimeoutAsync(1000);
            ILocator temp = Page.Locator("div", new PageLocatorOptions() { Has = Page.GetByText(email) });
            await temp.GetByText(currentRole).ClickAsync();
            await temp.GetByText("Remove").ClickAsync();
            //assert
            await Expect(Page.GetByText(checkMessage)).ToBeVisibleAsync(
                new LocatorAssertionsToBeVisibleOptions() { Timeout = 10000 });
        }
        
        [Test]
        [Order(4)]
        public async Task LeaveBoard()
        {
            //arrange
            string checkMessage = Message.Success.SUCCESSFULLY_LEAVE_BOARD("👨 A");
            //action
            await Page.WaitForTimeoutAsync(1000);
            await Page.GetByRole(AriaRole.Button, new() { Name = "Leave board" }).ClickAsync();
            //assert
            await Expect(Page.GetByText(checkMessage)).ToBeVisibleAsync(
                new LocatorAssertionsToBeVisibleOptions() { Timeout = 10000 });
        }
    }
}
