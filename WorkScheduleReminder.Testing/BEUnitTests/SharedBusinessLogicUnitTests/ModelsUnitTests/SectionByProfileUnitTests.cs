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
	public class SectionByProfileUnitTests
	{
		[Test]
		[Parallelizable]
		public void GetName_MustReturnNull()
		{
			/* --- ARRANGE --- */
			var sectionByProfile = new SectionByProfile();

			/* --- ACT --- */
			var name = sectionByProfile.Name; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(name, Is.Null);
		}

		[Test]
		[Parallelizable]
		public void GetSettings_MustReturnNull()
		{
			/* --- ARRANGE --- */
			var sectionByProfile = new SectionByProfile();

			/* --- ACT --- */
			var settings = sectionByProfile.Settings; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(settings, Is.Null);
		}

		[Test]
		[Parallelizable]
		public void GetProfileId_MustReturnEmptyGuid()
		{
			/* --- ARRANGE --- */
			var sectionByProfile = new SectionByProfile();

			/* --- ACT --- */
			var profileId = sectionByProfile.ProfileId; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(profileId, Is.EqualTo(Guid.Empty));
		}

		[Test]
		[Parallelizable]
		public void GetProfile_MustReturnNull()
		{
			/* --- ARRANGE --- */
			var sectionByProfile = new SectionByProfile();

			/* --- ACT --- */
			var profile = sectionByProfile.Profile; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(profile, Is.Null);
		}
	}
}
