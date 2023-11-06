using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkScheduleReminder.SharedBusinessLogic.Models.Abstractions___;

namespace WorkScheduleReminder.Testing.BEUnitTests.SharedBusinessLogicUnitTests.ModelsUnitTests
{
	public class MockModelWith00PrimaryKeys : CustomBaseModelTableJ
	{
		public MockModelWith00PrimaryKeys() : base()
		{
		}
	}

	public class MockModelWith01PrimaryKeys : CustomBaseModelTableJ
	{
		public MockModelWith01PrimaryKeys() : base()
		{
			PrimaryKeyPropertyName1 = nameof(PrimaryKeyPropertyName1);
		}
	}

	public class MockModelWith02PrimaryKeys : CustomBaseModelTableJ
	{
		public MockModelWith02PrimaryKeys() : base()
		{
			PrimaryKeyPropertyName1 = nameof(PrimaryKeyPropertyName1);
			PrimaryKeyPropertyName2 = nameof(PrimaryKeyPropertyName2);
		}
	}

	public class MockModelWith03PrimaryKeys : CustomBaseModelTableJ
	{
		public MockModelWith03PrimaryKeys() : base()
		{
			PrimaryKeyPropertyName1 = nameof(PrimaryKeyPropertyName1);
			PrimaryKeyPropertyName2 = nameof(PrimaryKeyPropertyName2);
			PrimaryKeyPropertyName3 = nameof(PrimaryKeyPropertyName3);
		}
	}

	public class MockModelWith04PrimaryKeys : CustomBaseModelTableJ
	{
		public MockModelWith04PrimaryKeys() : base()
		{
			PrimaryKeyPropertyName1 = nameof(PrimaryKeyPropertyName1);
			PrimaryKeyPropertyName2 = nameof(PrimaryKeyPropertyName2);
			PrimaryKeyPropertyName3 = nameof(PrimaryKeyPropertyName3);
			PrimaryKeyPropertyName4 = nameof(PrimaryKeyPropertyName4);
		}
	}

	public class MockModelWith05PrimaryKeys : CustomBaseModelTableJ
	{
		public MockModelWith05PrimaryKeys() : base()
		{
			PrimaryKeyPropertyName1 = nameof(PrimaryKeyPropertyName1);
			PrimaryKeyPropertyName2 = nameof(PrimaryKeyPropertyName2);
			PrimaryKeyPropertyName3 = nameof(PrimaryKeyPropertyName3);
			PrimaryKeyPropertyName4 = nameof(PrimaryKeyPropertyName4);
			PrimaryKeyPropertyName5 = nameof(PrimaryKeyPropertyName5);
		}
	}

	public class MockModelWith06PrimaryKeys : CustomBaseModelTableJ
	{
		public MockModelWith06PrimaryKeys() : base()
		{
			PrimaryKeyPropertyName1 = nameof(PrimaryKeyPropertyName1);
			PrimaryKeyPropertyName2 = nameof(PrimaryKeyPropertyName2);
			PrimaryKeyPropertyName3 = nameof(PrimaryKeyPropertyName3);
			PrimaryKeyPropertyName4 = nameof(PrimaryKeyPropertyName4);
			PrimaryKeyPropertyName5 = nameof(PrimaryKeyPropertyName5);
			PrimaryKeyPropertyName6 = nameof(PrimaryKeyPropertyName6);
		}
	}

	public class MockModelWith07PrimaryKeys : CustomBaseModelTableJ
	{
		public MockModelWith07PrimaryKeys() : base()
		{
			PrimaryKeyPropertyName1 = nameof(PrimaryKeyPropertyName1);
			PrimaryKeyPropertyName2 = nameof(PrimaryKeyPropertyName2);
			PrimaryKeyPropertyName3 = nameof(PrimaryKeyPropertyName3);
			PrimaryKeyPropertyName4 = nameof(PrimaryKeyPropertyName4);
			PrimaryKeyPropertyName5 = nameof(PrimaryKeyPropertyName5);
			PrimaryKeyPropertyName6 = nameof(PrimaryKeyPropertyName6);
			PrimaryKeyPropertyName7 = nameof(PrimaryKeyPropertyName7);
		}
	}

	public class MockModelWith08PrimaryKeys : CustomBaseModelTableJ
	{
		public MockModelWith08PrimaryKeys() : base()
		{
			PrimaryKeyPropertyName1 = nameof(PrimaryKeyPropertyName1);
			PrimaryKeyPropertyName2 = nameof(PrimaryKeyPropertyName2);
			PrimaryKeyPropertyName3 = nameof(PrimaryKeyPropertyName3);
			PrimaryKeyPropertyName4 = nameof(PrimaryKeyPropertyName4);
			PrimaryKeyPropertyName5 = nameof(PrimaryKeyPropertyName5);
			PrimaryKeyPropertyName6 = nameof(PrimaryKeyPropertyName6);
			PrimaryKeyPropertyName7 = nameof(PrimaryKeyPropertyName7);
			PrimaryKeyPropertyName8 = nameof(PrimaryKeyPropertyName8);
		}
	}

