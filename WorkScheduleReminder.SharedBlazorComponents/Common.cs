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

		public record class PersonalSettings
		{
			public bool IsDarkMode { get; set; } = false;
			public byte ThemeId    { get; set; } = 1;
		}

		public record class Task__AndPinOrNot
		{
			public Models.Task Task { get; set; } = null!;
			public bool Pinned { get; set; }
			public TaskIdAndPinOrNot TaskIdAndPinOrNot => new()
			{
				TaskId = Task.Id,
				Pinned = Pinned
			};
		}

		public record class TaskIdAndPinOrNot
		{
			public Guid TaskId { get; set; }
			public bool Pinned { get; set; }
		}

		public record class MyDayTasks
		{
			public List<TaskIdAndPinOrNot> TaskIdsAndPinOrNot { get; set; } = new();
			public DateOnly Date{ get; set; } = DateOnly.FromDateTime(DateTime.Now);
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
			public bool   AssigneesAvailable => Task.Assignees != "[]";
			public bool    SubtasksAvailable => Task.Checklist != "[]";
			public bool AttachmentsAvailable => Task.Attachments != "[]";
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
