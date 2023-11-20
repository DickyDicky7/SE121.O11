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
	public class SectioningByProfileUnitTests
	{
		[Test]
		[Parallelizable]
		public void GetPrimaryKeyPropertyName1_MustReturnNameOfSectionByProfileId()
		{
			/* --- ARRANGE --- */
			var sectioningByProfile = new SectioningByProfile();

			/* --- ACT --- */
			var primaryKeyPropertyName1 = sectioningByProfile.PrimaryKeyPropertyName1; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(primaryKeyPropertyName1, Is.EqualTo(nameof(sectioningByProfile.SectionByProfileId)));
		}

		[Test]
		[Parallelizable]
		public void GetPrimaryKeyPropertyName2_MustReturnNameOfTaskId()
		{
			/* --- ARRANGE --- */
			var sectioningByProfile = new SectioningByProfile();

			/* --- ACT --- */
			var primaryKeyPropertyName2 = sectioningByProfile.PrimaryKeyPropertyName2; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(primaryKeyPropertyName2, Is.EqualTo(nameof(sectioningByProfile.TaskId)));
		}

		[Test]
		[Parallelizable]
		public void GetPrimaryKeyPropertyName3_MustReturnEmptyString()
		{
			/* --- ARRANGE --- */
			var sectioningByProfile = new SectioningByProfile();

			/* --- ACT --- */
			var primaryKeyPropertyName3 = sectioningByProfile.PrimaryKeyPropertyName3; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(primaryKeyPropertyName3, Is.Empty);
		}

		[Test]
		[Parallelizable]
		public void GetPrimaryKeyPropertyName4_MustReturnEmptyString()
		{
			/* --- ARRANGE --- */
			var sectioningByProfile = new SectioningByProfile();

			/* --- ACT --- */
			var primaryKeyPropertyName4 = sectioningByProfile.PrimaryKeyPropertyName4; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(primaryKeyPropertyName4, Is.Empty);
		}

		[Test]
		[Parallelizable]
		public void GetPrimaryKeyPropertyName5_MustReturnEmptyString()
		{
			/* --- ARRANGE --- */
			var sectioningByProfile = new SectioningByProfile();

			/* --- ACT --- */
			var primaryKeyPropertyName5 = sectioningByProfile.PrimaryKeyPropertyName5; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(primaryKeyPropertyName5, Is.Empty);
		}

		[Test]
		[Parallelizable]
		public void GetPrimaryKeyPropertyName6_MustReturnEmptyString()
		{
			/* --- ARRANGE --- */
			var sectioningByProfile = new SectioningByProfile();

			/* --- ACT --- */
			var primaryKeyPropertyName6 = sectioningByProfile.PrimaryKeyPropertyName6; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(primaryKeyPropertyName6, Is.Empty);
		}

		[Test]
		[Parallelizable]
		public void GetPrimaryKeyPropertyName7_MustReturnEmptyString()
		{
			/* --- ARRANGE --- */
			var sectioningByProfile = new SectioningByProfile();

			/* --- ACT --- */
			var primaryKeyPropertyName7 = sectioningByProfile.PrimaryKeyPropertyName7; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(primaryKeyPropertyName7, Is.Empty);
		}

		[Test]
		[Parallelizable]
		public void GetPrimaryKeyPropertyName8_MustReturnEmptyString()
		{
			/* --- ARRANGE --- */
			var sectioningByProfile = new SectioningByProfile();

			/* --- ACT --- */
			var primaryKeyPropertyName8 = sectioningByProfile.PrimaryKeyPropertyName8; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(primaryKeyPropertyName8, Is.Empty);
		}

		[Test]
		[Parallelizable]
		public void GetTaskId_MustReturnEmptyGuid()
		{
			/* --- ARRANGE --- */
			var sectioningByProfile = new SectioningByProfile();

			/* --- ACT --- */
			var taskId = sectioningByProfile.TaskId; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(taskId, Is.EqualTo(Guid.Empty));
		}

		[Test]
		[Parallelizable]
		public void GetSectionByProfileId_MustReturnEmptyGuid()
		{
			/* --- ARRANGE --- */
			var sectioningByProfile = new SectioningByProfile();

			/* --- ACT --- */
			var sectionByProfileId = sectioningByProfile.SectionByProfileId; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(sectionByProfileId, Is.EqualTo(Guid.Empty));
		}

		[Test]
		[Parallelizable]
		public void GetTask_MustReturnNull()
		{
			/* --- ARRANGE --- */
			var sectioningByProfile = new SectioningByProfile();

			/* --- ACT --- */
			var task = sectioningByProfile.Task; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(task, Is.Null);
		}

		[Test]
		[Parallelizable]
		public void GetSectionByProfile_MustReturnNull()
		{
			/* --- ARRANGE --- */
			var sectioningByProfile = new SectioningByProfile();

			/* --- ACT --- */
			var sectionByProfile = sectioningByProfile.SectionByProfile; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(sectionByProfile, Is.Null);
		}
	}
}
