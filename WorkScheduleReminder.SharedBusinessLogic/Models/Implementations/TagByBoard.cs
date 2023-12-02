using     Postgrest.Attributes;
using     WorkScheduleReminder.SharedBusinessLogic.Models.Abstractions___;

namespace WorkScheduleReminder.SharedBusinessLogic.Models.Implementations
{
	[Table("tags_by_boards__")]
	public class TagByBoard : CustomBaseModelTableN, ITag
	{
	public       TagByBoard() : base()
		{
		}

		[Column(columnName: "board___id",
		        ignoreOnInsert: false,
		        ignoreOnUpdate: false)]
		public Guid  BoardId { get; set; }

		[Reference(joinType: ReferenceAttribute.JoinType.Left,
                   model:      typeof(Board  ),
                   columnName: nameof(BoardId),
                   foreignKey: "tags_by_boards___board___id_fkey",
		           includeInQuery: true,
		           ignoreOnInsert: true,
		           ignoreOnUpdate: true)]
		public Board Board   { get; set; } = default!;

		[Column(columnName: "name",
		        ignoreOnInsert: false,
		        ignoreOnUpdate: false)]
		public string Name     { get; set; } = default!;

		[Column(columnName: "settings",
		        ignoreOnInsert: false,
		        ignoreOnUpdate: false)]
		public string Settings { get; set; } = default!;
	}
}
