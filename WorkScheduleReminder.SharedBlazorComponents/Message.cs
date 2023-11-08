using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkScheduleReminder.SharedBlazorComponents
{
	public static class Message
	{

		public static class Info
		{

		}

		public static class Error
		{
			public const string EMPTY_PASSWORD        = "Empty password";
			public const string WRONG_PASSWORD_FORMAT = "Wrong password format";

			public const string EMPTY_EMAIL_ADDRESS        = "Empty email address";
			public const string WRONG_EMAIL_ADDRESS_FORMAT = "Wrong email address format";

			public const string PASSWORD_AND_PASSWORD_CONFIRMED_NOT_MATCH = "Password and password confirmed don't match each other";

			public static string CANNOT_LOG_IN_(string reason)
			=> $"Cannot log in: {reason}";
			public static string CANNOT_LOG_OUT(string reason)
			=> $"Cannot log out: {reason}";
			public static string CANNOT_SIGN_UP(string reason)
			=> $"Cannot sign up: {reason}";
		}

		public static class Normal
		{

		}

		public static class Success
		{
			public const string SUCCESSFULLY_LOGGING_IN_ = "Successfully logging in";
			public const string SUCCESSFULLY_LOGGING_OUT = "Successfully logging out";

			public static string SUCCESSFULLY_SIGNING_UP(string email)
			=> $"Successfully signing up, a confirmation email has been sent to {email}";
		}

		public static class Warning
		{

		}

	}
}
