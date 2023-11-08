using     Postgrest.Attributes;
using     WorkScheduleReminder.SharedBusinessLogic.Models.Abstractions___;

namespace WorkScheduleReminder.SharedBusinessLogic.Models.Implementations
{
	[Table("tags_by_groups__")]
	public class TagByGroup : CustomBaseModelTableN
	{
	public       TagByGroup() : base()
		{
		}

		[PrimaryKey(columnName: "group___id")]
		public Guid  GroupId { get; set; }

		[Reference(joinType: ReferenceAttribute.JoinType.Left,
			       model:      typeof(Group  ),
			       columnName: nameof(GroupId),
			       foreignKey: "tags_by_groups___group___id_fkey")]
		public Group Group   { get; set; } = default!;

		[PrimaryKey(columnName: "name")]
		public string Name     { get; set; } = default!;

		[Column    (columnName: "settings")]
		public string Settings { get; set; } = default!;
	}
}
