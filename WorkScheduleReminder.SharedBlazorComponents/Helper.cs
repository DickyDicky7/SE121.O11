using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Text.RegularExpressions;

namespace WorkScheduleReminder.SharedBlazorComponents
{
	public static class Helper
	{
		public static Assembly[] DependencyAdditionalAssemblies = new[] { Assembly.GetExecutingAssembly() };

		public static string GetResource(string path)
		{
			StringBuilder stringBuilder = new("_content/WorkScheduleReminder.SharedBlazorComponents");
			return        stringBuilder.Append(path).ToString();
		}

		public enum   ViewType
		{
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
							 FontFamily = new string[1] { "Mooli-Regular" },
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

		public static (bool ok, string reason) CheckEmailFormat(string email)
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

		public static (bool ok, string reason) CheckPasswordFormat(string password)
		{
			if (string.IsNullOrWhiteSpace(password))
			{
				return (ok: false, reason: Message.Error.EMPTY_PASSWORD);
			}

			    return (ok: true , reason: string.Empty);
		}
	}
}
