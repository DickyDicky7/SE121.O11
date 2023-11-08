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
	public class MemberUnitTests
	{
		[Test]
		[Parallelizable]
		public void PrimaryKeyPropertyName1_MustBeNameOfGroupId()
		{
			/* --- ARRANGE --- */
			var member = new Member();

			/* --- ACT --- */
			var primaryKeyPropertyName1 = member.PrimaryKeyPropertyName1; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(primaryKeyPropertyName1, Is.EqualTo(nameof(member.GroupId)));
		}

		[Test]
		[Parallelizable]
		public void PrimaryKeyPropertyName2_MustBeNameOfProfileId()
		{
			/* --- ARRANGE --- */
			var member = new Member();

			/* --- ACT --- */
			var primaryKeyPropertyName2 = member.PrimaryKeyPropertyName2; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(primaryKeyPropertyName2, Is.EqualTo(nameof(member.ProfileId)));
		}

		[Test]
		[Parallelizable]
		public void PrimaryKeyPropertyName3_MustBeEmptyString()
		{
			/* --- ARRANGE --- */
			var member = new Member();

			/* --- ACT --- */
			var primaryKeyPropertyName3 = member.PrimaryKeyPropertyName3; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(primaryKeyPropertyName3, Is.Empty);
		}

		[Test]
		[Parallelizable]
		public void PrimaryKeyPropertyName4_MustBeEmptyString()
		{
			/* --- ARRANGE --- */
			var member = new Member();

			/* --- ACT --- */
			var primaryKeyPropertyName4 = member.PrimaryKeyPropertyName4; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(primaryKeyPropertyName4, Is.Empty);
		}

		[Test]
		[Parallelizable]
		public void PrimaryKeyPropertyName5_MustBeEmptyString()
		{
			/* --- ARRANGE --- */
			var member = new Member();

			/* --- ACT --- */
			var primaryKeyPropertyName5 = member.PrimaryKeyPropertyName5; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(primaryKeyPropertyName5, Is.Empty);
		}

		[Test]
		[Parallelizable]
		public void PrimaryKeyPropertyName6_MustBeEmptyString()
		{
			/* --- ARRANGE --- */
			var member = new Member();

			/* --- ACT --- */
			var primaryKeyPropertyName6 = member.PrimaryKeyPropertyName6; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(primaryKeyPropertyName6, Is.Empty);
		}

		[Test]
		[Parallelizable]
		public void PrimaryKeyPropertyName7_MustBeEmptyString()
		{
			/* --- ARRANGE --- */
			var member = new Member();

			/* --- ACT --- */
			var primaryKeyPropertyName7 = member.PrimaryKeyPropertyName7; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(primaryKeyPropertyName7, Is.Empty);
		}

		[Test]
		[Parallelizable]
		public void PrimaryKeyPropertyName8_MustBeEmptyString()
		{
			/* --- ARRANGE --- */
			var member = new Member();

			/* --- ACT --- */
			var primaryKeyPropertyName8 = member.PrimaryKeyPropertyName8; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(primaryKeyPropertyName8, Is.Empty);
		}
	}
}