	[TestFixture]
	[Parallelizable]
	[FixtureLifeCycle(LifeCycle.SingleInstance)]
	public class CustomBaseModelTableJUnitTests
	{
		[Test]
		[Parallelizable]
		public void GetHashCode_MustReturnHashCodeCombinedOf00PrimaryKeyProperties()
		{
			/* --- ARRANGE --- */
			var cbmtj = new MockModelWith00PrimaryKeys();

			/* --- ACT --- */
			var hashCode = cbmtj.GetHashCode(); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(hashCode, Is.EqualTo(HashCode.Combine<object?, object?, object?, object?, object?, object?, object?, object?>
			(
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null
			)));
		}

		[Test]
		[Parallelizable]
		public void GetHashCode_MustReturnHashCodeCombinedOf01PrimaryKeyProperties()
		{
			/* --- ARRANGE --- */
			var cbmtj = new MockModelWith01PrimaryKeys();

			/* --- ACT --- */
			var hashCode = cbmtj.GetHashCode(); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(hashCode, Is.EqualTo(HashCode.Combine<object?, object?, object?, object?, object?, object?, object?, object?>
			(
				cbmtj.PrimaryKeyProperty1,
				null,
				null,
				null,
				null,
				null,
				null,
				null
			)));
		}

		[Test]
		[Parallelizable]
		public void GetHashCode_MustReturnHashCodeCombinedOf02PrimaryKeyProperties()
		{
			/* --- ARRANGE --- */
			var cbmtj = new MockModelWith02PrimaryKeys();

			/* --- ACT --- */
			var hashCode = cbmtj.GetHashCode(); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(hashCode, Is.EqualTo(HashCode.Combine<object?, object?, object?, object?, object?, object?, object?, object?>
			(
				cbmtj.PrimaryKeyProperty1,
				cbmtj.PrimaryKeyProperty2,
				null,
				null,
				null,
				null,
				null,
				null
			)));
		}

		[Test]
		[Parallelizable]
		public void GetHashCode_MustReturnHashCodeCombinedOf03PrimaryKeyProperties()
		{
			/* --- ARRANGE --- */
			var cbmtj = new MockModelWith03PrimaryKeys();

			/* --- ACT --- */
			var hashCode = cbmtj.GetHashCode(); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(hashCode, Is.EqualTo(HashCode.Combine<object?, object?, object?, object?, object?, object?, object?, object?>
			(
				cbmtj.PrimaryKeyProperty1,
				cbmtj.PrimaryKeyProperty2,
				cbmtj.PrimaryKeyProperty3,
				null,
				null,
				null,
				null,
				null
			)));
		}

		[Test]
		[Parallelizable]
		public void GetHashCode_MustReturnHashCodeCombinedOf04PrimaryKeyProperties()
		{
			/* --- ARRANGE --- */
			var cbmtj = new MockModelWith04PrimaryKeys();

			/* --- ACT --- */
			var hashCode = cbmtj.GetHashCode(); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(hashCode, Is.EqualTo(HashCode.Combine<object?, object?, object?, object?, object?, object?, object?, object?>
			(
				cbmtj.PrimaryKeyProperty1,
				cbmtj.PrimaryKeyProperty2,
				cbmtj.PrimaryKeyProperty3,
				cbmtj.PrimaryKeyProperty4,
				null,
				null,
				null,
				null
			)));
		}

		[Test]
		[Parallelizable]
		public void GetHashCode_MustReturnHashCodeCombinedOf05PrimaryKeyProperties()
		{
			/* --- ARRANGE --- */
			var cbmtj = new MockModelWith05PrimaryKeys();

			/* --- ACT --- */
			var hashCode = cbmtj.GetHashCode(); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(hashCode, Is.EqualTo(HashCode.Combine<object?, object?, object?, object?, object?, object?, object?, object?>
			(
				cbmtj.PrimaryKeyProperty1,
				cbmtj.PrimaryKeyProperty2,
				cbmtj.PrimaryKeyProperty3,
				cbmtj.PrimaryKeyProperty4,
				cbmtj.PrimaryKeyProperty5,
				null,
				null,
				null
			)));
		}

