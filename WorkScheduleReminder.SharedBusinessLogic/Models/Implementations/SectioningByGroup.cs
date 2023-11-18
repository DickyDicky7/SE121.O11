using     Postgrest.Attributes;
using     WorkScheduleReminder.SharedBusinessLogic.Models.Abstractions___;

namespace WorkScheduleReminder.SharedBusinessLogic.Models.Implementations
{
	[Table("sectionings_by_groups__")]
	public class SectioningByGroup : CustomBaseModelTableJ, ISectioning
	{
	public       SectioningByGroup() : base()
		{
			PrimaryKeyPropertyName1 = nameof(SectionByGroupId);
			PrimaryKeyPropertyName2 = nameof(          TaskId);
		}

		[PrimaryKey(columnName: "task_id")]
		public Guid TaskId { get; set; }

		[Reference(joinType: ReferenceAttribute.JoinType.Left,
			       model:      typeof(Task  ),
			       columnName: nameof(TaskId),
			       foreignKey: "sectionings_by_groups___task_id_fkey")]
		public Task Task   { get; set; } = default!;

		[PrimaryKey(columnName: "section_by_group___id")]
		public Guid           SectionByGroupId { get; set; }

		[Reference(joinType: ReferenceAttribute.JoinType.Left,
			       model:      typeof(SectionByGroup  ),
			       columnName: nameof(SectionByGroupId),
			       foreignKey: "sectionings_by_groups___section_by_group___id_fkey")]
		public SectionByGroup SectionByGroup   { get; set; } = default!;
	}
}
