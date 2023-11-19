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
	public class TagByBoardUnitTests
	{
		[Test]
		[Parallelizable]
		public void GetName_MustReturnNull()
		{
			/* --- ARRANGE --- */
			var tagByBoard = new TagByBoard();

			/* --- ACT --- */
			var name = tagByBoard.Name; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(name, Is.Null);
		}

		[Test]
		[Parallelizable]
		public void GetSettings_MustReturnNull()
		{
			/* --- ARRANGE --- */
			var tagByBoard = new TagByBoard();

			/* --- ACT --- */
			var settings = tagByBoard.Settings; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(settings, Is.Null);
		}

		[Test]
		[Parallelizable]
		public void GetBoard_MustReturnNull()
		{
			/* --- ARRANGE --- */
			var tagByBoard = new TagByBoard();

			/* --- ACT --- */
			var board = tagByBoard.Board; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(board, Is.Null);
		}

		[Test]
		[Parallelizable]
		public void GetBoardId_MustReturnEmptyGuid()
		{
			/* --- ARRANGE --- */
			var tagByBoard = new TagByBoard();

			/* --- ACT --- */
			var boardId = tagByBoard.BoardId; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(boardId, Is.EqualTo(Guid.Empty));
		}
	}
}
