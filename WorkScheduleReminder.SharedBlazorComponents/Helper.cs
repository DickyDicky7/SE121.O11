using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Text.RegularExpressions;
using WorkScheduleReminder.SharedBusinessLogic.Models.Abstractions___;
using WorkScheduleReminder.SharedBusinessLogic.Models.Implementations;

namespace WorkScheduleReminder.SharedBlazorComponents
{
	public static class Helper
	{
		public static Assembly[] DependencyAdditionalAssemblies = new[] { Assembly.GetExecutingAssembly() };

		public static string GetResource(this string path)
		{
			StringBuilder stringBuilder = new("_content/WorkScheduleReminder.SharedBlazorComponents");
			return        stringBuilder.Append(path).ToString();
		}

		public enum ViewType
		{
			  MyDayView,
			DefaultView, CustomView, WorkspaceView
		}

		public enum DeviceType
		{
			Desktop, Mobile, Unknown
		}

		public static Dictionary<byte, MudTheme> CustomThemes { get; } = new()
		{
			{
				1
				,
				new()
				{
					Typography = new()
					{
						 Default = new()
						 {
							 FontFamily = new string[1] { "Montserrat-Regular" },
						 },
					},
					ZIndex = new()
					{
					},
					Shadows = new()
					{
					},
					Palette = new()
					{
					},
					PaletteDark = new()
					{

					},
					PseudoCss = new()
					{
					},
					LayoutProperties = new()
					{
					},
				}
			}
			,
			{
				2
				,
				new()
				{

				}
			}
			,
			{
				3,
				new()
				{

				}
			}
			,
		};

		public static (bool ok, string reason) CheckEmailFormat(this string email)
		{
			if (string.IsNullOrWhiteSpace(email))
			{
				return (ok: false, reason: 
				Message.Error.EMPTY_EMAIL_ADDRESS);
			}

			string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
			Regex regex = new(pattern);
			Match match = regex.Match(email);
			return (ok:   match.Success, reason: match.Success ?
			string.       Empty:
				Message.Error.WRONG_EMAIL_ADDRESS_FORMAT);
		}

		public static (bool ok, string reason) CheckPasswordFormat(this string password)
		{
			if (string.IsNullOrWhiteSpace(password))
			{
				return (ok: false, reason: Message.Error.EMPTY_PASSWORD);
			}

			    return (ok: true , reason: string.Empty);
		}

		public static string ExtractSupabaseGotrueException(this JObject message)
		=> message["msg"]              ?.Value<string>()
		?? message["error_description"]?.Value<string>()
		?? string.Empty;

		public static string ExtractMessage
		( this Supabase.Gotrue.Exceptions.     GotrueException    gotrueException)
		{
			JObject message = JObject.Parse(   gotrueException.Message);
			return message["msg"]              ?.Value<string>()
				?? message["error_description"]?.Value<string>()
				?? string.Empty;
		}

		public static string ExtractMessage
		( this Postgrest      .Exceptions.  PostgrestException postgrestException)
		{
			JObject message = JObject.Parse(postgrestException.Message);
			return  message["message"]         ?.Value<string>()
				?? string.Empty;
		}

		public static async Task<string> GetUserFriendlyContentFromRawContentInDatabaseMessages
		(this Supabase.Client supabaseClient, string rawContent)
		{
			string result = (await
			supabaseClient.Rpc("database_messages_get_user_friendly_content_from_raw_content",
			new() { { "_raw_content_", rawContent } }))?.Content ?? string.Empty;
			return JsonConvert.DeserializeObject<string>(result) ?? string.Empty;
		}

		public static bool IsInTheNext7DaysFromToday(this DateOnly dateOnly)
		{
			DateOnly currentDateOnly = DateOnly.FromDateTime(DateTime.Now);
			int    daysDifference    = dateOnly.Day - currentDateOnly.Day ;
			return daysDifference is >= 0 and <= 7;
		}

		public static bool IsToday(this DateOnly dateOnly)
		{
			DateOnly currentDateOnly = DateOnly.FromDateTime(DateTime.Now);
			return  dateOnly == currentDateOnly.AddDays(+0);
		}

		public static bool IsSomeday(this DateOnly dateOnly)
		{
			DateOnly currentDateOnly = DateOnly.FromDateTime(DateTime.Now);
			return  dateOnly >= currentDateOnly.AddDays(+7);
		}

		public static bool IsTomorrow(this DateOnly dateOnly)
		{
			DateOnly currentDateOnly = DateOnly.FromDateTime(DateTime.Now);
			return  dateOnly == currentDateOnly.AddDays(+1);
		}


		public static bool IsUpcoming(this DateOnly dateOnly)
		{
			DateOnly currentDateOnly = DateOnly.FromDateTime(DateTime.Now);
			return  dateOnly >= currentDateOnly.AddDays(+2)
				&&  dateOnly <= currentDateOnly.AddDays(+6);
		}

		public static bool IsOnceUponATime(this DateOnly dateOnly)
		{
			DateOnly currentDateOnly = DateOnly.FromDateTime(DateTime.Now);
			return  dateOnly <= currentDateOnly.AddDays(-1);
		}

		public static bool IsOnceUponATime(this TimeOnly timeOnly)
		{
			TimeOnly currentTimeOnly = TimeOnly.FromDateTime(DateTime.Now);
			return  timeOnly <= currentTimeOnly;
		}

		public static IEnumerable<(DateOnly dateOnly, int daysOffset)> CalculateTheNext7DaysFromToday()
		{
			DateOnly currentDateOnly =   DateOnly.FromDateTime(DateTime.Now);
			foreach (int daysOffset in Enumerable.Range(0, 7))
			{
				yield return (currentDateOnly.AddDays(daysOffset), daysOffset);
			}
		}

		public static bool IsInTheNext7DaysFromToday
		(this DateOnly? dateOnly) => dateOnly != null && dateOnly.Value.IsInTheNext7DaysFromToday();

		public static bool IsToday
		(this DateOnly? dateOnly) => dateOnly != null && dateOnly.Value.IsToday();

		public static bool IsSomeday
		(this DateOnly? dateOnly) => dateOnly != null && dateOnly.Value.IsSomeday();

		public static bool IsTomorrow
		(this DateOnly? dateOnly) => dateOnly != null && dateOnly.Value.IsTomorrow();

		public static bool IsUpcoming
		(this DateOnly? dateOnly) => dateOnly != null && dateOnly.Value.IsUpcoming();

		public static bool IsOnceUponATime
		(this DateOnly? dateOnly) => dateOnly != null && dateOnly.Value.IsOnceUponATime();

		public static bool IsOnceUponATime
		(this TimeOnly? timeOnly) => timeOnly != null && timeOnly.Value.IsOnceUponATime();

		public static Color ParseColor(this ITag tag)
		=> Enum.Parse<Color>(JObject.Parse(tag.Settings)["Color"]?.Value<string>() ?? nameof(Color.Default));

		public static DateOnly DefaultDueDate(int daysOffset) => DateOnly.FromDateTime(DateTime.Now).AddDays(daysOffset);
		public static TimeOnly DefaultDueTime(              ) => TimeOnly.MaxValue.AddHours(+0).AddMinutes(-1);
	}
}
