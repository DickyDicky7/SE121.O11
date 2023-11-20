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
	public class ProfileUnitTests
	{
		[Test]
		[Parallelizable]
		public void GetUserName_MustReturnNull()
		{
			var profile = new Profile();

			Assert.That(profile.UserName, Is.Null);
		}

		[Test]
		[Parallelizable]
		public void GetFullName_MustReturnNull()
		{
			var profile = new Profile();

			Assert.That(profile.FullName, Is.Null);
		}

		[Test]
		[Parallelizable]
		public void GetEmail_MustReturnNull()
		{
			var profile = new Profile();

			Assert.That(profile.Email, Is.Null);
		}

		[Test]
		[Parallelizable]
		public void GetAvatar_MustReturnNull()
		{
			var profile = new Profile();

			Assert.That(profile.AvatarURL, Is.Null);
		}
	}
}
