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

		[Column(columnName: "email")]
		public string Email     { get; set; } = default!;

		[Column(columnName: "username")]
		public string UserName  { get; set; } = default!;

		[Column(columnName: "fullname")]
		public string FullName  { get; set; } = default!;

		[Column(columnName: "avatar_url")]
		public string AvatarURL { get; set; } = default!;
	}
}
