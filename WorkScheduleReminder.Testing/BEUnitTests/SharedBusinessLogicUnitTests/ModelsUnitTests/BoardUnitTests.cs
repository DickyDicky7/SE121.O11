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
	public class BoardUnitTests
	{
		[Test]
		[Parallelizable]
		public void GetName_MustReturnNull()
		{
			/* --- ARRANGE --- */
			var board = new Board();

			/* --- ACT --- */
			var name = board.Name; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(name, Is.Null);
		}

		[Test]
		[Parallelizable]
		public void GetOwnerId_MustReturnEmptyGuid()
		{
			/* --- ARRANGE --- */
			var board = new Board();

			/* --- ACT --- */
			var ownerId = board.OwnerId; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(ownerId, Is.EqualTo(Guid.Empty));
		}

		[Test]
		[Parallelizable]
		public void GetOwner_MustReturnNull()
		{
			/* --- ARRANGE --- */
			var board = new Board();

			/* --- ACT --- */
			var owner = board.Owner; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(owner, Is.Null);
		}
	}
}
