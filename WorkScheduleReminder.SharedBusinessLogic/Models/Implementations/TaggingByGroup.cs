using     Postgrest.Attributes;
using     WorkScheduleReminder.SharedBusinessLogic.Models.Abstractions___;

namespace WorkScheduleReminder.SharedBusinessLogic.Models.Implementations
{
	[Table("taggings_by_groups__")]
	public class TaggingByGroup : CustomBaseModelTableJ
	{
	public       TaggingByGroup() : base()
		{
			PrimaryKeyPropertyName1 = nameof(TagByGroupId);
			PrimaryKeyPropertyName2 = nameof(      TaskId);
		}

		[PrimaryKey(columnName: "task_id")]
		public Guid TaskId { get; set; }

		[Reference(joinType: ReferenceAttribute.JoinType.Left,
			       model:      typeof(Task  ),
			       columnName: nameof(TaskId),
			       foreignKey: "taggings_by_groups___task_id_fkey")]
		public Task Task   { get; set; } = default!;

		[PrimaryKey(columnName: "tag_by_group___id")]
		public Guid       TagByGroupId { get; set; }

		[Reference(joinType: ReferenceAttribute.JoinType.Left,
			       model:      typeof(TagByGroup  ),
			       columnName: nameof(TagByGroupId),
			       foreignKey: "taggings_by_groups___tag_by_group___id_fkey")]
		public TagByGroup TagByGroup   { get; set; } = default!;
	}
}
