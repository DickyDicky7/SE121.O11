using     Postgrest.Attributes;
using     WorkScheduleReminder.SharedBusinessLogic.Models.Abstractions___;

namespace WorkScheduleReminder.SharedBusinessLogic.Models.Implementations
{
	[Table("sections_by_boards__")]
	public class SectionByBoard : CustomBaseModelTableN, ISection
	{
	public       SectionByBoard() : base()
		{
		}

		[Column(columnName: "board___id",
		        ignoreOnInsert: false,
		        ignoreOnUpdate: false)]
		public Guid  BoardId { get; set; }

		[Reference(joinType: ReferenceAttribute.JoinType.Left,
                   model:      typeof(Board  ),
                   columnName: nameof(BoardId),
                   foreignKey: "sections_by_boards___board___id_fkey",
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
