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

			public const string INVALID_PASSWORD_RECOVERY_CODE = "Invalid password recovery code";

			public const string PASSWORD_AND_PASSWORD_CONFIRMED_NOT_MATCH = "Password and password confirmed don't match each other";

			public static string CANNOT_LOG_IN_(string reason)
			=> $"Cannot log in: {reason}";
			public static string CANNOT_LOG_OUT(string reason)
			=> $"Cannot log out: {reason}";
			public static string CANNOT_SIGN_UP(string reason)
			=> $"Cannot sign up: {reason}";

			public static string USER_ALREADY_EXISTS(string email)
			=> $"User with the email {email} already exists";

			public static string CANNOT_RESET_PASSWORD(string reason)
			=> $"Cannot reset password: {reason}";

			public static string CANNOT_SEND_PASSWORD_RECOVERY_CODE(string reason)
			=> $"Cannot send password recovery code: {reason}";
		}

		public static class Normal
		{

		}

		public static class Success
		{
			public const string SUCCESSFULLY_LOGGING_IN_ = "Successfully logging in" ;
			public const string SUCCESSFULLY_LOGGING_OUT = "Successfully logging out";
			public const string SUCCESSFULLY_LOGGING_IN_BY_PASSWORD_RECOVERY_CODE = "Successfully logging in by password recovery code";

			public static string SUCCESSFULLY_SIGNING_UP(string email)
			=> $"Successfully signing up, a confirmation email has been sent to {email}";

			public static string SUCCESSFULLY_RESET_PASSWORD(string email)
			=> $"Successfully reset password, a new password has been set for {email}";

			public static string SUCCESSFULLY_SEND_PASSWORD_RECOVERY_CODE_TO(string email)
			=> $"Successfully requiring, a password recovery code has been sent to {email}";
		}

		public static class Warning
		{

		}

	}
}
