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
	public class SectionByBoardUnitTests
	{
		[Test]
		[Parallelizable]
		public void GetName_MustReturnNull()
		{
			/* --- ARRANGE --- */
			var sectionByBoard = new SectionByBoard();

			/* --- ACT --- */
			var name = sectionByBoard.Name; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(name, Is.Null);
		}

		[Test]
		[Parallelizable]
		public void GetSettings_MustReturnNull()
		{
			/* --- ARRANGE --- */
			var sectionByBoard = new SectionByBoard();

			/* --- ACT --- */
			var settings = sectionByBoard.Settings; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(settings, Is.Null);
		}

		[Test]
		[Parallelizable]
		public void GetBoard_MustReturnNull()
		{
			/* --- ARRANGE --- */
			var sectionByBoard = new SectionByBoard();

			/* --- ACT --- */
			var board = sectionByBoard.Board; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(board, Is.Null);
		}

		[Test]
		[Parallelizable]
		public void GetBoardId_MustReturnEmptyGuid()
		{
			/* --- ARRANGE --- */
			var sectionByBoard = new SectionByBoard();

			/* --- ACT --- */
			var boardId = sectionByBoard.BoardId; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(boardId, Is.EqualTo(Guid.Empty));
		}
	}
}
