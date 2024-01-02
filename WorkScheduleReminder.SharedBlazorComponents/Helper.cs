using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

		public enum ViewTypeBoard
		{
			Kanban,
			 Table,
			Calendar,
		}

		public enum DeviceType
		{
			Desktop, Mobile, Unknown
		}

		public class CustomMudTheme_1
		                 : MudTheme
		{
		public       CustomMudTheme_1() : base()
			{
				this.Typography.Default.FontFamily = new string[1] { "Montserrat-Regular" };
				this.Palette    .Info = Colors.Blue.Darken4;
				this.PaletteDark.Info = Colors.Blue.Darken4;
			}
		}

		public class CustomMudTheme_2
		                 : MudTheme
		{
		public       CustomMudTheme_2() : base()
			{
				this.Typography.Default.FontFamily = new string[1] { "Montserrat-Regular" };
				this.Palette    .Info = Colors.Indigo.Darken4;
				this.PaletteDark.Info = Colors.Indigo.Darken4;
			}
		}

		public class CustomMudTheme_3
		                 : MudTheme
		{
		public       CustomMudTheme_3() : base()
			{
				this.Typography.Default.FontFamily = new string[1] { "Montserrat-Regular" };
				this.Palette    .Info = Colors.DeepPurple.Darken4;
				this.PaletteDark.Info = Colors.DeepPurple.Darken4;
			}
		}

		public class CustomMudTheme_4
		                 : MudTheme
		{
		public       CustomMudTheme_4() : base()
			{
				this.Typography.Default.FontFamily = new string[1] { "Montserrat-Regular" };
				this.Palette    .Info = Colors.Red.Darken4;
				this.PaletteDark.Info = Colors.Red.Darken4;
			}
		}

		public class CustomMudTheme_5
		                 : MudTheme
		{
		public       CustomMudTheme_5() : base()
			{
				this.Typography.Default.FontFamily = new string[1] { "Montserrat-Regular" };
				this.Palette    .Info = Colors.Pink.Darken4;
				this.PaletteDark.Info = Colors.Pink.Darken4;
			}
		}

		public class CustomMudTheme_6
		                 : MudTheme
		{
		public       CustomMudTheme_6() : base()
			{
				this.Typography.Default.FontFamily = new string[1] { "Montserrat-Regular" };
				this.Palette    .Info = Colors.Purple.Darken4;
				this.PaletteDark.Info = Colors.Purple.Darken4;
			}
		}

		public class CustomMudTheme_7
		                 : MudTheme
		{
		public       CustomMudTheme_7() : base()
			{
				this.Typography.Default.FontFamily = new string[1] { "Montserrat-Regular" };
				this.Palette    .Info = Colors.LightBlue.Darken4;
				this.PaletteDark.Info = Colors.LightBlue.Darken4;
			}
		}

		public class CustomMudTheme_8
		                 : MudTheme
		{
		public       CustomMudTheme_8() : base()
			{
				this.Typography.Default.FontFamily = new string[1] { "Montserrat-Regular" };
				this.Palette    .Info = Colors.Cyan.Darken4;
				this.PaletteDark.Info = Colors.Cyan.Darken4;
			}
		}

		public class CustomMudTheme_9
		                 : MudTheme
		{
		public       CustomMudTheme_9() : base()
			{
				this.Typography.Default.FontFamily = new string[1] { "Montserrat-Regular" };
				this.Palette    .Info = Colors.Teal.Darken4;
				this.PaletteDark.Info = Colors.Teal.Darken4;
			}
		}

		public class CustomMudTheme_10
		                 : MudTheme
		{
		public       CustomMudTheme_10() : base()
			{
				this.Typography.Default.FontFamily = new string[1] { "Montserrat-Regular" };
				this.Palette    .Info = Colors.Green.Darken4;
				this.PaletteDark.Info = Colors.Green.Darken4;
			}
		}

		public class CustomMudTheme_11
		                 : MudTheme
		{
		public       CustomMudTheme_11() : base()
			{
				this.Typography.Default.FontFamily = new string[1] { "Montserrat-Regular" };
				this.Palette    .Info = Colors.LightGreen.Darken4;
				this.PaletteDark.Info = Colors.LightGreen.Darken4;
			}
		}

		public class CustomMudTheme_12
		                 : MudTheme
		{
		public       CustomMudTheme_12() : base()
			{
				this.Typography.Default.FontFamily = new string[1] { "Montserrat-Regular" };
				this.Palette    .Info = Colors.Lime.Darken4;
				this.PaletteDark.Info = Colors.Lime.Darken4;
			}
		}

		public class CustomMudTheme_13
		                 : MudTheme
		{
		public       CustomMudTheme_13() : base()
			{
				this.Typography.Default.FontFamily = new string[1] { "Montserrat-Regular" };
				this.Palette    .Info = Colors.Yellow.Darken4;
				this.PaletteDark.Info = Colors.Yellow.Darken4;
			}
		}

		public class CustomMudTheme_14
		                 : MudTheme
		{
		public       CustomMudTheme_14() : base()
			{
				this.Typography.Default.FontFamily = new string[1] { "Montserrat-Regular" };
				this.Palette    .Info = Colors.Amber.Darken4;
				this.PaletteDark.Info = Colors.Amber.Darken4;
			}
		}

		public class CustomMudTheme_15
		                 : MudTheme
		{
		public       CustomMudTheme_15() : base()
			{
				this.Typography.Default.FontFamily = new string[1] { "Montserrat-Regular" };
				this.Palette    .Info = Colors.Orange.Darken4;
				this.PaletteDark.Info = Colors.Orange.Darken4;
			}
		}

		public class CustomMudTheme_16
		                 : MudTheme
		{
		public       CustomMudTheme_16() : base()
			{
				this.Typography.Default.FontFamily = new string[1] { "Montserrat-Regular" };
				this.Palette    .Info = Colors.DeepOrange.Darken4;
				this.PaletteDark.Info = Colors.DeepOrange.Darken4;
			}
		}

		public class CustomMudTheme_17
		                 : MudTheme
		{
		public       CustomMudTheme_17() : base()
			{
				this.Typography.Default.FontFamily = new string[1] { "Montserrat-Regular" };
				this.Palette    .Info = Colors.Brown.Darken4;
				this.PaletteDark.Info = Colors.Brown.Darken4;
			}
		}

		public class CustomMudTheme_18
		                 : MudTheme
		{
		public       CustomMudTheme_18() : base()
			{
				this.Typography.Default.FontFamily = new string[1] { "Montserrat-Regular" };
				this.Palette    .Info = Colors.BlueGrey.Darken4;
				this.PaletteDark.Info = Colors.BlueGrey.Darken4;
			}
		}

		public class CustomMudTheme_19
		                 : MudTheme
		{
		public       CustomMudTheme_19() : base()
			{
				this.Typography.Default.FontFamily = new string[1] { "Montserrat-Regular" };
				this.Palette    .Info = Colors.Grey.Darken4;
				this.PaletteDark.Info = Colors.Grey.Darken4;
			}
		}

		public static Dictionary<byte, MudTheme> CustomThemes { get; } = new()
		{
			{
				1
				,
				new CustomMudTheme_1()
			}
			,
			{
				2
				,
				new CustomMudTheme_2()
			}
			,
			{
				3,
				new CustomMudTheme_3()
			}
			,
			{
				4,
				new CustomMudTheme_4()
			}
			,
            {
                5,
                new CustomMudTheme_5()
            }
            ,
            {
                6,
                new CustomMudTheme_6()
            }
            ,
            {
                7,
                new CustomMudTheme_7()
            }
            ,
            {
                8,
                new CustomMudTheme_8()
            }
            ,
            {
                9,
                new CustomMudTheme_9()
            }
            ,
            {
                10,
                new CustomMudTheme_10()
            }
            ,
            {
                11,
                new CustomMudTheme_11()
            }
            ,
            {
                12,
                new CustomMudTheme_12()
            }
            ,
            {
                13,
                new CustomMudTheme_13()
            }
            ,
            {
                14,
                new CustomMudTheme_14()
            }
            ,
            {
                15,
                new CustomMudTheme_15()
            }
            ,
            {
                16,
                new CustomMudTheme_16()
            }
            ,
            {
                17,
                new CustomMudTheme_17()
            }
            ,
            {
                18,
                new CustomMudTheme_18()
            }
            ,
            {
                19,
                new CustomMudTheme_19()
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

		public static string ExtractMessage
		( this Supabase.Gotrue.Exceptions.     GotrueException    gotrueException)
		{
			try
			{
				JObject message = JObject.Parse(gotrueException.Message);
				return  message["msg"]              ?.Value<string>()
				    ??  message["error_description"]?.Value<string>()
				    ??  string.Empty;
			}
			catch (   Exception exception)
			{
				Debug.WriteLine(exception.Message); return Message.Error.SOMETHING_WENT_WRONG;
			}
		}

		public static string ExtractMessage
		( this Postgrest      .Exceptions.  PostgrestException postgrestException)
		{
			try
			{
				JObject message = JObject.Parse(postgrestException.Message);
				return  message["message"]          ?.Value<string>()
				    ??  string.Empty;
			}
			catch (   Exception exception)
			{
				Debug.WriteLine(exception.Message); return Message.Error.SOMETHING_WENT_WRONG;
			}
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
