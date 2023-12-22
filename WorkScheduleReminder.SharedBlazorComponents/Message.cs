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
			/// <summary> MSG E COMMON 01 </summary>
			public const string SOMETHING_WENT_WRONG = @"Something went wrong";

			/// <summary> MSG E TAG 01 </summary>
			public const string TAG_ALREADY_EXISTS = @"Tag already exists";

			/// <summary> MSG E AUTH 01 </summary>
			public const string EMPTY_PASSWORD        = @"Empty password";
			/// <summary> MSG E AUTH 02 </summary>
			public const string WRONG_PASSWORD_FORMAT = @"Wrong password format";

			/// <summary> MSG E AUTH 03 </summary>
			public const string EMPTY_EMAIL_ADDRESS        = @"Empty email address";
			/// <summary> MSG E AUTH 04 </summary>
			public const string WRONG_EMAIL_ADDRESS_FORMAT = @"Wrong email address format";

			/// <summary> MSG E AUTH 05 </summary>
			public const string INVALID_PASSWORD_RECOVERY_CODE = @"Invalid password recovery code";

			/// <summary> MSG E AUTH 06 </summary>
			public const string PASSWORD_AND_PASSWORD_CONFIRMED_NOT_MATCH = @"Password and password confirmed don't match each other";

			/// <summary> MSG E AUTH 07 </summary>
			public static string CANNOT_LOG_IN_(string reason)
			=> @$"Cannot log in: {reason}";
			/// <summary> MSG E AUTH 08 </summary>
			public static string CANNOT_LOG_OUT(string reason)
			=> @$"Cannot log out: {reason}";
			/// <summary> MSG E AUTH 09 </summary>
			public static string CANNOT_SIGN_UP(string reason)
			=> @$"Cannot sign up: {reason}";

			public static string CANNOT_DOWNLOAD_FILE(string fileName, string reason)
			=> $@"Cannot download ""{fileName}"": {reason}";

			/// <summary> MSG E MEMBER 01 </summary>
			public static string CANNOT_INVITE_MEMBER(string reason)
			=> @$"Cannot invite member: {reason}";
			/// <summary> MSG E MEMBER 02 </summary>
			public static string CANNOT_UPDATE_MEMBER(string reason)
			=> @$"Cannot update member: {reason}";
			/// <summary> MSG E MEMBER 03 </summary>
			public static string CANNOT_REMOVE_MEMBER(string reason)
			=> @$"Cannot remove member: {reason}";

			/// <summary> MSG E TAG 02 </summary>
			public static string CANNOT_CREATE_TAG(string reason)
			=> $@"Cannot create tag: {reason}";
			/// <summary> MSG E TAG 03 </summary>
			public static string CANNOT_UPDATE_TAG(string reason)
			=> $@"Cannot update tag: {reason}";
			/// <summary> MSG E TAG 04 </summary>
			public static string CANNOT_DELETE_TAG(string reason)
			=> $@"Cannot delete tag: {reason}";
			/// <summary> MSG E TAG 05 </summary>
			public static string CANNOT_UPDATE_TAGGINGS(string reason)
			=> $@"Cannot update taggings: {reason}";

			/// <summary> MSG E TASK 01 </summary>
			public static string CANNOT_CREATE_TASK(string reason)
			=> $@"Cannot create task: {reason}";
			/// <summary> MSG E TASK 02 </summary>
			public static string CANNOT_UPDATE_TASK(string reason)
			=> $@"Cannot update task: {reason}";
			/// <summary> MSG E TASK 03 </summary>
			public static string CANNOT_REMOVE_TASK(string reason)
			=> $@"Cannot remove task: {reason}";

			/// <summary> MSG E BOARD 01 </summary>
			public static string CANNOT_CREATE_BOARD(string boardName, string reason)
			=> $@"Cannot create new board ""{boardName}"": {reason}";
			/// <summary> MSG E BOARD 02 </summary>
			public static string CANNOT_UPDATE_BOARD(string boardName, string reason)
			=> $@"Cannot update the board ""{boardName}"": {reason}";
			/// <summary> MSG E BOARD 03 </summary>
			public static string CANNOT_REMOVE_BOARD(string boardName, string reason)
			=> $@"Cannot remove old board ""{boardName}"": {reason}";
			/// <summary> MSG E BOARD 04 </summary>
			public static string CANNOT_LEAVE_BOARD(string boardName, string reason)
			=> $@"Cannot leave board ""{boardName}"": {reason}";

			/// <summary> MSG E SECTION 01 </summary>
			public static string CANNOT_CREATE_SECTION(string sectionName, string reason)
			=> $@"Cannot create new section ""{sectionName}"": {reason}";
			/// <summary> MSG E SECTION 02 </summary>
			public static string CANNOT_UPDATE_SECTION(string sectionName, string reason)
			=> $@"Cannot update the section ""{sectionName}"": {reason}";
			/// <summary> MSG E SECTION 03 </summary>
			public static string CANNOT_REMOVE_SECTION(string sectionName, string reason)
			=> $@"Cannot remove old section ""{sectionName}"": {reason}";
			/// <summary> MSG E SECTION 04 </summary>
			public static string CANNOT_CREATE_SECTIONS_OF_BOARD(string boardName, string reason)
			=> $@"Cannot create sections of board ""{boardName}"": {reason}";
			/// <summary> MSG E SECTION 08 </summary>
			public static string CANNOT_UPDATE_SECTIONS_OF_BOARD(string boardName, string reason)
			=> $@"Cannot update sections of board ""{boardName}"": {reason}";
			/// <summary> MSG E SECTION 09 </summary>
			public static string CANNOT_REMOVE_SECTIONS_OF_BOARD(string boardName, string reason)
			=> $@"Cannot remove sections of board ""{boardName}"": {reason}";
			/// <summary> MSG E SECTION 07 </summary>
			public static string CANNOT_UPDATE_SECTIONING(
			string fstBoardName,
			string sndBoardName,
			string taskName, string reason)
			=> $@"Cannot move task ""{taskName}"" from board ""{fstBoardName}"" to board ""{sndBoardName}"": {reason}";

			/// <summary> MSG E SECTION 05 </summary>
			public static string SECTION_ALREADY_EXISTS(string sectionName)
			=> $@"Section ""{sectionName}"" already exists";
			/// <summary> MSG E SECTION 06 </summary>
			public static string SECTION_ALREADY_EXISTS(string sectionName, string boardName)
			=> $@"Section ""{sectionName}"" already exists in board ""{boardName}""";

			/// <summary> MSG E COMMON 02 </summary>
			public static string USER_DOESNOT_EXIST_(string email)
			=> @$"User with the email {email} does not exist";
			/// <summary> MSG E COMMON 03 </summary>
			public static string USER_ALREADY_EXISTS(string email)
			=> @$"User with the email {email} already exists";

			/// <summary> MSG E AUTH 10 </summary>
			public static string CANNOT_RESET_PASSWORD(string reason)
			=> @$"Cannot reset password: {reason}";

			/// <summary> MSG E AUTH 11 </summary>
			public static string CANNOT_SEND_PASSWORD_RECOVERY_CODE(string reason)
			=> @$"Cannot send password recovery code: {reason}";
		}

		public static class Normal
		{

		}

		public static class Success
		{
			/// <summary> MSG S AUTH 01 </summary>
			public const string SUCCESSFULLY_LOGGING_IN_ = @"Successfully logging in" ;
			/// <summary> MSG S AUTH 02 </summary>
			public const string SUCCESSFULLY_LOGGING_OUT = @"Successfully logging out";
			/// <summary> MSG S AUTH 03 </summary>
			public const string SUCCESSFULLY_LOGGING_IN_BY_PASSWORD_RECOVERY_CODE = @"Successfully logging in by password recovery code";

			/// <summary> MSG S MEMBER 01 </summary>
			public const string SUCCESSFULLY_INVITE_MEMBER = @"Successfully invite member";
			/// <summary> MSG S MEMBER 02 </summary>
			public const string SUCCESSFULLY_UPDATE_MEMBER = @"Successfully update member";
			/// <summary> MSG S MEMBER 03 </summary>
			public const string SUCCESSFULLY_REMOVE_MEMBER = @"Successfully remove member";

			/// <summary> MSG S TAG 01 </summary>
			public const string SUCCESSFULLY_CREATE_TAG = @"Successfully create tag";
			/// <summary> MSG S TAG 02 </summary>
			public const string SUCCESSFULLY_UPDATE_TAG = @"Successfully update tag";
			/// <summary> MSG S TAG 03 </summary>
			public const string SUCCESSFULLY_DELETE_TAG = @"Successfully delete tag";
			/// <summary> MSG S TAG 04 </summary>
			public const string SUCCESSFULLY_UPDATE_TAGGINGS = @"Successfully update taggings";

			/// <summary> MSG S TASK 01 </summary>
			public const string SUCCESSFULLY_CREATE_TASK = @"Successfully create task";
			/// <summary> MSG S TASK 02 </summary>
			public const string SUCCESSFULLY_UPDATE_TASK = @"Successfully update task";
			/// <summary> MSG S TASK 03 </summary>
			public const string SUCCESSFULLY_REMOVE_TASK = @"Successfully remove task";

			public static string SUCCESSFULLY_DOWNLOAD_FILE(string  fileName, string savePath)
			=> @$"Successfully download ""{fileName}"", save path: {savePath}";

			/// <summary> MSG S BOARD 01 </summary>
			public static string SUCCESSFULLY_CREATE_BOARD(string boardName)
			=> @$"Successfully create new board ""{boardName}""";
			/// <summary> MSG S BOARD 02 </summary>
			public static string SUCCESSFULLY_UPDATE_BOARD(string boardName)
			=> @$"Successfully update the board ""{boardName}""";
			/// <summary> MSG S BOARD 03 </summary>
			public static string SUCCESSFULLY_REMOVE_BOARD(string boardName)
			=> @$"Successfully remove old board ""{boardName}""";
			/// <summary> MSG S BOARD 04 </summary>
			public static string SUCCESSFULLY_LEAVE_BOARD(string boardName)
			=> @$"Successfully leave board ""{boardName}""";

			/// <summary> MSG S SECTION 01 </summary>
			public static string SUCCESSFULLY_CREATE_SECTION(string sectionName)
			=> @$"Successfully create new section ""{sectionName}""";
			/// <summary> MSG S SECTION 02 </summary>
			public static string SUCCESSFULLY_UPDATE_SECTION(string sectionName)
			=> @$"Successfully update the section ""{sectionName}""";
			/// <summary> MSG S SECTION 03 </summary>
			public static string SUCCESSFULLY_REMOVE_SECTION(string sectionName)
			=> @$"Successfully remove old section ""{sectionName}""";
			/// <summary> MSG S SECTION 04 </summary>
			public static string SUCCESSFULLY_CREATE_SECTIONS_OF_BOARD(string boardName)
			=> $@"Successfully create sections of board ""{boardName}""";
			/// <summary> MSG S SECTION 06 </summary>
			public static string SUCCESSFULLY_UPDATE_SECTIONS_OF_BOARD(string boardName)
			=> $@"Successfully update sections of board ""{boardName}""";
			/// <summary> MSG S SECTION 07 </summary>
			public static string SUCCESSFULLY_REMOVE_SECTIONS_OF_BOARD(string boardName)
			=> $@"Successfully remove sections of board ""{boardName}""";
			/// <summary> MSG S SECTION 05 </summary>
			public static string SUCCESSFULLY_UPDATE_SECTIONING(
			string fstBoardName,
			string sndBoardName,
			string taskName)
			=> $@"Successfully move task ""{taskName}"" from board ""{fstBoardName}"" to board ""{sndBoardName}""";

			/// <summary> MSG S AUTH 04 </summary>
			public static string SUCCESSFULLY_SIGNING_UP(string email)
			=> @$"Successfully signing up, a confirmation email has been sent to {email}";

			/// <summary> MSG S AUTH 05 </summary>
			public static string SUCCESSFULLY_RESET_PASSWORD(string email)
			=> @$"Successfully reset password, a new password has been set for {email}";

			/// <summary> MSG S AUTH 06 </summary>
			public static string SUCCESSFULLY_SEND_PASSWORD_RECOVERY_CODE_TO(string  email)
			=> @$"Successfully requiring, a password recovery code has been sent to {email}";
		}

		public static class Warning
		{

		}

	}
}
