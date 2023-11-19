using     Postgrest.Attributes;
using     WorkScheduleReminder.SharedBusinessLogic.Models.Abstractions___;

namespace WorkScheduleReminder.SharedBusinessLogic.Models.Implementations
{
	[Table("boards__")]
	public class Board : CustomBaseModelTableN, IBoard
	{
	public       Board() : base() 
		{
		}

		[Column(columnName: "name")]
		public string Name { get; set; } = default!;

		[Column(columnName: "owner_id")]
		public Guid    OwnerId { get; set; }

		[Reference(joinType: ReferenceAttribute.JoinType.Left,
			       model:      typeof(Profile), 
			       columnName: nameof(OwnerId),
			       foreignKey: "boards___owner_id_fkey")]
		public Profile Owner   { get; set; } = default!;
	}
}
