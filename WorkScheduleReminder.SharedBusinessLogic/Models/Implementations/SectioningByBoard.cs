using     Postgrest.Attributes;
using     WorkScheduleReminder.SharedBusinessLogic.Models.Abstractions___;

namespace WorkScheduleReminder.SharedBusinessLogic.Models.Implementations
{
	[Table("sectionings_by_boards__")]
	public class SectioningByBoard : CustomBaseModelTableJ, ISectioning
	{
	public       SectioningByBoard() : base()
		{
			PrimaryKeyPropertyName1 = nameof(SectionByBoardId);
			PrimaryKeyPropertyName2 = nameof(          TaskId);
		}

		[PrimaryKey(columnName: "task_id",
		            shouldInsert: true)]
		public Guid TaskId { get; set; }

		[Reference(joinType: ReferenceAttribute.JoinType.Left,
                   model:      typeof(Task  ),
                   columnName: nameof(TaskId),
                   foreignKey: "sectionings_by_boards___task_id_fkey",
		           includeInQuery: true,
		           ignoreOnInsert: true,
		           ignoreOnUpdate: true)]
		public Task Task   { get; set; } = default!;

		[PrimaryKey(columnName: "section_by_board___id",
		            shouldInsert: true)]
		public Guid           SectionByBoardId { get; set; }

		[Reference(joinType: ReferenceAttribute.JoinType.Left,
                   model:      typeof(SectionByBoard  ),
                   columnName: nameof(SectionByBoardId),
                   foreignKey: "sectionings_by_boards___section_by_board___id_fkey",
		           includeInQuery: true,
		           ignoreOnInsert: true,
		           ignoreOnUpdate: true)]
		public SectionByBoard SectionByBoard   { get; set; } = default!;
	}
}
