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
	public class TaggingByGroupUnitTests
	{
		[Test]
		[Parallelizable]
		public void PrimaryKeyPropertyName3_MustBeEmptyString()
		{
			/* --- ARRANGE --- */
			var taggingByGroup = new TaggingByGroup();

			/* --- ACT --- */
			var primaryKeyPropertyName3 = taggingByGroup.PrimaryKeyPropertyName3; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(primaryKeyPropertyName3, Is.Empty);
		}

		[Test]
		[Parallelizable]
		public void PrimaryKeyPropertyName4_MustBeEmptyString()
		{
			/* --- ARRANGE --- */
			var taggingByGroup = new TaggingByGroup();

			/* --- ACT --- */
			var primaryKeyPropertyName4 = taggingByGroup.PrimaryKeyPropertyName4; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(primaryKeyPropertyName4, Is.Empty);
		}

		[Test]
		[Parallelizable]
		public void PrimaryKeyPropertyName5_MustBeEmptyString()
		{
			/* --- ARRANGE --- */
			var taggingByGroup = new TaggingByGroup();

			/* --- ACT --- */
			var primaryKeyPropertyName5 = taggingByGroup.PrimaryKeyPropertyName5; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(primaryKeyPropertyName5, Is.Empty);
		}

		[Test]
		[Parallelizable]
		public void PrimaryKeyPropertyName6_MustBeEmptyString()
		{
			/* --- ARRANGE --- */
			var taggingByGroup = new TaggingByGroup();

			/* --- ACT --- */
			var primaryKeyPropertyName6 = taggingByGroup.PrimaryKeyPropertyName6; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(primaryKeyPropertyName6, Is.Empty);
		}

		[Test]
		[Parallelizable]
		public void PrimaryKeyPropertyName7_MustBeEmptyString()
		{
			/* --- ARRANGE --- */
			var taggingByGroup = new TaggingByGroup();

			/* --- ACT --- */
			var primaryKeyPropertyName7 = taggingByGroup.PrimaryKeyPropertyName7; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(primaryKeyPropertyName7, Is.Empty);
		}

		[Test]
		[Parallelizable]
		public void PrimaryKeyPropertyName8_MustBeEmptyString()
		{
			/* --- ARRANGE --- */
			var taggingByGroup = new TaggingByGroup();

			/* --- ACT --- */
			var primaryKeyPropertyName8 = taggingByGroup.PrimaryKeyPropertyName8; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(primaryKeyPropertyName8, Is.Empty);
		}
	}
}
