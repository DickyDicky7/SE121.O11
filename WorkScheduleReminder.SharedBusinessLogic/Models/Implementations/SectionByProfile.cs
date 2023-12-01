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

		[Column(columnName: "name",
		        ignoreOnInsert: false,
		        ignoreOnUpdate: false)]
		public string Name     { get; set; } = default!;

		[Column(columnName: "settings",
		        ignoreOnInsert: false,
		        ignoreOnUpdate: false)]
		public string Settings { get; set; } = default!;

		[Column(columnName: "profile_id",
		        ignoreOnInsert: false,
		        ignoreOnUpdate: false)]
		public Guid    ProfileId { get; set; }

		[Reference(joinType: ReferenceAttribute.JoinType.Left,
                   model:      typeof(Profile  ),
                   columnName: nameof(ProfileId),
                   foreignKey: "sections_by_profiles_profile_id_fkey",
		           includeInQuery: true,
		           ignoreOnInsert: true,
		           ignoreOnUpdate: true)]
		public Profile Profile   { get; set; } = default!;
	}
}
