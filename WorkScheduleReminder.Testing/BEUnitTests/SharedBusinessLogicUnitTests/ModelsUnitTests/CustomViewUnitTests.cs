using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkScheduleReminder.SharedBusinessLogic.Models.Implementations;

namespace WorkScheduleReminder.Testing.BEUnitTests.SharedBusinessLogicUnitTests.ModelsUnitTests
{
	[TestFixture]
	[Parallelizable]
	[FixtureLifeCycle(LifeCycle.SingleInstance)]
	public class CustomViewUnitTests
	{
		[Test]
		public void GetName_MustReturnNull()
		{
			var customView = new CustomView();
			Assert.That(customView.Name, Is.Null);
		}

		[Test]
		public void GetBoardId_MustReturnEmptyGuid()
		{
			var customView = new CustomView();
			Assert.That(customView.BoardId, Is.EqualTo(Guid.Empty));
		}

		[Test]
		public void GetProfileId_MustReturnEmptyGuid()
		{
			var customView = new CustomView();
			Assert.That(customView.ProfileId, Is.EqualTo(Guid.Empty));
		}

		[Test]
		public void GetBoard_MustReturnNull()
		{
			var customView = new CustomView();
			Assert.That(customView.Board, Is.Null);
		}

		[Test]
		public void GetProfile_MustReturnNull()
		{
			var customView = new CustomView();
			Assert.That(customView.Profile, Is.Null);
		}

		[Test]
		public void GetRealType_MustReturnNull()
		{
			var customView = new CustomView();
			Assert.That(customView.RealType, Is.Null);
		}

		[Test]
		public void GetSettings_MustReturnNull()
		{
			var customView = new CustomView();
			Assert.That(customView.Settings, Is.Null);
		}

		[Test]
		public void GetType_MustThrowArgumentNullException()
		{
			var customView = new CustomView();
			Assert.Throws<ArgumentNullException>(() => { CustomView.PossibleType type = customView.Type; });
		}

		[Test]
		public void SetType_MustReturnRealTypeWithValueToString()
		{
			var customView = new CustomView();
			customView.Type = CustomView.PossibleType.DueDay;
			Assert.That(customView.RealType, Is.EqualTo(CustomView.PossibleType.DueDay.ToString()));
		}
	}
}
