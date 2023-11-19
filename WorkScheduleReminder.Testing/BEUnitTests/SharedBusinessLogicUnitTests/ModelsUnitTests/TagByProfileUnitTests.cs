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
	internal class TagByProfileUnitTests
	{
		[Test]
		[Parallelizable]
		public void GetName_MustReturnNull()
		{
			/* --- ARRANGE --- */
			var tagByProfile = new TagByProfile();

			/* --- ACT --- */
			var name = tagByProfile.Name; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(name, Is.Null);
		}

		[Test]
		[Parallelizable]
		public void GetSettings_MustReturnNull()
		{
			/* --- ARRANGE --- */
			var tagByProfile = new TagByProfile();

			/* --- ACT --- */
			var settings = tagByProfile.Settings; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(settings, Is.Null);
		}

		[Test]
		[Parallelizable]
		public void GetProfileId_MustReturnEmptyGuid()
		{
			/* --- ARRANGE --- */
			var tagByProfile = new TagByProfile();

			/* --- ACT --- */
			var profileId = tagByProfile.ProfileId; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(profileId, Is.EqualTo(Guid.Empty));
		}

		[Test]
		[Parallelizable]
		public void GetProfile_MustReturnNull()
		{
			/* --- ARRANGE --- */
			var tagByProfile = new TagByProfile();

			/* --- ACT --- */
			var profile = tagByProfile.Profile; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(profile, Is.Null);
		}
	}
}
