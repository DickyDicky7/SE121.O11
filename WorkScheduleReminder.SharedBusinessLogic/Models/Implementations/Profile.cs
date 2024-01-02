using     Postgrest.Attributes;
using     WorkScheduleReminder.SharedBusinessLogic.Models.Abstractions___;

namespace WorkScheduleReminder.SharedBusinessLogic.Models.Implementations
{
	[Table("profiles")]
	public class Profile : CustomBaseModelTableN, IProfile
	{
	public       Profile() : base()
		{
		}

		[Column(columnName: "email",
		        ignoreOnInsert: false,
		        ignoreOnUpdate: false)]
		public string Email     { get; set; } = default!;

		[Column(columnName: "username",
		        ignoreOnInsert: false,
		        ignoreOnUpdate: false)]
		public string UserName  { get; set; } = default!;

		[Column(columnName: "fullname",
		        ignoreOnInsert: false,
		        ignoreOnUpdate: false)]
		public string FullName  { get; set; } = default!;

		[Column(columnName: "avatar_url",
		        ignoreOnInsert: false,
		        ignoreOnUpdate: false)]
		public string AvatarURL { get; set; } = default!;

		[Column(columnName: "my_day_tasks",
		        ignoreOnInsert: false,
		        ignoreOnUpdate: false)]
		public string MyDayTasks{ get; set; } = default!;

		[Column(columnName: "personal_settings",
		        ignoreOnInsert: false,
		        ignoreOnUpdate: false)]
        public string PersonalSettings { get; set; } = default!;
    }
}
