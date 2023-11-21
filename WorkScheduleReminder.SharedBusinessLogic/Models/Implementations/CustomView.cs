using     Postgrest.Attributes;
using     WorkScheduleReminder.SharedBusinessLogic.Models.Abstractions___;

namespace WorkScheduleReminder.SharedBusinessLogic.Models.Implementations
{
	[Table("custom_views")]
	public class CustomView : CustomBaseModelTableN, ICustomView
	{
	public       CustomView() : base()
		{
		}

		[Column(columnName: "name")]
		public string Name { get; set; } = default!;

		[Column(columnName: "type")]
		public string Type { get; set; } = default!;

		[Column(columnName: "profile_id")]
		public Guid ProfileId { get; set; }

		[Column(columnName: "board___id")]
		public Guid   BoardId { get; set; }

		[Column(columnName: "settings")]
		public string Settings { get; set; } = default!;

		[Reference(joinType: ReferenceAttribute.JoinType.Left,
                   model:      typeof(Profile  ), 
                   columnName: nameof(ProfileId),
                   foreignKey: "custom_views_profile_id_fkey")]
		public Profile Profile { get; set; } = default!;

		[Reference(joinType: ReferenceAttribute.JoinType.Left,
                   model:      typeof(Board  ), 
                   columnName: nameof(BoardId),
                   foreignKey: "custom_views_board___id_fkey")]
		public   Board   Board { get; set; } = default!;
	}
}
