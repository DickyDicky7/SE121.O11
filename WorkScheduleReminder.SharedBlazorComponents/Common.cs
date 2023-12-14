using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkScheduleReminder.SharedBlazorComponents.Services.Implementations;

namespace WorkScheduleReminder.SharedBlazorComponents
{
	public static class Common
	{
		public record ReminderRecurringSettings
		{
			public List<string> DaysOfWeek { get; set; } = new();
			public int Every { get; set; } = 1;
			public void IncreaseEveryByOne() => ++Every;
			public void DecreaseEveryByOne() => --Every;
			public static string[] GetDaysOfWeek()
			=> new string[7] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };
		}

		//public static async Task<bool> LogIn(
		//	SupabaseAuthenticationStateProviderService
		//	supabaseAuthenticationStateProviderService,
		//	string email   ,
		//	string password, ISnackbar snackbar)
		//{
		//	(bool ok1, string reason1) = Helper.CheckEmailFormat(email);
		//	if  (!ok1)
		//	{
		//		snackbar.Add(Message.Error.CANNOT_LOG_IN_(reason1),
		//		Severity.Error);
		//		return false;
		//	}
		//	(bool ok2, string reason2) = Helper.CheckPasswordFormat(password);
		//	if  (!ok2)
		//	{
		//		snackbar.Add(Message.Error.CANNOT_LOG_IN_(reason2),
		//		Severity.Error);
		//		return false;
		//	}
		//	(bool ok3, string reason3) = await supabaseAuthenticationStateProviderService.SignIn_(email, password);
		//	if  (!ok3)
		//	{
		//		snackbar.Add(Message.Error.CANNOT_LOG_IN_(reason3),
		//		Severity.Error);
		//		return false;
		//	}
		//	else
		//	{
		//		snackbar.Add(reason3,
		//		Severity.Success);
		//		return true;
		//	}
		//}

		//public static async Task<bool> SignUp(
		//	SupabaseAuthenticationStateProviderService
		//	supabaseAuthenticationStateProviderService,
		//	string email            ,
		//	string password         ,
		//	string passwordConfirmed, ISnackbar snackbar)
		//{
		//	(bool ok1, string reason1) = Helper.CheckEmailFormat(email);
		//	if  (!ok1)
		//	{
		//		snackbar.Add(Message.Error.CANNOT_SIGN_UP(reason1),
		//		Severity.Error);
		//		return false;
		//	}
		//	(bool ok2, string reason2) = Helper.CheckPasswordFormat(password);
		//	if  (!ok2)
		//	{
		//		snackbar.Add(Message.Error.CANNOT_SIGN_UP(reason2),
		//		Severity.Error);
		//		return false;
		//	}
		//	if  (password != passwordConfirmed)
		//	{
		//		snackbar.Add(Message.Error.PASSWORD_AND_PASSWORD_CONFIRMED_NOT_MATCH,
		//		Severity.Error);
		//		return false;
		//	}
		//	(bool ok4, string reason4) = await supabaseAuthenticationStateProviderService.SignUp_(email, password);
		//	if  (!ok4)
		//	{
		//		snackbar.Add(Message.Error.CANNOT_SIGN_UP(reason4),
		//		Severity.Error);
		//		return false;
		//	}
		//	else
		//	{
		//		snackbar.Add(reason4,
		//		Severity.Success);
		//		return true;
		//	}
		//}
	}
}
