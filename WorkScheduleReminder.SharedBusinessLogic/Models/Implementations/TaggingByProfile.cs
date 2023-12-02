using     Postgrest.Attributes;
using     WorkScheduleReminder.SharedBusinessLogic.Models.Abstractions___;

namespace WorkScheduleReminder.SharedBusinessLogic.Models.Implementations
{
	[Table("taggings_by_profiles")]
	public class TaggingByProfile : CustomBaseModelTableJ, ITagging
	{
	public       TaggingByProfile() : base()
		{
			PrimaryKeyPropertyName1 = nameof(TagByProfileId);
			PrimaryKeyPropertyName2 = nameof(        TaskId);
		}

		[PrimaryKey(columnName: "task_id",
		            shouldInsert: true)]
		public Guid TaskId { get; set; }

		[Reference(joinType: ReferenceAttribute.JoinType.Left,
                   model:      typeof(Task  ),
                   columnName: nameof(TaskId),
                   foreignKey: "taggings_by_profiles_task_id_fkey",
		           includeInQuery: true,
		           ignoreOnInsert: true,
		           ignoreOnUpdate: true)]
		public Task Task   { get; set; } = default!;

		[PrimaryKey(columnName: "tag_by_profile_id",
		            shouldInsert: true)]
		public Guid         TagByProfileId { get; set; }

		[Reference(joinType: ReferenceAttribute.JoinType.Left,
                   model:      typeof(TagByProfile  ),
                   columnName: nameof(TagByProfileId),
                   foreignKey: "taggings_by_profiles_tag_by_profile_id_fkey",
		           includeInQuery: true,
		           ignoreOnInsert: true,
		           ignoreOnUpdate: true)]
		public TagByProfile TagByProfile   { get; set; } = default!;
	}
}
