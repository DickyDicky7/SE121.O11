using     Postgrest.Attributes;
using     WorkScheduleReminder.SharedBusinessLogic.Models.Abstractions___;

namespace WorkScheduleReminder.SharedBusinessLogic.Models.Implementations
{
	[Table("sections_by_profiles")]
	public class SectionByProfile : CustomBaseModelTableN, ISection
	{
	public       SectionByProfile() : base()
		{
		}

		[PrimaryKey(columnName: "name")]
		public string Name     { get; set; } = default!;

		[Column    (columnName: "settings")]
		public string Settings { get; set; } = default!;

		[PrimaryKey(columnName: "profile_id")]
		public Guid    ProfileId { get; set; }

		[Reference(joinType: ReferenceAttribute.JoinType.Left,
                   model:      typeof(Profile  ),
                   columnName: nameof(ProfileId),
                   foreignKey: "sections_by_profiles_profile_id_fkey")]
		public Profile Profile   { get; set; } = default!;
	}
}
