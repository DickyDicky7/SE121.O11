using     Postgrest.Attributes;
using     WorkScheduleReminder.SharedBusinessLogic.Models.Abstractions___;

namespace WorkScheduleReminder.SharedBusinessLogic.Models.Implementations
{
	[Table("members")]
	public class Member : CustomBaseModelTableJ, IMember
	{
	public       Member() : base()
		{
			PrimaryKeyPropertyName1 = nameof(  GroupId);
			PrimaryKeyPropertyName2 = nameof(ProfileId);
		}

		[PrimaryKey(columnName: "group___id")]
		public Guid   GroupId { get; set; }

		[PrimaryKey(columnName: "profile_id")]
		public Guid ProfileId { get; set; }

		[Reference(joinType: ReferenceAttribute.JoinType.Left,
			       model:      typeof(Group  ),
			       columnName: nameof(GroupId),
			       foreignKey: "members_group___id_fkey")]
		public   Group   Group { get; set; } = default!;

		[Reference(joinType: ReferenceAttribute.JoinType.Left,
			       model:      typeof(Profile  ),
			       columnName: nameof(ProfileId),
			       foreignKey: "members_profile_id_fkey")]
		public Profile Profile { get; set; } = default!;

		[Column(columnName: "role")]
		public string Role { get; set; } = default!;

		[Column(columnName: "invitation_accepted")]
		public  bool? InvitationAccepted { get; set; }
	}
}
