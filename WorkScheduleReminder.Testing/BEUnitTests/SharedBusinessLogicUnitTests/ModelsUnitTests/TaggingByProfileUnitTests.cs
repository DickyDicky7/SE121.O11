﻿using System;
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
	public class TaggingByProfileUnitTests
	{
		[Test]
		[Parallelizable]
		public void GetPrimaryKeyPropertyName1_MustReturnNameOfTagByProfileId()
		{
			/* --- ARRANGE --- */
			var taggingByProfile = new TaggingByProfile();

			/* --- ACT --- */
			var primaryKeyPropertyName1 = taggingByProfile.PrimaryKeyPropertyName1; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(primaryKeyPropertyName1, Is.EqualTo(nameof(taggingByProfile.TagByProfileId)));
		}

		[Test]
		[Parallelizable]
		public void GetPrimaryKeyPropertyName2_MustReturnNameOfTaskId()
		{
			/* --- ARRANGE --- */
			var taggingByProfile = new TaggingByProfile();

			/* --- ACT --- */
			var primaryKeyPropertyName2 = taggingByProfile.PrimaryKeyPropertyName2; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(primaryKeyPropertyName2, Is.EqualTo(nameof(taggingByProfile.TaskId)));
		}

		[Test]
		[Parallelizable]
		public void GetPrimaryKeyPropertyName3_MustReturnEmptyString()
		{
			/* --- ARRANGE --- */
			var taggingByProfile = new TaggingByProfile();

			/* --- ACT --- */
			var primaryKeyPropertyName3 = taggingByProfile.PrimaryKeyPropertyName3; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(primaryKeyPropertyName3, Is.Empty);
		}

		[Test]
		[Parallelizable]
		public void GetPrimaryKeyPropertyName4_MustReturnEmptyString()
		{
			/* --- ARRANGE --- */
			var taggingByProfile = new TaggingByProfile();

			/* --- ACT --- */
			var primaryKeyPropertyName4 = taggingByProfile.PrimaryKeyPropertyName4; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(primaryKeyPropertyName4, Is.Empty);
		}

		[Test]
		[Parallelizable]
		public void GetPrimaryKeyPropertyName5_MustReturnEmptyString()
		{
			/* --- ARRANGE --- */
			var taggingByProfile = new TaggingByProfile();

			/* --- ACT --- */
			var primaryKeyPropertyName5 = taggingByProfile.PrimaryKeyPropertyName5; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(primaryKeyPropertyName5, Is.Empty);
		}

		[Test]
		[Parallelizable]
		public void GetPrimaryKeyPropertyName6_MustReturnEmptyString()
		{
			/* --- ARRANGE --- */
			var taggingByProfile = new TaggingByProfile();

			/* --- ACT --- */
			var primaryKeyPropertyName6 = taggingByProfile.PrimaryKeyPropertyName6; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(primaryKeyPropertyName6, Is.Empty);
		}

		[Test]
		[Parallelizable]
		public void GetPrimaryKeyPropertyName7_MustReturnEmptyString()
		{
			/* --- ARRANGE --- */
			var taggingByProfile = new TaggingByProfile();

			/* --- ACT --- */
			var primaryKeyPropertyName7 = taggingByProfile.PrimaryKeyPropertyName7; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(primaryKeyPropertyName7, Is.Empty);
		}

		[Test]
		[Parallelizable]
		public void GetPrimaryKeyPropertyName8_MustReturnEmptyString()
		{
			/* --- ARRANGE --- */
			var taggingByProfile = new TaggingByProfile();

			/* --- ACT --- */
			var primaryKeyPropertyName8 = taggingByProfile.PrimaryKeyPropertyName8; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(primaryKeyPropertyName8, Is.Empty);
		}

		[Test]
		[Parallelizable]
		public void GetTaskId_MustReturnEmptyGuid()
		{
			/* --- ARRANGE --- */
			var taggingByProfile = new TaggingByProfile();

			/* --- ACT --- */
			var taskId = taggingByProfile.TaskId; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(taskId, Is.EqualTo(Guid.Empty));
		}

		[Test]
		[Parallelizable]
		public void GetTagByProfileId_MustReturnEmptyGuid()
		{
			/* --- ARRANGE --- */
			var taggingByProfile = new TaggingByProfile();

			/* --- ACT --- */
			var tagByProfileId = taggingByProfile.TagByProfileId; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(tagByProfileId, Is.EqualTo(Guid.Empty));
		}

		[Test]
		[Parallelizable]
		public void GetTask_MustReturnNull()
		{
			/* --- ARRANGE --- */
			var taggingByProfile = new TaggingByProfile();

			/* --- ACT --- */
			var task = taggingByProfile.Task; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(task, Is.Null);
		}

		[Test]
		[Parallelizable]
		public void GetTagByProfile_MustReturnNull()
		{
			/* --- ARRANGE --- */
			var taggingByProfile = new TaggingByProfile();

			/* --- ACT --- */
			var tagByProfile = taggingByProfile.TagByProfile; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(tagByProfile, Is.Null);
		}
	}
}
