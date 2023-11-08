

namespace WorkScheduleReminder.SharedBusinessLogic.Models.Abstractions___
{
	public abstract class CustomBaseModelTableJ : CustomBaseModel
	{
	public                CustomBaseModelTableJ() : base()
		{
			PrimaryKeyPropertyName1 = string.Empty;
			PrimaryKeyPropertyName2 = string.Empty;
			PrimaryKeyPropertyName3 = string.Empty;
			PrimaryKeyPropertyName4 = string.Empty;
			PrimaryKeyPropertyName5 = string.Empty;
			PrimaryKeyPropertyName6 = string.Empty;
			PrimaryKeyPropertyName7 = string.Empty;
			PrimaryKeyPropertyName8 = string.Empty;
		}

		public string PrimaryKeyPropertyName1 { get; protected set; }
		public string PrimaryKeyPropertyName2 { get; protected set; }
		public string PrimaryKeyPropertyName3 { get; protected set; }
		public string PrimaryKeyPropertyName4 { get; protected set; }
		public string PrimaryKeyPropertyName5 { get; protected set; }
		public string PrimaryKeyPropertyName6 { get; protected set; }
		public string PrimaryKeyPropertyName7 { get; protected set; }
		public string PrimaryKeyPropertyName8 { get; protected set; }

		public object? PrimaryKeyProperty1 => this.GetType().GetProperty(PrimaryKeyPropertyName1)?.GetValue(this);
		public object? PrimaryKeyProperty2 => this.GetType().GetProperty(PrimaryKeyPropertyName2)?.GetValue(this);
		public object? PrimaryKeyProperty3 => this.GetType().GetProperty(PrimaryKeyPropertyName3)?.GetValue(this);
		public object? PrimaryKeyProperty4 => this.GetType().GetProperty(PrimaryKeyPropertyName4)?.GetValue(this);
		public object? PrimaryKeyProperty5 => this.GetType().GetProperty(PrimaryKeyPropertyName5)?.GetValue(this);
		public object? PrimaryKeyProperty6 => this.GetType().GetProperty(PrimaryKeyPropertyName6)?.GetValue(this);
		public object? PrimaryKeyProperty7 => this.GetType().GetProperty(PrimaryKeyPropertyName7)?.GetValue(this);
		public object? PrimaryKeyProperty8 => this.GetType().GetProperty(PrimaryKeyPropertyName8)?.GetValue(this);

		public override int GetHashCode()
		{
			return HashCode.Combine
			(
				PrimaryKeyProperty1,
				PrimaryKeyProperty2,
				PrimaryKeyProperty3,
				PrimaryKeyProperty4,
				PrimaryKeyProperty5,
				PrimaryKeyProperty6,
				PrimaryKeyProperty7,
				PrimaryKeyProperty8
			);
		}

		public override bool Equals(object? obj)
		{
			return obj is CustomBaseModelTableJ       customBaseModelTableJ
				&& Object.Equals(PrimaryKeyProperty1, customBaseModelTableJ.PrimaryKeyProperty1)
				&& Object.Equals(PrimaryKeyProperty2, customBaseModelTableJ.PrimaryKeyProperty2)
				&& Object.Equals(PrimaryKeyProperty3, customBaseModelTableJ.PrimaryKeyProperty3)
				&& Object.Equals(PrimaryKeyProperty4, customBaseModelTableJ.PrimaryKeyProperty4)
				&& Object.Equals(PrimaryKeyProperty5, customBaseModelTableJ.PrimaryKeyProperty5)
				&& Object.Equals(PrimaryKeyProperty6, customBaseModelTableJ.PrimaryKeyProperty6)
				&& Object.Equals(PrimaryKeyProperty7, customBaseModelTableJ.PrimaryKeyProperty7)
				&& Object.Equals(PrimaryKeyProperty8, customBaseModelTableJ.PrimaryKeyProperty8)
				;
		}
	}
}
