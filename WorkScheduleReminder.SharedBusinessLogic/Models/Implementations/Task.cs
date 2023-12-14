using     Postgrest.Attributes;
using     WorkScheduleReminder.SharedBusinessLogic.Models.Abstractions___;

namespace WorkScheduleReminder.SharedBusinessLogic.Models.Implementations
{
	[Table("tasks")]
	public class Task : CustomBaseModelTableN, ITask
	{
	public       Task() : base()
		{
		}

		[Column(columnName: "name",
		        ignoreOnInsert: false,
		        ignoreOnUpdate: false)]
		public string Name { get; set; } = default!;

		[Column(columnName: "note",
		        ignoreOnInsert: false,
		        ignoreOnUpdate: false)]
		public string Note { get; set; } = default!;

		[Column(columnName: "done",
		        ignoreOnInsert: false,
		        ignoreOnUpdate: false)]
		public bool   Done { get; set; }

		[Column(columnName: "checklist",
		        ignoreOnInsert: false,
		        ignoreOnUpdate: false)]
		public string Checklist { get; set; } = default!;

		[Column(columnName: "reminder_begin_date",
		        ignoreOnInsert: false,
		        ignoreOnUpdate: false)]
		public DateOnly? ReminderBeginDate {  get; set; }

		[Column(columnName: "reminder_cease_date",
		        ignoreOnInsert: false,
		        ignoreOnUpdate: false)]
		public DateOnly? ReminderCeaseDate { get; set; }

		[Column(columnName: "reminder_begin_time",
		        ignoreOnInsert: false,
		        ignoreOnUpdate: false)]
		public TimeOnly? ReminderBeginTime { get; set; }

		[Column(columnName: "reminder_cease_time",
		        ignoreOnInsert: false,
		        ignoreOnUpdate: false)]
		public TimeOnly? ReminderCeaseTime { get; set; }

		[Column(columnName: "settings",
		        ignoreOnInsert: false,
		        ignoreOnUpdate: false)]
		public string Settings { get; set; } = default!;

		[Column(columnName: "reminder_recurring_mode",
		        ignoreOnInsert: false,
		        ignoreOnUpdate: false)]
		public string ReminderRecurringMode     { get; set; } = default!;

		[Column(columnName: "reminder_recurring_settings",
		        ignoreOnInsert: false,
		        ignoreOnUpdate: false)]
		public string ReminderRecurringSettings { get; set; } = default!;

		[Column(columnName: "attachments",
		        ignoreOnInsert: false,
		        ignoreOnUpdate: false)]
		public string Attachments { get; set; } = default!;

		[Column(columnName: "due_date",
		        ignoreOnInsert: false,
		        ignoreOnUpdate: false)]
		public DateOnly DueDate { get; set; }

		[Column(columnName: "due_time",
		        ignoreOnInsert: false,
		        ignoreOnUpdate: false)]
		public TimeOnly DueTime { get; set; }

		[Column(columnName: "board___id",
		        ignoreOnInsert: false,
		        ignoreOnUpdate: false)]
		public Guid?   BoardId { get; set; }

		[Column(columnName: "profile_id",
		        ignoreOnInsert: false,
		        ignoreOnUpdate: false)]
		public Guid? ProfileId { get; set; }

		[Reference(joinType: ReferenceAttribute.JoinType.Left,
                   model:      typeof(Board  ),
                   columnName: nameof(BoardId),
                   foreignKey: "tasks_board___id_fkey",
		           includeInQuery: true,
		           ignoreOnInsert: true,
		           ignoreOnUpdate: true)]
		public   Board?   Board { get; set; }

		[Reference(joinType: ReferenceAttribute.JoinType.Left,
                   model:      typeof(Profile  ),
                   columnName: nameof(ProfileId),
                   foreignKey: "tasks_profile_id_fkey",
		           includeInQuery: true,
		           ignoreOnInsert: true,
		           ignoreOnUpdate: true)]
		public Profile? Profile { get; set; }

		public bool IsBoardTask() => BoardId != null;

		public bool HasReminder() => ReminderRecurringMode != PossibleReminderRecurringMode.Empty.ToString()
		&& ReminderBeginDate != null
		&& ReminderBeginTime != null;

		public bool HasReminderNeverEnd()
		=>          HasReminder()
		&& ReminderCeaseDate == null
		&& ReminderCeaseTime == null;

		public enum PossibleReminderRecurringMode
		{
			Empty,
			Daily,
			Weekly,
			Monthly,
			Yearly,
		}
	}
}
