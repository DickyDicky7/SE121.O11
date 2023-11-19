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

		[PrimaryKey(columnName: "board___id")]
		public Guid  BoardId { get; set; }

		[Reference(joinType: ReferenceAttribute.JoinType.Left,
			       model:      typeof(Board  ),
			       columnName: nameof(BoardId),
			       foreignKey: "tags_by_boards___board___id_fkey")]
		public Board Board   { get; set; } = default!;

		[PrimaryKey(columnName: "name")]
		public string Name     { get; set; } = default!;

		[Column    (columnName: "settings")]
		public string Settings { get; set; } = default!;
	}
}
