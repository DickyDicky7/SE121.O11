﻿using     Postgrest.Attributes;
using     WorkScheduleReminder.SharedBusinessLogic.Models.Abstractions___;

namespace WorkScheduleReminder.SharedBusinessLogic.Models.Implementations
{
	[Table("tags_by_profiles")]
	public class TagByProfile : CustomBaseModelTableN
	{
		[PrimaryKey(columnName: "name")]
		public string Name     { get; set; } = null!;

		[Column    (columnName: "settings")]
		public string Settings { get; set; } = null!;

		[PrimaryKey(columnName: "profile_id")]
		public Guid    ProfileId { get; set; }

		[Reference(joinType: ReferenceAttribute.JoinType.Left,
			       model:      typeof(Profile  ),
			       columnName: nameof(ProfileId),
			       foreignKey: "tags_by_profiles_profile_id_fkey")]
		public Profile Profile   { get; set; } = null!;
	}
}
