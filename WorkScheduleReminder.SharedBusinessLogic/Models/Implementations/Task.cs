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

		[Column(columnName: "begin_date",
		        ignoreOnInsert: false,
		        ignoreOnUpdate: false)]
		public DateOnly? BeginDate {  get; set; }

		[Column(columnName: "cease_date",
		        ignoreOnInsert: false,
		        ignoreOnUpdate: false)]
		public DateOnly? CeaseDate { get; set; }

		[Column(columnName: "begin_time",
		        ignoreOnInsert: false,
		        ignoreOnUpdate: false)]
		public TimeOnly? BeginTime { get; set; }

		[Column(columnName: "cease_time",
		        ignoreOnInsert: false,
		        ignoreOnUpdate: false)]
		public TimeOnly? CeaseTime { get; set; }

		[Column(columnName: "settings",
		        ignoreOnInsert: false,
		        ignoreOnUpdate: false)]
		public string Settings { get; set; } = default!;

		[Column(columnName: "reminder",
		        ignoreOnInsert: false,
		        ignoreOnUpdate: false)]
		public string Reminder { get; set; } = default!;

		[Column(columnName: "attachments",
		        ignoreOnInsert: false,
		        ignoreOnUpdate: false)]
		public string Attachments { get; set; } = default!;

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
	}
}
