﻿using     Postgrest.Attributes;
using     WorkScheduleReminder.SharedBusinessLogic.Models.Abstractions___;

namespace WorkScheduleReminder.SharedBusinessLogic.Models.Implementations
{
	[Table("tags_by_groups__")]
	public class TagByGroup : CustomBaseModelTableN
	{
		[PrimaryKey(columnName: "group___id")]
		public Guid  GroupId { get; set; }

		[Reference(joinType: ReferenceAttribute.JoinType.Left,
			       model:      typeof(Group  ),
			       columnName: nameof(GroupId),
			       foreignKey: "tags_by_groups___group___id_fkey")]
		public Group Group   { get; set; } = null!;

		[PrimaryKey(columnName: "name")]
		public string Name     { get; set; } = null!;

		[Column    (columnName: "settings")]
		public string Settings { get; set; } = null!;
	}
}