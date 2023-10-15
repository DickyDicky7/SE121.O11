using     Postgrest.Attributes;
using     WorkScheduleReminder.SharedBusinessLogic.Models.Abstractions___;

namespace WorkScheduleReminder.SharedBusinessLogic.Models.Implementations
{
	[Table("tags_by_groups__")]
	public class TagByGroup : CustomBaseModelTableJ
	{
	public       TagByGroup() : base()
		{
			PrimaryKeyPropertyName1 = nameof(GroupId);
			PrimaryKeyPropertyName2 = nameof(Name);
			PrimaryKeyPropertyName3 = "";
			PrimaryKeyPropertyName4 = "";
			PrimaryKeyPropertyName5 = "";
			PrimaryKeyPropertyName6 = "";
			PrimaryKeyPropertyName7 = "";
			PrimaryKeyPropertyName8 = "";
		}

		[PrimaryKey(columnName: "group_id")]
		public Guid  GroupId { get; set; }

		[Reference(joinType: ReferenceAttribute.JoinType.Left,
			       model:        typeof(Group  ),
			       columnName:   nameof(GroupId),
			       foreignKey: "tags_by_groups___group_id_fkey")]
		public Group Group   { get; set; } = null!;

		[PrimaryKey(columnName: "name")]
		public string Name     { get; set; } = null!;

		[Column    (columnName: "settings")]
		public string Settings { get; set; } = null!;
	}
}
