using     Postgrest.Attributes;
using     WorkScheduleReminder.SharedBusinessLogic.Models.Abstractions___;

namespace WorkScheduleReminder.SharedBusinessLogic.Models.Implementations
{
	[Table("groups__")]
	public class Group : CustomBaseModelTableN
	{
		[Column(columnName: "name")]
		public string Name { get; set; } = default!;

		[Column(columnName: "owner_id")]
		public Guid    OwnerId { get; set; }

		[Reference(joinType: ReferenceAttribute.JoinType.Left,
			       model:      typeof(Profile), 
			       columnName: nameof(OwnerId),
			       foreignKey: "groups___owner_id_fkey")]
		public Profile Owner   { get; set; } = default!;
	}
}
