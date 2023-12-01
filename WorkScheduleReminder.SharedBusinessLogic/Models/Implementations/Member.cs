using     Postgrest.Attributes;
using     WorkScheduleReminder.SharedBusinessLogic.Models.Abstractions___;

namespace WorkScheduleReminder.SharedBusinessLogic.Models.Implementations
{
	[Table("members")]
	public class Member : CustomBaseModelTableJ, IMember
	{
	public       Member() : base()
		{
			PrimaryKeyPropertyName1 = nameof(  BoardId);
			PrimaryKeyPropertyName2 = nameof(ProfileId);
		}

		[PrimaryKey(columnName: "board___id",
		            shouldInsert: true)]
		public Guid   BoardId { get; set; }

		[PrimaryKey(columnName: "profile_id",
		            shouldInsert: true)]
		public Guid ProfileId { get; set; }

		[Reference(joinType: ReferenceAttribute.JoinType.Left,
                   model:      typeof(Board  ),
                   columnName: nameof(BoardId),
                   foreignKey: "members_board___id_fkey",
		           includeInQuery: true,
		           ignoreOnInsert: true,
		           ignoreOnUpdate: true)]
		public   Board   Board { get; set; } = default!;

		[Reference(joinType: ReferenceAttribute.JoinType.Left,
                   model:      typeof(Profile  ),
                   columnName: nameof(ProfileId),
                   foreignKey: "members_profile_id_fkey",
		           includeInQuery: true,
		           ignoreOnInsert: true,
		           ignoreOnUpdate: true)]
		public Profile Profile { get; set; } = default!;

		[Column(columnName: "role",
		        ignoreOnInsert: false,
		        ignoreOnUpdate: false)]
		public string RealRole { get; set; } = default!;

		[Column(columnName: "settings",
		        ignoreOnInsert: false,
		        ignoreOnUpdate: false)]
		public string Settings { get; set; } = default!;

		[Column(columnName: "invitation_accepted",
		        ignoreOnInsert: false,
		        ignoreOnUpdate: false)]
		public bool InvitationAccepted { get; set; }

		[Column(ignoreOnInsert: true, 
		        ignoreOnUpdate: true)]
		public      PossibleRole  Role { get => Enum.Parse<PossibleRole>(RealRole); set => RealRole = value.ToString(); }

		public enum PossibleRole
		{
			Editor,
			Viewer,
		}
	}
}
