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

		[Column(columnName: "name",
		        ignoreOnInsert: false,
		        ignoreOnUpdate: false)]
		public string Name { get; set; } = default!;

		[Column(columnName: "owner_id",
		        ignoreOnInsert: false,
		        ignoreOnUpdate: false)]
		public Guid    OwnerId { get; set; }

		[Reference(joinType: ReferenceAttribute.JoinType.Left,
                   model:      typeof(Profile), 
                   columnName: nameof(OwnerId),
                   foreignKey: "boards___owner_id_fkey",
		           includeInQuery: true,
		           ignoreOnInsert: true,
		           ignoreOnUpdate: true)]
		public Profile Owner   { get; set; } = default!;
	}
}
