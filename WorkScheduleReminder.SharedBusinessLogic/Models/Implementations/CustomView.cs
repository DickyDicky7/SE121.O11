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

		[Column(columnName: "name",
		        ignoreOnInsert: false,
		        ignoreOnUpdate: false)]
		public string Name { get; set; } = default!;

		[Column(columnName: "profile_id",
		        ignoreOnInsert: false,
		        ignoreOnUpdate: false)]
		public Guid ProfileId { get; set; }

		[Column(columnName: "board___id",
		        ignoreOnInsert: false,
		        ignoreOnUpdate: false)]
		public Guid   BoardId { get; set; }

		[Column(columnName: "type",
		        ignoreOnInsert: false,
		        ignoreOnUpdate: false)]
		public string RealType { get; set; } = default!;

		[Column(columnName: "settings",
		        ignoreOnInsert: false,
		        ignoreOnUpdate: false)]
		public string Settings { get; set; } = default!;

		[Reference(joinType: ReferenceAttribute.JoinType.Left,
                   model:      typeof(Profile  ), 
                   columnName: nameof(ProfileId),
                   foreignKey: "custom_views_profile_id_fkey",
		           includeInQuery: true,
		           ignoreOnInsert: true,
		           ignoreOnUpdate: true)]
		public Profile Profile { get; set; } = default!;

		[Reference(joinType: ReferenceAttribute.JoinType.Left,
                   model:      typeof(Board  ), 
                   columnName: nameof(BoardId),
                   foreignKey: "custom_views_board___id_fkey",
		           includeInQuery: true,
		           ignoreOnInsert: true,
		           ignoreOnUpdate: true)]
		public   Board   Board { get; set; } = default!;

		[Column(ignoreOnInsert: true,
		        ignoreOnUpdate: true)]
		public      PossibleType Type { get => Enum.Parse<PossibleType>(RealType); set => RealType = value.ToString(); }

		public enum PossibleType
		{
			People,
			DueDay,
			BoardsAndSections,
		}
	}
}
