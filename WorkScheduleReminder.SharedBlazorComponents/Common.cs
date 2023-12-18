using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models = WorkScheduleReminder.SharedBusinessLogic.Models.Implementations;

namespace WorkScheduleReminder.SharedBlazorComponents
{
	public static class Common
	{
		public record class ReminderRecurringSettings
		{
			public List<string> DaysOfWeek { get; set; } = new();
			public int Every { get; set; } = 1;
			public void IncreaseEveryByOne() => ++Every;
			public void DecreaseEveryByOne() => --Every;
			public static string[] GetDaysOfWeek()
			=> new string[7] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };
		}

		public record class Tag
		{
			public Guid Id { get; set; }
			public Color Color { get; set; }
			public string Name { get; set; } = null!;
		}

		public record class SectionTask
		{
			public Models.Task Task { get; init; } = null!;
			public List<Tag>   Tags { get; init; } = null!;
			public bool    SubtasksAvailable { get; init; } = false;
			public bool AttachmentsAvailable { get; init; } = false;
			public List<Models.Profile> Assignees { get; set; } = null!;
		}

		public record class Section
		{
			public bool IsSectionByBoard                { get; init; } = false;
			public Models.SectionByBoard SectionByBoard { get; init; } = null!;
			public int DaysOffset { get; set; }
			public string Name    { get; set; } = null!;
			public string NewTask { get; set; } = string.Empty;
			public List<SectionTask> SectionTasks { get;  init; } = null!;
		}
	}
}
