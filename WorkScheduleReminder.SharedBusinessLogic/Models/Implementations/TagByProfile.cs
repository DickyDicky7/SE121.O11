using     Postgrest.Attributes;
using     WorkScheduleReminder.SharedBusinessLogic.Models.Abstractions___;

namespace WorkScheduleReminder.SharedBusinessLogic.Models.Implementations
{
	[Table("tags_by_profiles")]
	public class TagByProfile : CustomBaseModelTableN, ITag
	{
	public       TagByProfile() : base()
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
                   foreignKey: "tags_by_profiles_profile_id_fkey",
		           includeInQuery: true,
		           ignoreOnInsert: true,
		           ignoreOnUpdate: true)]
		public Profile Profile   { get; set; } = default!;
	}
}