		[Test]
		[Parallelizable]
		public void GetHashCode_MustReturnHashCodeCombinedOf06PrimaryKeyProperties()
		{
			/* --- ARRANGE --- */
			var cbmtj = new MockModelWith06PrimaryKeys();

			/* --- ACT --- */
			var hashCode = cbmtj.GetHashCode(); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(hashCode, Is.EqualTo(HashCode.Combine<object?, object?, object?, object?, object?, object?, object?, object?>
			(
				cbmtj.PrimaryKeyProperty1,
				cbmtj.PrimaryKeyProperty2,
				cbmtj.PrimaryKeyProperty3,
				cbmtj.PrimaryKeyProperty4,
				cbmtj.PrimaryKeyProperty5,
				cbmtj.PrimaryKeyProperty6,
				null,
				null
			)));
		}

		[Test]
		[Parallelizable]
		public void GetHashCode_MustReturnHashCodeCombinedOf07PrimaryKeyProperties()
		{
			/* --- ARRANGE --- */
			var cbmtj = new MockModelWith07PrimaryKeys();

			/* --- ACT --- */
			var hashCode = cbmtj.GetHashCode(); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(hashCode, Is.EqualTo(HashCode.Combine<object?, object?, object?, object?, object?, object?, object?, object?>
			(
				cbmtj.PrimaryKeyProperty1,
				cbmtj.PrimaryKeyProperty2,
				cbmtj.PrimaryKeyProperty3,
				cbmtj.PrimaryKeyProperty4,
				cbmtj.PrimaryKeyProperty5,
				cbmtj.PrimaryKeyProperty6,
				cbmtj.PrimaryKeyProperty7,
				null
			)));
		}

		[Test]
		[Parallelizable]
		public void GetHashCode_MustReturnHashCodeCombinedOf08PrimaryKeyProperties()
		{
			/* --- ARRANGE --- */
			var cbmtj = new MockModelWith08PrimaryKeys();

			/* --- ACT --- */
			var hashCode = cbmtj.GetHashCode(); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(hashCode, Is.EqualTo(HashCode.Combine<object?, object?, object?, object?, object?, object?, object?, object?>
			(
				cbmtj.PrimaryKeyProperty1,
				cbmtj.PrimaryKeyProperty2,
				cbmtj.PrimaryKeyProperty3,
				cbmtj.PrimaryKeyProperty4,
				cbmtj.PrimaryKeyProperty5,
				cbmtj.PrimaryKeyProperty6,
				cbmtj.PrimaryKeyProperty7,
				cbmtj.PrimaryKeyProperty8
			)));
		}

		[Test]
		[Parallelizable]
		public void Equals_MustReturnTrueIfCompareBetweenTheTwoSameModelWith00PrimaryKeys()
		{
			/* --- ARRANGE --- */
			var cbmtj1 = new MockModelWith00PrimaryKeys();
			var cbmtj2 = new MockModelWith00PrimaryKeys();

			/* --- ACT --- */
			var result = cbmtj1.Equals(cbmtj2); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(result, Is.True);
		}

		[Test]
		[Parallelizable]
		public void Equals_MustReturnTrueIfCompareBetweenTheTwoSameModelWith01PrimaryKeys()
		{
			/* --- ARRANGE --- */
			var cbmtj1 = new MockModelWith01PrimaryKeys();
			var cbmtj2 = new MockModelWith01PrimaryKeys();

			/* --- ACT --- */
			var result = cbmtj1.Equals(cbmtj2); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(result, Is.True);
		}

		[Test]
		[Parallelizable]
		public void Equals_MustReturnTrueIfCompareBetweenTheTwoSameModelWith02PrimaryKeys()
		{
			/* --- ARRANGE --- */
			var cbmtj1 = new MockModelWith02PrimaryKeys();
			var cbmtj2 = new MockModelWith02PrimaryKeys();

			/* --- ACT --- */
			var result = cbmtj1.Equals(cbmtj2); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(result, Is.True);
		}

		[Test]
		[Parallelizable]
		public void Equals_MustReturnTrueIfCompareBetweenTheTwoSameModelWith03PrimaryKeys()
		{
			/* --- ARRANGE --- */
			var cbmtj1 = new MockModelWith03PrimaryKeys();
			var cbmtj2 = new MockModelWith03PrimaryKeys();

			/* --- ACT --- */
			var result = cbmtj1.Equals(cbmtj2); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(result, Is.True);
		}

		[Test]
		[Parallelizable]
		public void Equals_MustReturnTrueIfCompareBetweenTheTwoSameModelWith04PrimaryKeys()
		{
			/* --- ARRANGE --- */
			var cbmtj1 = new MockModelWith04PrimaryKeys();
			var cbmtj2 = new MockModelWith04PrimaryKeys();

			/* --- ACT --- */
			var result = cbmtj1.Equals(cbmtj2); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(result, Is.True);
		}

		[Test]
		[Parallelizable]
		public void Equals_MustReturnTrueIfCompareBetweenTheTwoSameModelWith05PrimaryKeys()
		{
			/* --- ARRANGE --- */
			var cbmtj1 = new MockModelWith05PrimaryKeys();
			var cbmtj2 = new MockModelWith05PrimaryKeys();

			/* --- ACT --- */
			var result = cbmtj1.Equals(cbmtj2); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(result, Is.True);
		}

