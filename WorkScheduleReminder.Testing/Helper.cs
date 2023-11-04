using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkScheduleReminder.Testing
{
	public static class Helper
	{
		public static List<string> GenerateAllPossibleStrings(int length)
		{
			List<string> result = new();
			GenerateStringsRecursive("", length, result);
			return result;
		}

		public static void GenerateStringsRecursive(string current, int length, List<string> result)
		{
			if (length == 0)
			{
				result.Add(current);
				return;
			}

			for (char c = ' '; c <= '~'; c++)
			{
				GenerateStringsRecursive(current + c, length - 1, result);
			}
		}
	}
}
