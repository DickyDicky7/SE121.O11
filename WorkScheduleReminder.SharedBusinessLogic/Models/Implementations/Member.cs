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

		[PrimaryKey(columnName: "board___id")]
		public Guid   BoardId { get; set; }

		[PrimaryKey(columnName: "profile_id")]
		public Guid ProfileId { get; set; }

		[Reference(joinType: ReferenceAttribute.JoinType.Left,
                   model:      typeof(Board  ),
                   columnName: nameof(BoardId),
                   foreignKey: "members_board___id_fkey")]
		public   Board   Board { get; set; } = default!;

		[Reference(joinType: ReferenceAttribute.JoinType.Left,
                   model:      typeof(Profile  ),
                   columnName: nameof(ProfileId),
                   foreignKey: "members_profile_id_fkey")]
		public Profile Profile { get; set; } = default!;

		[Column(columnName: "role")]
		public string     Role { get; set; } = default!;

		[Column(columnName: "settings")]
		public string Settings { get; set; } = default!;

		[Column(columnName: "invitation_accepted")]
		public  bool? InvitationAccepted { get; set; }
	}
}
