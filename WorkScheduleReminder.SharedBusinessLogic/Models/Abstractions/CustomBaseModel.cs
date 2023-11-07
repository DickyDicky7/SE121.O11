using     Postgrest.Models;
using     Postgrest.Attributes;

namespace WorkScheduleReminder.SharedBusinessLogic.Models.Abstractions___
{
	public abstract class CustomBaseModel : BaseModel
	{
	public                CustomBaseModel() : base() 
		{
		}

		[Column(columnName: "created_timestamp")]
		public DateTimeOffset CreatedTimeStamp { get; set; }

		[Column(columnName: "updated_timestamp")]
		public DateTimeOffset UpdatedTimeStamp { get; set; }

		public abstract override int GetHashCode();

		public abstract override bool Equals(object? obj);

		public static bool operator ==(CustomBaseModel? cbm1, CustomBaseModel? cbm2)
		{
			if (cbm1 is null
			&&  cbm2 is null) return  true;
			if (cbm1 is null) return !true;
			return
			    cbm1.Equals(
			    cbm2);
		}

		public static bool operator !=(CustomBaseModel? cbm1, CustomBaseModel? cbm2)
		{
			return !(cbm1 == cbm2);
		}
	}
}
