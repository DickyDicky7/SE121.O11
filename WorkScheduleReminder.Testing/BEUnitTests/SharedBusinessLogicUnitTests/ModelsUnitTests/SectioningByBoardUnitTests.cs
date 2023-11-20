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
	public class SectioningByBoardUnitTests
	{
		[Test]
		[Parallelizable]
		public void GetPrimaryKeyPropertyName1_MustReturnNameOfSectionByBoardId()
		{
			/* --- ARRANGE --- */
			var sectioningByBoard = new SectioningByBoard();

			/* --- ACT --- */
			var primaryKeyPropertyName1 = sectioningByBoard.PrimaryKeyPropertyName1; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(primaryKeyPropertyName1, Is.EqualTo(nameof(sectioningByBoard.SectionByBoardId)));
		}

		[Test]
		[Parallelizable]
		public void GetPrimaryKeyPropertyName2_MustReturnNameOfTaskId()
		{
			/* --- ARRANGE --- */
			var sectioningByBoard = new SectioningByBoard();

			/* --- ACT --- */
			var primaryKeyPropertyName2 = sectioningByBoard.PrimaryKeyPropertyName2; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(primaryKeyPropertyName2, Is.EqualTo(nameof(sectioningByBoard.TaskId)));
		}

		[Test]
		[Parallelizable]
		public void GetPrimaryKeyPropertyName3_MustReturnEmptyString()
		{
			/* --- ARRANGE --- */
			var sectioningByBoard = new SectioningByBoard();

			/* --- ACT --- */
			var primaryKeyPropertyName3 = sectioningByBoard.PrimaryKeyPropertyName3; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(primaryKeyPropertyName3, Is.Empty);
		}

		[Test]
		[Parallelizable]
		public void GetPrimaryKeyPropertyName4_MustReturnEmptyString()
		{
			/* --- ARRANGE --- */
			var sectioningByBoard = new SectioningByBoard();

			/* --- ACT --- */
			var primaryKeyPropertyName4 = sectioningByBoard.PrimaryKeyPropertyName4; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(primaryKeyPropertyName4, Is.Empty);
		}

		[Test]
		[Parallelizable]
		public void GetPrimaryKeyPropertyName5_MustReturnEmptyString()
		{
			/* --- ARRANGE --- */
			var sectioningByBoard = new SectioningByBoard();

			/* --- ACT --- */
			var primaryKeyPropertyName5 = sectioningByBoard.PrimaryKeyPropertyName5; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(primaryKeyPropertyName5, Is.Empty);
		}

		[Test]
		[Parallelizable]
		public void GetPrimaryKeyPropertyName6_MustReturnEmptyString()
		{
			/* --- ARRANGE --- */
			var sectioningByBoard = new SectioningByBoard();

			/* --- ACT --- */
			var primaryKeyPropertyName6 = sectioningByBoard.PrimaryKeyPropertyName6; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(primaryKeyPropertyName6, Is.Empty);
		}

		[Test]
		[Parallelizable]
		public void GetPrimaryKeyPropertyName7_MustReturnEmptyString()
		{
			/* --- ARRANGE --- */
			var sectioningByBoard = new SectioningByBoard();

			/* --- ACT --- */
			var primaryKeyPropertyName7 = sectioningByBoard.PrimaryKeyPropertyName7; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(primaryKeyPropertyName7, Is.Empty);
		}

		[Test]
		[Parallelizable]
		public void GetPrimaryKeyPropertyName8_MustReturnEmptyString()
		{
			/* --- ARRANGE --- */
			var sectioningByBoard = new SectioningByBoard();

			/* --- ACT --- */
			var primaryKeyPropertyName8 = sectioningByBoard.PrimaryKeyPropertyName8; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(primaryKeyPropertyName8, Is.Empty);
		}

		[Test]
		[Parallelizable]
		public void GetTaskId_MustReturnEmptyGuid()
		{
			/* --- ARRANGE --- */
			var sectioningByBoard = new SectioningByBoard();

			/* --- ACT --- */
			var taskId = sectioningByBoard.TaskId; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(taskId, Is.EqualTo(Guid.Empty));
		}

		[Test]
		[Parallelizable]
		public void GetSectionByBoardId_MustReturnEmptyGuid()
		{
			/* --- ARRANGE --- */
			var sectioningByBoard = new SectioningByBoard();

			/* --- ACT --- */
			var sectionByBoardId = sectioningByBoard.SectionByBoardId; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(sectionByBoardId, Is.EqualTo(Guid.Empty));
		}

		[Test]
		[Parallelizable]
		public void GetTask_MustReturnNull()
		{
			/* --- ARRANGE --- */
			var sectioningByBoard = new SectioningByBoard();

			/* --- ACT --- */
			var task = sectioningByBoard.Task; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(task, Is.Null);
		}

		[Test]
		[Parallelizable]
		public void GetSectionByBoard_MustReturnNull()
		{
			/* --- ARRANGE --- */
			var sectioningByBoard = new SectioningByBoard();

			/* --- ACT --- */
			var sectionByBoard = sectioningByBoard.SectionByBoard; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(sectionByBoard, Is.Null);
		}
	}
}
