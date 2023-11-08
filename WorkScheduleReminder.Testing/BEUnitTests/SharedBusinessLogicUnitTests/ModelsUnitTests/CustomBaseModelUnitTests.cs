using Moq;
using System;
using System.Collections;
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
	public class CustomBaseModelUnitTests
	{
		[Test]
		[Parallelizable]
		[TestCaseSource(sourceType: typeof(CustomBaseModelUnitTests), sourceName: nameof(TestCasesForTestingEqualityOperatorEqualTo))]
		public bool TestEqualityOperatorEqualTo(CustomBaseModel? cbm1, CustomBaseModel? cbm2)
		{
			return cbm1 == cbm2;
		}

		public static IEnumerable TestCasesForTestingEqualityOperatorEqualTo
		{
			get
			{
				yield return new TestCaseData(null, Mock.Of<CustomBaseModel>()).Returns(false);
				yield return new TestCaseData(Mock.Of<CustomBaseModel>(), null).Returns(false);
				yield return new TestCaseData(null, null).Returns(true);
				yield return new TestCaseData(Mock.Of<CustomBaseModel>(), Mock.Of<CustomBaseModel>()).Returns(false);
			}
		}

		[Test]
		[Parallelizable]
		[TestCaseSource(sourceType: typeof(CustomBaseModelUnitTests), sourceName: nameof(TestCasesForTestingEqualityOperatorNotEqualTo))]
		public bool TestEqualityOperatorNotEqualTo(CustomBaseModel? cbm1, CustomBaseModel? cbm2)
		{
			return cbm1 != cbm2;
		}

		public static IEnumerable TestCasesForTestingEqualityOperatorNotEqualTo
		{
			get
			{
				yield return new TestCaseData(null, Mock.Of<CustomBaseModel>()).Returns(true);
				yield return new TestCaseData(Mock.Of<CustomBaseModel>(), null).Returns(true);
				yield return new TestCaseData(null, null).Returns(false);
				yield return new TestCaseData(Mock.Of<CustomBaseModel>(), Mock.Of<CustomBaseModel>()).Returns(true);
			}
		}
	}
}
