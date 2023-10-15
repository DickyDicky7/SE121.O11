using     Postgrest.Attributes;
using     WorkScheduleReminder.SharedBusinessLogic.Models.Abstractions___;

namespace WorkScheduleReminder.SharedBusinessLogic.Models.Implementations
{
	[Table("taggings_by_profiles")]
	public class TaggingByProfile : CustomBaseModelTableJ
	{
	public       TaggingByProfile() : base()
		{
			PrimaryKeyPropertyName1 = nameof(ProfileId);
			PrimaryKeyPropertyName2 = nameof(   TaskId);
			PrimaryKeyPropertyName3 = nameof(Name);
			PrimaryKeyPropertyName4 = "";
			PrimaryKeyPropertyName5 = "";
			PrimaryKeyPropertyName6 = "";
			PrimaryKeyPropertyName7 = "";
			PrimaryKeyPropertyName8 = "";
		}

		[PrimaryKey(columnName: "task_id")]
		public Guid TaskId { get; set; }

		[Reference(joinType: ReferenceAttribute.JoinType.Left,
			       model:            typeof(Task  ),
			       columnName:       nameof(TaskId),
			       foreignKey: "taggings_by_profiles_task_id_fkey")]
		public Task Task   { get; set; } = null!;

		[PrimaryKey(columnName: "name")]
		public string Name     { get; set; } = null!;

		[Column    (columnName: "settings")]
		public string Settings { get; set; } = null!;

		[PrimaryKey(columnName: "profile_id")]
		public Guid    ProfileId { get; set; }

		[Reference(joinType: ReferenceAttribute.JoinType.Left,
			       model:            typeof(Profile  ),
			       columnName:       nameof(ProfileId),
			       foreignKey: "taggings_by_profiles_profile_id_fkey")]
		public Profile Profile   { get; set; } = null!;
	}
}