		[Test]
		[Parallelizable]
		public void Equals_MustReturnTrueIfCompareBetweenTheTwoSameModelWith06PrimaryKeys()
		{
			/* --- ARRANGE --- */
			var cbmtj1 = new MockModelWith06PrimaryKeys();
			var cbmtj2 = new MockModelWith06PrimaryKeys();

			/* --- ACT --- */
			var result = cbmtj1.Equals(cbmtj2); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(result, Is.True);
		}

		[Test]
		[Parallelizable]
		public void Equals_MustReturnTrueIfCompareBetweenTheTwoSameModelWith07PrimaryKeys()
		{
			/* --- ARRANGE --- */
			var cbmtj1 = new MockModelWith07PrimaryKeys();
			var cbmtj2 = new MockModelWith07PrimaryKeys();

			/* --- ACT --- */
			var result = cbmtj1.Equals(cbmtj2); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(result, Is.True);
		}

		[Test]
		[Parallelizable]
		public void Equals_MustReturnTrueIfCompareBetweenTheTwoSameModelWith08PrimaryKeys()
		{
			/* --- ARRANGE --- */
			var cbmtj1 = new MockModelWith08PrimaryKeys();
			var cbmtj2 = new MockModelWith08PrimaryKeys();

			/* --- ACT --- */
			var result = cbmtj1.Equals(cbmtj2); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(result, Is.True);
		}

		[Test]
		[Parallelizable]
		public void Equals_MustReturnFalseIfCompareBetweenModelWith00PrimaryKeysAndNull()
		{
			/* --- ARRANGE --- */
			var cbmtj = new MockModelWith00PrimaryKeys();

			/* --- ACT --- */
			var result = cbmtj.Equals(null); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(result, Is.False);
		}

		[Test]
		[Parallelizable]
		public void Equals_MustReturnFalseIfCompareBetweenModelWith01PrimaryKeysAndNull()
		{
			/* --- ARRANGE --- */
			var cbmtj = new MockModelWith01PrimaryKeys();

			/* --- ACT --- */
			var result = cbmtj.Equals(null); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(result, Is.False);
		}

		[Test]
		[Parallelizable]
		public void Equals_MustReturnFalseIfCompareBetweenModelWith02PrimaryKeysAndNull()
		{
			/* --- ARRANGE --- */
			var cbmtj = new MockModelWith02PrimaryKeys();

			/* --- ACT --- */
			var result = cbmtj.Equals(null); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(result, Is.False);
		}

		[Test]
		[Parallelizable]
		public void Equals_MustReturnFalseIfCompareBetweenModelWith03PrimaryKeysAndNull()
		{
			/* --- ARRANGE --- */
			var cbmtj = new MockModelWith03PrimaryKeys();

			/* --- ACT --- */
			var result = cbmtj.Equals(null); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(result, Is.False);
		}

		[Test]
		[Parallelizable]
		public void Equals_MustReturnFalseIfCompareBetweenModelWith04PrimaryKeysAndNull()
		{
			/* --- ARRANGE --- */
			var cbmtj = new MockModelWith04PrimaryKeys();

			/* --- ACT --- */
			var result = cbmtj.Equals(null); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(result, Is.False);
		}

		[Test]
		[Parallelizable]
		public void Equals_MustReturnFalseIfCompareBetweenModelWith05PrimaryKeysAndNull()
		{
			/* --- ARRANGE --- */
			var cbmtj = new MockModelWith05PrimaryKeys();

			/* --- ACT --- */
			var result = cbmtj.Equals(null); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(result, Is.False);
		}

		[Test]
		[Parallelizable]
		public void Equals_MustReturnFalseIfCompareBetweenModelWith06PrimaryKeysAndNull()
		{
			/* --- ARRANGE --- */
			var cbmtj = new MockModelWith06PrimaryKeys();

			/* --- ACT --- */
			var result = cbmtj.Equals(null); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(result, Is.False);
		}

		[Test]
		[Parallelizable]
		public void Equals_MustReturnFalseIfCompareBetweenModelWith07PrimaryKeysAndNull()
		{
			/* --- ARRANGE --- */
			var cbmtj = new MockModelWith07PrimaryKeys();

			/* --- ACT --- */
			var result = cbmtj.Equals(null); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(result, Is.False);
		}

		[Test]
		[Parallelizable]
		public void Equals_MustReturnFalseIfCompareBetweenModelWith08PrimaryKeysAndNull()
		{
			/* --- ARRANGE --- */
			var cbmtj = new MockModelWith08PrimaryKeys();

			/* --- ACT --- */
			var result = cbmtj.Equals(null); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(result, Is.False);
		}

	}
}
