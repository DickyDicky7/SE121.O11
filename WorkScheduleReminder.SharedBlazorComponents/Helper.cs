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
		public static Assembly[] LibraryAdditionalAssemblies = new[] { Assembly.GetExecutingAssembly()};
		public static string GetResource(string path)
		{
			StringBuilder stringBuilder = new("_content/WorkScheduleReminder.SharedBlazorComponents");
			return stringBuilder.Append(path).ToString();
		}
	}
}
