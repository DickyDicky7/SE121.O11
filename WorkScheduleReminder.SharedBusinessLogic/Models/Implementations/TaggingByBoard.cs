using     Postgrest.Attributes;
using     WorkScheduleReminder.SharedBusinessLogic.Models.Abstractions___;

namespace WorkScheduleReminder.SharedBusinessLogic.Models.Implementations
{
	[Table("taggings_by_boards__")]
	public class TaggingByBoard : CustomBaseModelTableJ, ITagging
	{
	public       TaggingByBoard() : base()
		{
			PrimaryKeyPropertyName1 = nameof(TagByBoardId);
			PrimaryKeyPropertyName2 = nameof(      TaskId);
		}

		[PrimaryKey(columnName: "task_id",
		            shouldInsert: true)]
		public Guid TaskId { get; set; }

		[Reference(joinType: ReferenceAttribute.JoinType.Left,
                   model:      typeof(Task  ),
                   columnName: nameof(TaskId),
                   foreignKey: "taggings_by_boards___task_id_fkey",
		           includeInQuery: true,
		           ignoreOnInsert: true,
		           ignoreOnUpdate: true)]
		public Task Task   { get; set; } = default!;

		[PrimaryKey(columnName: "tag_by_board___id",
		            shouldInsert: true)]
		public Guid       TagByBoardId { get; set; }

		[Reference(joinType: ReferenceAttribute.JoinType.Left,
                   model:      typeof(TagByBoard  ),
                   columnName: nameof(TagByBoardId),
                   foreignKey: "taggings_by_boards___tag_by_board___id_fkey",
		           includeInQuery: true,
		           ignoreOnInsert: true,
		           ignoreOnUpdate: true)]
		public TagByBoard TagByBoard   { get; set; } = default!;
	}
}
