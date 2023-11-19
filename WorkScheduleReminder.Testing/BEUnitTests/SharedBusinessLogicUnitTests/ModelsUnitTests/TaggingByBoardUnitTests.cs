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
	public class TaggingByBoardUnitTests
	{
		[Test]
		[Parallelizable]
		public void GetPrimaryKeyPropertyName1_MustReturnNameOfTagByBoardId()
		{
			/* --- ARRANGE --- */
			var taggingByBoard = new TaggingByBoard();

			/* --- ACT --- */
			var primaryKeyPropertyName1 = taggingByBoard.PrimaryKeyPropertyName1; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(primaryKeyPropertyName1, Is.EqualTo(nameof(taggingByBoard.TagByBoardId)));
		}

		[Test]
		[Parallelizable]
		public void GetPrimaryKeyPropertyName2_MustReturnNameOfTaskId()
		{
			/* --- ARRANGE --- */
			var taggingByBoard = new TaggingByBoard();

			/* --- ACT --- */
			var primaryKeyPropertyName2 = taggingByBoard.PrimaryKeyPropertyName2; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(primaryKeyPropertyName2, Is.EqualTo(nameof(taggingByBoard.TaskId)));
		}

		[Test]
		[Parallelizable]
		public void GetPrimaryKeyPropertyName3_MustReturnEmptyString()
		{
			/* --- ARRANGE --- */
			var taggingByBoard = new TaggingByBoard();

			/* --- ACT --- */
			var primaryKeyPropertyName3 = taggingByBoard.PrimaryKeyPropertyName3; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(primaryKeyPropertyName3, Is.Empty);
		}

		[Test]
		[Parallelizable]
		public void GetPrimaryKeyPropertyName4_MustReturnEmptyString()
		{
			/* --- ARRANGE --- */
			var taggingByBoard = new TaggingByBoard();

			/* --- ACT --- */
			var primaryKeyPropertyName4 = taggingByBoard.PrimaryKeyPropertyName4; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(primaryKeyPropertyName4, Is.Empty);
		}

		[Test]
		[Parallelizable]
		public void GetPrimaryKeyPropertyName5_MustReturnEmptyString()
		{
			/* --- ARRANGE --- */
			var taggingByBoard = new TaggingByBoard();

			/* --- ACT --- */
			var primaryKeyPropertyName5 = taggingByBoard.PrimaryKeyPropertyName5; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(primaryKeyPropertyName5, Is.Empty);
		}

		[Test]
		[Parallelizable]
		public void GetPrimaryKeyPropertyName6_MustReturnEmptyString()
		{
			/* --- ARRANGE --- */
			var taggingByBoard = new TaggingByBoard();

			/* --- ACT --- */
			var primaryKeyPropertyName6 = taggingByBoard.PrimaryKeyPropertyName6; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(primaryKeyPropertyName6, Is.Empty);
		}

		[Test]
		[Parallelizable]
		public void GetPrimaryKeyPropertyName7_MustReturnEmptyString()
		{
			/* --- ARRANGE --- */
			var taggingByBoard = new TaggingByBoard();

			/* --- ACT --- */
			var primaryKeyPropertyName7 = taggingByBoard.PrimaryKeyPropertyName7; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(primaryKeyPropertyName7, Is.Empty);
		}

		[Test]
		[Parallelizable]
		public void GetPrimaryKeyPropertyName8_MustReturnEmptyString()
		{
			/* --- ARRANGE --- */
			var taggingByBoard = new TaggingByBoard();

			/* --- ACT --- */
			var primaryKeyPropertyName8 = taggingByBoard.PrimaryKeyPropertyName8; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(primaryKeyPropertyName8, Is.Empty);
		}

		[Test]
		[Parallelizable]
		public void GetTaskId_MustReturnEmptyGuid()
		{
			/* --- ARRANGE --- */
			var taggingByBoard = new TaggingByBoard();

			/* --- ACT --- */
			var taskId = taggingByBoard.TaskId; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(taskId, Is.EqualTo(Guid.Empty));
		}

		[Test]
		[Parallelizable]
		public void GetTagByBoardId_MustReturnEmptyGuid()
		{
			/* --- ARRANGE --- */
			var taggingByBoard = new TaggingByBoard();

			/* --- ACT --- */
			var tagByBoardId = taggingByBoard.TagByBoardId; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(tagByBoardId, Is.EqualTo(Guid.Empty));
		}

		[Test]
		[Parallelizable]
		public void GetTask_MustReturnNull()
		{
			/* --- ARRANGE --- */
			var taggingByBoard = new TaggingByBoard();

			/* --- ACT --- */
			var task = taggingByBoard.Task; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(task, Is.Null);
		}

		[Test]
		[Parallelizable]
		public void GetTagByBoard_MustReturnNull()
		{
			/* --- ARRANGE --- */
			var taggingByBoard = new TaggingByBoard();

			/* --- ACT --- */
			var tagByBoard = taggingByBoard.TagByBoard; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(tagByBoard, Is.Null);
		}
	}
}
