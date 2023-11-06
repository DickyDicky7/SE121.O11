using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkScheduleReminder.SharedBusinessLogic.Models.Abstractions___;

namespace WorkScheduleReminder.Testing.BEUnitTests.SharedBusinessLogicUnitTests.ModelsUnitTests
{
	[TestFixture]
	[Parallelizable]
	[FixtureLifeCycle(LifeCycle.SingleInstance)]
	public class CustomBaseModelTableNUnitTests
	{
		public class MockCustomBaseModelTableN : CustomBaseModelTableN
		{
			public MockCustomBaseModelTableN() : base()
			{
			}
		}

		[Test]
		[Parallelizable]
		public void GetHashCode_MustReturnHashCodeCombinedFromId()
		{
			/* --- ARRANGE --- */
			var mockCustomBaseModelTableN = new MockCustomBaseModelTableN()
			{
				Id = Guid.NewGuid(),
			};

			/* --- ACT --- */
			var hashCode = mockCustomBaseModelTableN.GetHashCode(); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(hashCode, Is.EqualTo(HashCode.Combine(mockCustomBaseModelTableN.Id)));
		}

		[Test]
		[Parallelizable]
		public void Equals_MustReturnTrueIfCompareBetweenTheTwoSameCustomBaseModelTableN()
		{
			/* --- ARRANGE --- */
			var guid = Guid.NewGuid();
			var mockCustomBaseModelTableN1 = new MockCustomBaseModelTableN()
			{
				Id = guid,
			};
			var mockCustomBaseModelTableN2 = new MockCustomBaseModelTableN()
			{
				Id = guid,
			};

			/* --- ACT --- */
			var result = mockCustomBaseModelTableN1.Equals(mockCustomBaseModelTableN2); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(result, Is.True);
		}

		[Test]
		[Parallelizable]
		public void Equals_MustReturnFalseIfCompareBetweenTheTwoDifferentCustomBaseModelTableN()
		{
			/* --- ARRANGE --- */
			var mockCustomBaseModelTableN1 = new MockCustomBaseModelTableN()
			{
				Id = Guid.NewGuid(),
			};
			var mockCustomBaseModelTableN2 = new MockCustomBaseModelTableN()
			{
				Id = Guid.NewGuid(),
			};

			/* --- ACT --- */
			var result = mockCustomBaseModelTableN1.Equals(mockCustomBaseModelTableN2); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(result, Is.False);
		}

		[Test]
		[Parallelizable]
		public void Equals_MustReturnFalseIfCompareBetweenCustomBaseModelTableNAndNull()
		{
			/* --- ARRANGE --- */
			var mockCustomBaseModelTableN = new MockCustomBaseModelTableN()
			{
				Id = Guid.NewGuid(),
			};

			/* --- ACT --- */
			var result = mockCustomBaseModelTableN.Equals(null); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(result, Is.False);
		}

		[Test]
		[Parallelizable]
		public void Equals_MustReturnFalseIfCompareBetweenCustomBaseModelTableNAndObjectThatIsNotCustomBaseModelTableN()
		{
			/* --- ARRANGE --- */
			var mockCustomBaseModelTableN = new MockCustomBaseModelTableN()
			{
				Id = Guid.NewGuid(),
			};

			/* --- ACT --- */
			var result = mockCustomBaseModelTableN.Equals("object that is not custom base model table N"); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(result, Is.False);
		}
	}
}
