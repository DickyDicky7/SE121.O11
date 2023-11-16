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
		public void GetUserName_MustBeNull()
		{
			var profile = new Profile();

			Assert.That(profile.UserName, Is.Null);
		}

		[Test]
		public void GetFullName_MustBeNull()
		{
			var profile = new Profile();

			Assert.That(profile.FullName, Is.Null);
		}

		[Test]
		public void GetWebsite_MustBeNull()
		{
			var profile = new Profile();

			Assert.That(profile.Website, Is.Null);
		}

		[Test]
		public void GetAvatar_MustBeNull()
		{
			var profile = new Profile();

			Assert.That(profile.AvatarURL, Is.Null);
		}
	}
}
