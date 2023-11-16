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
	public class TagByGroupUnitTests
	{
		[Test]
		public void Test1()
		{
			var tagByGroup = new TagByGroup();

			Assert.That(tagByGroup.Name, Is.Null);
		}

		[Test]
		public void Test2()
		{
			var tagByGroup = new TagByGroup();

			Assert.That(tagByGroup.Settings, Is.Null);
		}

		[Test]
		public void Test3()
		{
			var tagByGroup = new TagByGroup();

			Assert.That(tagByGroup.Group, Is.Null);
		}

		[Test]
		public void Test4()
		{
			var tagByGroup = new TagByGroup();

			Assert.That(tagByGroup.GroupId, Is.EqualTo(Guid.Parse("00000000-0000-0000-0000-000000000000")));
		}
	}
}
