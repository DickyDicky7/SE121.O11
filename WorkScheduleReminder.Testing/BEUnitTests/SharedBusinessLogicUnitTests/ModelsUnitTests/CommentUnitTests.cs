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
	public class CommentUnitTests
	{
		[Test]
		[Parallelizable]
		public void GetTaskId_MustReturnEmptyGuid()
		{
			/* --- ARRANGE --- */
			var comment = new Comment();

			/* --- ACT --- */
			var taskId = comment.TaskId; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(taskId, Is.EqualTo(Guid.Empty));
		}

		[Test]
		[Parallelizable]
		public void GetProfileId_MustReturnEmptyGuid()
		{
			/* --- ARRANGE --- */
			var comment = new Comment();

			/* --- ACT --- */
			var profileId = comment.ProfileId; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(profileId, Is.EqualTo(Guid.Empty));
		}

		[Test]
		[Parallelizable]
		public void GetTask_MustReturnNull()
		{
			/* --- ARRANGE --- */
			var comment = new Comment();

			/* --- ACT --- */
			var task = comment.Task; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(task, Is.Null);
		}

		[Test]
		[Parallelizable]
		public void GetProfile_MustReturnNull()
		{
			/* --- ARRANGE --- */
			var comment = new Comment();

			/* --- ACT --- */
			var profile = comment.Profile; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(profile, Is.Null);
		}

		[Test]
		[Parallelizable]
		public void GetMessage_MustReturnNull()
		{
			/* --- ARRANGE --- */
			var comment = new Comment();

			/* --- ACT --- */
			var message = comment.Message; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(message, Is.Null);
		}

		[Test]
		[Parallelizable]
		public void GetCommentId_MustReturnNull()
		{
			/* --- ARRANGE --- */
			var comment = new Comment();

			/* --- ACT --- */
			var commentId = comment.CommentId; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(commentId, Is.Null);
		}

		[Test]
		[Parallelizable]
		public void GetReplies_MustReturnNull()
		{
			/* --- ARRANGE --- */
			var comment = new Comment();

			/* --- ACT --- */
			var replies = comment.Replies; /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(replies, Is.Null);
		}
	}
}
