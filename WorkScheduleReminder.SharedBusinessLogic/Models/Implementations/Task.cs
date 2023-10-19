using     Postgrest.Attributes;
using     WorkScheduleReminder.SharedBusinessLogic.Models.Abstractions___;

namespace WorkScheduleReminder.SharedBusinessLogic.Models.Implementations
{
	[Table("tasks")]
	public class Task : CustomBaseModelTableN
	{
		[Column(columnName: "name")]
		public string Name { get; set; } = null!;

		[Column(columnName: "note")]
		public string Note { get; set; } = null!;

		[Column(columnName: "done")]
		public bool   Done { get; set; }

		[Column(columnName: "checklist")]
		public string Checklist { get; set; } = null!;

		[Column(columnName: "begin_date")]
		public DateOnly? BeginDate {  get; set; }

		[Column(columnName: "cease_date")]
		public DateOnly? CeaseDate { get; set; }

		[Column(columnName: "begin_time")]
		public DateTimeOffset? BeginTime { get; set; }

		[Column(columnName: "cease_time")]
		public DateTimeOffset? CeaseTime { get; set; }

		[Column(columnName: "settings")]
		public string Settings { get; set; } = null!;

		[Column(columnName: "reminder")]
		public string Reminder { get; set; } = null!;

		[Column(columnName: "attachments")]
		public string Attachments { get; set; } = null!;

		[Column(columnName: "group___id")]
		public Guid?   GroupId { get; set; }

		[Column(columnName: "profile_id")]
		public Guid? ProfileId { get; set; }

		[Reference(joinType: ReferenceAttribute.JoinType.Left,
				   model:      typeof(Group  ),
				   columnName: nameof(GroupId),
				   foreignKey: "tasks_group___id_fkey")]
		public   Group?   Group { get; set; }

		[Reference(joinType: ReferenceAttribute.JoinType.Left,
				   model:      typeof(Profile  ),
				   columnName: nameof(ProfileId),
				   foreignKey: "tasks_profile_id_fkey")]
		public Profile? Profile { get; set; }
	}
}
