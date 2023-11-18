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

		[Column(columnName: "username")]
		public string? UserName  { get; set; }

		[Column(columnName: "fullname")]
		public string? FullName  { get; set; }

		[Column(columnName: "website" )]
		public string? Website   { get; set; }

		[Column(columnName: "avatar_url")]
		public string? AvatarURL { get; set; }
	}
}
