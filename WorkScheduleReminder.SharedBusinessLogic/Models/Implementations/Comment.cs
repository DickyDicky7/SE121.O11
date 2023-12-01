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

		[Column(columnName:    "task_id",
		        ignoreOnInsert: false,
		        ignoreOnUpdate: false)]
		public Guid    TaskId { get; set; }

		[Column(columnName: "profile_id",
		        ignoreOnInsert: false,
		        ignoreOnUpdate: false)]
		public Guid ProfileId { get; set; }

		[Reference(joinType: ReferenceAttribute.JoinType.Left,
                   model:      typeof(Task  ),
                   columnName: nameof(TaskId),
                   foreignKey: "comments_task____id_fkey",
		           includeInQuery: true,
		           ignoreOnInsert: true,
		           ignoreOnUpdate: true)]
		public    Task    Task { get; set; } = default!;

		[Reference(joinType: ReferenceAttribute.JoinType.Left,
                   model:      typeof(Profile  ),
                   columnName: nameof(ProfileId),
                   foreignKey: "comments_profile_id_fkey",
		           includeInQuery: true,
		           ignoreOnInsert: true,
		           ignoreOnUpdate: true)]
		public Profile Profile { get; set; } = default!;

		[Column(columnName: "message",
		        ignoreOnInsert: false,
		        ignoreOnUpdate: false)]
		public string  Message { get; set; } = default!;

		[Column(columnName: "comment_id",
		        ignoreOnInsert: false,
		        ignoreOnUpdate: false)]
		public Guid? CommentId { get; set; }

		[Reference(joinType: ReferenceAttribute.JoinType.Left,
                   model:    typeof(Comment  ),
                   foreignKey:     "comments" ,
		           includeInQuery: true,
		           ignoreOnInsert: true,
		           ignoreOnUpdate: true)]
		public List<Comment> Replies { get; set; } = default!;
	}
}
