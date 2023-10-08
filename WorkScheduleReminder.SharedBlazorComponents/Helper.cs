using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WorkScheduleReminder.SharedBlazorComponents
{
	public class Helper
	{
		public static Assembly[] DependencyAdditionalAssemblies { get; set; } = new[] { Assembly.GetExecutingAssembly() };
		
		public static string GetResource(string path)
		{
			StringBuilder stringBuilder = new("_content/WorkScheduleReminder.SharedBlazorComponents");
			return        stringBuilder.Append(path).ToString();
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
	}
}
