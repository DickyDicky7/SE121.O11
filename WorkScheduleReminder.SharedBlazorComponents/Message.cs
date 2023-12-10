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
			public const string SOMETHING_WENT_WRONG = @"Something went wrong";

			/// <summary>
			/// MSG 01
			/// </summary>
			public const string EMPTY_PASSWORD        = @"Empty password";
			public const string WRONG_PASSWORD_FORMAT = @"Wrong password format";

			public const string EMPTY_EMAIL_ADDRESS        = @"Empty email address";
			public const string WRONG_EMAIL_ADDRESS_FORMAT = @"Wrong email address format";

			public const string INVALID_PASSWORD_RECOVERY_CODE = @"Invalid password recovery code";

			public const string PASSWORD_AND_PASSWORD_CONFIRMED_NOT_MATCH = @"Password and password confirmed don't match each other";

			public static string CANNOT_LOG_IN_(string reason)
			=> @$"Cannot log in: {reason}";
			public static string CANNOT_LOG_OUT(string reason)
			=> @$"Cannot log out: {reason}";
			public static string CANNOT_SIGN_UP(string reason)
			=> @$"Cannot sign up: {reason}";

			public static string CANNOT_INVITE_MEMBER(string reason)
			=> @$"Cannot invite member: {reason}";
			public static string CANNOT_UPDATE_MEMBER(string reason)
			=> @$"Cannot update member: {reason}";
			public static string CANNOT_REMOVE_MEMBER(string reason)
			=> @$"Cannot remove member: {reason}";

			public static string CANNOT_CREATE_BOARD(string boardName, string reason)
			=> $@"Cannot create new board ""{boardName}"": {reason}";
			public static string CANNOT_UPDATE_BOARD(string boardName, string reason)
			=> $@"Cannot update the board ""{boardName}"": {reason}";
			public static string CANNOT_REMOVE_BOARD(string boardName, string reason)
			=> $@"Cannot remove old board ""{boardName}"": {reason}";
			public static string CANNOT_LEAVE_BOARD(string boardName, string reason)
			=> $@"Cannot leave board ""{boardName}"": {reason}";

			public static string CANNOT_CREATE_SECTION(string sectionName, string reason)
			=> $@"Cannot create new section ""{sectionName}"": {reason}";
			public static string CANNOT_UPDATE_SECTION(string sectionName, string reason)
			=> $@"Cannot update the section ""{sectionName}"": {reason}";
			public static string CANNOT_REMOVE_SECTION(string sectionName, string reason)
			=> $@"Cannot remove old section ""{sectionName}"": {reason}";
			public static string CANNOT_CREATE_SECTIONS_OF_BOARD(string boardName, string reason)
			=> $@"Cannot create sections of board ""{boardName}"": {reason}";

			public static string SECTION_ALREADY_EXISTS(string sectionName)
			=> $@"Section ""{sectionName}"" already exists";
			public static string SECTION_ALREADY_EXISTS(string sectionName, string boardName)
			=> $@"Section ""{sectionName}"" already exists in board ""{boardName}""";

			public static string USER_DOESNOT_EXIST_(string email)
			=> @$"User with the email {email} does not exist";
			public static string USER_ALREADY_EXISTS(string email)
			=> @$"User with the email {email} already exists";

			public static string CANNOT_RESET_PASSWORD(string reason)
			=> @$"Cannot reset password: {reason}";

			public static string CANNOT_SEND_PASSWORD_RECOVERY_CODE(string reason)
			=> @$"Cannot send password recovery code: {reason}";
		}

		public static class Normal
		{

		}

		public static class Success
		{
			public const string SUCCESSFULLY_LOGGING_IN_ = @"Successfully logging in" ;
			public const string SUCCESSFULLY_LOGGING_OUT = @"Successfully logging out";
			public const string SUCCESSFULLY_LOGGING_IN_BY_PASSWORD_RECOVERY_CODE = @"Successfully logging in by password recovery code";

			public const string SUCCESSFULLY_INVITE_MEMBER = @"Successfully invite member";
			public const string SUCCESSFULLY_UPDATE_MEMBER = @"Successfully update member";
			public const string SUCCESSFULLY_REMOVE_MEMBER = @"Successfully remove member";

			public static string SUCCESSFULLY_CREATE_BOARD(string boardName)
			=> @$"Successfully create new board ""{boardName}""";
			public static string SUCCESSFULLY_UPDATE_BOARD(string boardName)
			=> @$"Successfully update the board ""{boardName}""";
			public static string SUCCESSFULLY_REMOVE_BOARD(string boardName)
			=> @$"Successfully remove old board ""{boardName}""";
			public static string SUCCESSFULLY_LEAVE_BOARD(string boardName)
			=> @$"Successfully leave board ""{boardName}""";

			public static string SUCCESSFULLY_CREATE_SECTION(string sectionName)
			=> @$"Successfully create new section ""{sectionName}""";
			public static string SUCCESSFULLY_UPDATE_SECTION(string sectionName)
			=> @$"Successfully update the section ""{sectionName}""";
			public static string SUCCESSFULLY_REMOVE_SECTION(string sectionName)
			=> @$"Successfully remove old section ""{sectionName}""";
			public static string SUCCESSFULLY_CREATE_SECTIONS_OF_BOARD(string boardName)
			=> $@"Successfully create sections of board ""{boardName}""";

			public static string SUCCESSFULLY_SIGNING_UP(string email)
			=> @$"Successfully signing up, a confirmation email has been sent to {email}";

			public static string SUCCESSFULLY_RESET_PASSWORD(string email)
			=> @$"Successfully reset password, a new password has been set for {email}";

			public static string SUCCESSFULLY_SEND_PASSWORD_RECOVERY_CODE_TO(string  email)
			=> @$"Successfully requiring, a password recovery code has been sent to {email}";
		}

		public static class Warning
		{

		}

	}
}
