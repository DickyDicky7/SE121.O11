using     Postgrest.Attributes;
using     WorkScheduleReminder.SharedBusinessLogic.Models.Abstractions___;

namespace WorkScheduleReminder.SharedBusinessLogic.Models.Implementations
{
	[Table("sectionings_by_profiles")]
	public class SectioningByProfile : CustomBaseModelTableJ, ISectioning
	{
	public       SectioningByProfile() : base()
		{
			PrimaryKeyPropertyName1 = nameof(SectionByProfileId);
			PrimaryKeyPropertyName2 = nameof(            TaskId);
		}

		[PrimaryKey(columnName: "task_id")]
		public Guid TaskId { get; set; }

		[Reference(joinType: ReferenceAttribute.JoinType.Left,
                   model:      typeof(Task  ),
                   columnName: nameof(TaskId),
                   foreignKey: "sectionings_by_profiles_task_id_fkey")]
		public Task Task   { get; set; } = default!;

		[PrimaryKey(columnName: "section_by_profile_id")]
		public Guid             SectionByProfileId { get; set; }

		[Reference(joinType: ReferenceAttribute.JoinType.Left,
                   model:      typeof(SectionByProfile  ),
                   columnName: nameof(SectionByProfileId),
                   foreignKey: "sectionings_by_profiles_section_by_profile_id_fkey")]
		public SectionByProfile SectionByProfile   { get; set; } = default!;
	}
}
