using     Postgrest.Attributes;

namespace WorkScheduleReminder.SharedBusinessLogic.Models.Abstractions___
{
	public abstract class CustomBaseModelTableN : CustomBaseModel
	{
	public                CustomBaseModelTableN() : base()
		{
		}

		[PrimaryKey(columnName: "id")]
		public Guid Id { get; set; }

		public override int GetHashCode()
		{
			return HashCode.Combine(Id);
		}

		public override bool Equals(object? obj)
		{
			return obj is CustomBaseModelTableN customBaseModelTableN && Id == customBaseModelTableN.Id;
		}
	}
}
