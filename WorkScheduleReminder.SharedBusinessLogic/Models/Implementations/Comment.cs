using     Postgrest.Attributes;
using     WorkScheduleReminder.SharedBusinessLogic.Models.Abstractions___;

namespace WorkScheduleReminder.SharedBusinessLogic.Models.Implementations
{
	[Table("comments")]
	public class Comment : CustomBaseModelTableN, IComment
	{
	public       Comment() : base() 
		{
		}

		[Column(columnName:    "task_id")]
		public Guid    TaskId { get; set; }

		[Column(columnName: "profile_id")]
		public Guid ProfileId { get; set; }

		[Reference(joinType: ReferenceAttribute.JoinType.Left,
                   model:         typeof(Task  ),
                   columnName:    nameof(TaskId),
                   foreignKey: "comments_task_id_fkey")]
		public    Task    Task { get; set; } = default!;

		[Reference(joinType: ReferenceAttribute.JoinType.Left,
                   model:         typeof(Profile  ),
                   columnName:    nameof(ProfileId),
                   foreignKey: "comments_profile_id_fkey")]
		public Profile Profile { get; set; } = default!;

		[Column(columnName: "message")]
		public string  Message { get; set; } = default!;

		[Column(columnName: "comment_id")]
		public Guid? CommentId { get; set; }

		[Reference(joinType: ReferenceAttribute.JoinType.Left,
                   model:    typeof(Comment  ),
                   foreignKey:     "comments")]
		public List<Comment> Replies { get; set; } = default!;
	}
}
