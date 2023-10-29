using     Postgrest.Attributes;
using     WorkScheduleReminder.SharedBusinessLogic.Models.Abstractions___;

namespace WorkScheduleReminder.SharedBusinessLogic.Models.Implementations
{
	[Table("taggings_by_profiles")]
	public class TaggingByProfile : CustomBaseModelTableJ
	{
	public       TaggingByProfile() : base()
		{
			PrimaryKeyPropertyName1 = nameof(TagByProfileId);
			PrimaryKeyPropertyName2 = nameof(        TaskId);
			PrimaryKeyPropertyName3 = "";
			PrimaryKeyPropertyName4 = "";
			PrimaryKeyPropertyName5 = "";
			PrimaryKeyPropertyName6 = "";
			PrimaryKeyPropertyName7 = "";
			PrimaryKeyPropertyName8 = "";
		}

		[PrimaryKey(columnName: "task_id")]
		public Guid TaskId { get; set; }

		[Reference(joinType: ReferenceAttribute.JoinType.Left,
			       model:      typeof(Task  ),
			       columnName: nameof(TaskId),
			       foreignKey: "taggings_by_profiles_task_id_fkey")]
		public Task Task   { get; set; } = default!;

		[PrimaryKey(columnName: "tag_by_profile_id")]
		public Guid         TagByProfileId { get; set; }

		[Reference(joinType: ReferenceAttribute.JoinType.Left,
			       model:      typeof(TagByProfile  ),
			       columnName: nameof(TagByProfileId),
			       foreignKey: "taggings_by_profiles_tag_by_profile_id_fkey")]
		public TagByProfile TagByProfile   { get; set; } = default!;
	}
}
