using     Postgrest.Attributes;
using     WorkScheduleReminder.SharedBusinessLogic.Models.Abstractions___;

namespace WorkScheduleReminder.SharedBusinessLogic.Models.Implementations
{
	[Table("taggings_by_groups__")]
	public class TaggingByGroup : CustomBaseModelTableJ
	{
	public       TaggingByGroup() : base()
		{
			PrimaryKeyPropertyName1 = nameof(GroupId);
			PrimaryKeyPropertyName2 = nameof( TaskId);
			PrimaryKeyPropertyName3 = nameof(Name);
			PrimaryKeyPropertyName4 = "";
			PrimaryKeyPropertyName5 = "";
			PrimaryKeyPropertyName6 = "";
			PrimaryKeyPropertyName7 = "";
			PrimaryKeyPropertyName8 = "";
		}

		[PrimaryKey(columnName: "group_id")]
		public Guid  GroupId { get; set; }

		[Reference(joinType: ReferenceAttribute.JoinType.Left,
			       model:            typeof(Group  ),
			       columnName:       nameof(GroupId),
			       foreignKey: "taggings_by_groups___group_id_fkey")]
		public Group Group { get; set; } = null!;

		[PrimaryKey(columnName: "name")]
		public string Name { get; set; } = null!;

		[PrimaryKey(columnName: "task_id")]
		public Guid TaskId { get; set; }

		[Reference(joinType: ReferenceAttribute.JoinType.Left,
			       model:            typeof(Task  ),
			       columnName:       nameof(TaskId),
			       foreignKey: "taggings_by_groups___task_id_fkey")]
		public Task Task   { get; set; } = null!;
	}
}
