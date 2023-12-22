using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models = WorkScheduleReminder.SharedBusinessLogic.Models.Implementations;

namespace WorkScheduleReminder.Testing.BEUnitTests.SharedBusinessLogicUnitTests.ModelsUnitTests
{
    [TestFixture]
    [Parallelizable]
    [FixtureLifeCycle(LifeCycle.SingleInstance)]
    public class TaskUnitTests
    {
        [Test]
        [Parallelizable]
        public void IsBoardTask_MustReturnTWhenBoardIdNoNull()
        {
            /* --- ARRANGE --- */
            var task = new Models.Task();

            /* --- ACT --- */
            task.BoardId = Guid.Empty; /* <-- HERE <-- */

            /* --- ASSERT --- */
            Assert.That(task.IsBoardTask(), Is.True);
        }

        [Test]
        [Parallelizable]
        public void IsBoardTask_MustReturnFWhenBoardIdIsNull()
        {
            /* --- ARRANGE --- */
            var task = new Models.Task();

            /* --- ACT --- */
            task.BoardId = null; /* <-- HERE <-- */

            /* --- ASSERT --- */
            Assert.That(task.IsBoardTask(), Is.False);
        }

        [Test]
        [Parallelizable]
        public void HasReminder_MustReturnF_If_1F_2F_3F()
        {
            /* --- ARRANGE --- */
            var task = new Models.Task();

            /* --- ACT --- */
            task.ReminderRecurringMode = Models.Task.PossibleReminderRecurringMode.Empty.ToString(); /* <-- HERE <-- */
            task.ReminderBeginDate = null; /* <-- HERE <-- */
            task.ReminderBeginTime = null; /* <-- HERE <-- */

            /* --- ASSERT --- */
            Assert.That(task.HasReminder(), Is.False);
        }

        [Test]
        [Parallelizable]
        public void HasReminder_MustReturnF_If_1T_2F_3F()
        {
            /* --- ARRANGE --- */
            var task = new Models.Task();

            /* --- ACT --- */
            task.ReminderRecurringMode = Models.Task.PossibleReminderRecurringMode.Daily.ToString(); /* <-- HERE <-- */
            task.ReminderBeginDate = null; /* <-- HERE <-- */
            task.ReminderBeginTime = null; /* <-- HERE <-- */

            /* --- ASSERT --- */
            Assert.That(task.HasReminder(), Is.False);
        }

        [Test]
        [Parallelizable]
        public void HasReminder_MustReturnF_If_1F_2T_3F()
        {
            /* --- ARRANGE --- */
            var task = new Models.Task();

            /* --- ACT --- */
            task.ReminderRecurringMode = Models.Task.PossibleReminderRecurringMode.Empty.ToString(); /* <-- HERE <-- */
            task.ReminderBeginDate = DateOnly.MinValue; /* <-- HERE <-- */
            task.ReminderBeginTime = null; /* <-- HERE <-- */

            /* --- ASSERT --- */
            Assert.That(task.HasReminder(), Is.False);
        }

        [Test]
        [Parallelizable]
        public void HasReminder_MustReturnF_If_1T_2T_3F()
        {
            /* --- ARRANGE --- */
            var task = new Models.Task();

            /* --- ACT --- */
            task.ReminderRecurringMode = Models.Task.PossibleReminderRecurringMode.Daily.ToString(); /* <-- HERE <-- */
            task.ReminderBeginDate = DateOnly.MinValue; /* <-- HERE <-- */
            task.ReminderBeginTime = null; /* <-- HERE <-- */

            /* --- ASSERT --- */
            Assert.That(task.HasReminder(), Is.False);
        }

        [Test]
        [Parallelizable]
        public void HasReminder_MustReturnF_If_1F_2F_3T()
        {
            /* --- ARRANGE --- */
            var task = new Models.Task();

            /* --- ACT --- */
            task.ReminderRecurringMode = Models.Task.PossibleReminderRecurringMode.Empty.ToString(); /* <-- HERE <-- */
            task.ReminderBeginDate = null; /* <-- HERE <-- */
            task.ReminderBeginTime = TimeOnly.MinValue; /* <-- HERE <-- */

            /* --- ASSERT --- */
            Assert.That(task.HasReminder(), Is.False);
        }

        [Test]
        [Parallelizable]
        public void HasReminder_MustReturnF_If_1T_2F_3T()
        {
            /* --- ARRANGE --- */
            var task = new Models.Task();

            /* --- ACT --- */
            task.ReminderRecurringMode = Models.Task.PossibleReminderRecurringMode.Daily.ToString(); /* <-- HERE <-- */
            task.ReminderBeginDate = null; /* <-- HERE <-- */
            task.ReminderBeginTime = TimeOnly.MinValue; /* <-- HERE <-- */

            /* --- ASSERT --- */
            Assert.That(task.HasReminder(), Is.False);
        }

        [Test]
        [Parallelizable]
        public void HasReminder_MustReturnF_If_1F_2T_3T()
        {
            /* --- ARRANGE --- */
            var task = new Models.Task();

            /* --- ACT --- */
            task.ReminderRecurringMode = Models.Task.PossibleReminderRecurringMode.Empty.ToString(); /* <-- HERE <-- */
            task.ReminderBeginDate = DateOnly.MinValue; /* <-- HERE <-- */
            task.ReminderBeginTime = TimeOnly.MinValue; /* <-- HERE <-- */

            /* --- ASSERT --- */
            Assert.That(task.HasReminder(), Is.False);
        }

        [Test]
        [Parallelizable]
        public void HasReminder_MustReturnT_If_1T_2T_3T()
        {
            /* --- ARRANGE --- */
            var task = new Models.Task();

            /* --- ACT --- */
            task.ReminderRecurringMode = Models.Task.PossibleReminderRecurringMode.Daily.ToString(); /* <-- HERE <-- */
            task.ReminderBeginDate = DateOnly.MinValue; /* <-- HERE <-- */
            task.ReminderBeginTime = TimeOnly.MinValue; /* <-- HERE <-- */

            /* --- ASSERT --- */
            Assert.That(task.HasReminder(), Is.True);
        }

        [Test]
        [Parallelizable]
        public void HasReminderNeverEnd_MustReturnF_If_1F_2F_3F()
        {
            /* --- ARRANGE --- */
            var task = new Models.Task();

            /* --- ACT --- */
            task.ReminderRecurringMode = Models.Task.PossibleReminderRecurringMode.Empty.ToString(); /* <-- HERE <-- */
            task.ReminderBeginDate = null; /* <-- HERE <-- */
            task.ReminderBeginTime = null; /* <-- HERE <-- */

            task.ReminderCeaseDate = DateOnly.MinValue; /* <-- HERE <-- */
            task.ReminderCeaseTime = TimeOnly.MinValue; /* <-- HERE <-- */

            /* --- ASSERT --- */
            Assert.That(task.HasReminderNeverEnd(), Is.False);
        }

        [Test]
        [Parallelizable]
        public void HasReminderNeverEnd_MustReturnF_If_1F_2F_3T()
        {
            /* --- ARRANGE --- */
            var task = new Models.Task();

            /* --- ACT --- */
            task.ReminderRecurringMode = Models.Task.PossibleReminderRecurringMode.Empty.ToString(); /* <-- HERE <-- */
            task.ReminderBeginDate = null; /* <-- HERE <-- */
            task.ReminderBeginTime = null; /* <-- HERE <-- */

            task.ReminderCeaseDate = DateOnly.MinValue; /* <-- HERE <-- */
            task.ReminderCeaseTime = null; /* <-- HERE <-- */

            /* --- ASSERT --- */
            Assert.That(task.HasReminderNeverEnd(), Is.False);
        }

        [Test]
        [Parallelizable]
        public void HasReminderNeverEnd_MustReturnF_If_1F_2T_3F()
        {
            /* --- ARRANGE --- */
            var task = new Models.Task();

            /* --- ACT --- */
            task.ReminderRecurringMode = Models.Task.PossibleReminderRecurringMode.Empty.ToString(); /* <-- HERE <-- */
            task.ReminderBeginDate = null; /* <-- HERE <-- */
            task.ReminderBeginTime = null; /* <-- HERE <-- */

            task.ReminderCeaseDate = null; /* <-- HERE <-- */
            task.ReminderCeaseTime = TimeOnly.MinValue; /* <-- HERE <-- */

            /* --- ASSERT --- */
            Assert.That(task.HasReminderNeverEnd(), Is.False);
        }

        [Test]
        [Parallelizable]
        public void HasReminderNeverEnd_MustReturnF_If_1F_2T_3T()
        {
            /* --- ARRANGE --- */
            var task = new Models.Task();

            /* --- ACT --- */
            task.ReminderRecurringMode = Models.Task.PossibleReminderRecurringMode.Empty.ToString(); /* <-- HERE <-- */
            task.ReminderBeginDate = null; /* <-- HERE <-- */
            task.ReminderBeginTime = null; /* <-- HERE <-- */

            task.ReminderCeaseDate = null; /* <-- HERE <-- */
            task.ReminderCeaseTime = null; /* <-- HERE <-- */

            /* --- ASSERT --- */
            Assert.That(task.HasReminderNeverEnd(), Is.False);
        }

        [Test]
        [Parallelizable]
        public void HasReminderNeverEnd_MustReturnF_If_1T_2F_3F()
        {
            /* --- ARRANGE --- */
            var task = new Models.Task();

            /* --- ACT --- */
            task.ReminderRecurringMode = Models.Task.PossibleReminderRecurringMode.Daily.ToString(); /* <-- HERE <-- */
            task.ReminderBeginDate = DateOnly.MinValue; /* <-- HERE <-- */
            task.ReminderBeginTime = TimeOnly.MinValue; /* <-- HERE <-- */

            task.ReminderCeaseDate = DateOnly.MinValue; /* <-- HERE <-- */
            task.ReminderCeaseTime = TimeOnly.MinValue; /* <-- HERE <-- */

            /* --- ASSERT --- */
            Assert.That(task.HasReminderNeverEnd(), Is.False);
        }

        [Test]
        [Parallelizable]
        public void HasReminderNeverEnd_MustReturnF_If_1T_2F_3T()
        {
            /* --- ARRANGE --- */
            var task = new Models.Task();

            /* --- ACT --- */
            task.ReminderRecurringMode = Models.Task.PossibleReminderRecurringMode.Daily.ToString(); /* <-- HERE <-- */
            task.ReminderBeginDate = DateOnly.MinValue; /* <-- HERE <-- */
            task.ReminderBeginTime = TimeOnly.MinValue; /* <-- HERE <-- */

            task.ReminderCeaseDate = DateOnly.MinValue; /* <-- HERE <-- */
            task.ReminderCeaseTime = null; /* <-- HERE <-- */

            /* --- ASSERT --- */
            Assert.That(task.HasReminderNeverEnd(), Is.False);
        }

        [Test]
        [Parallelizable]
        public void HasReminderNeverEnd_MustReturnF_If_1T_2T_3F()
        {
            /* --- ARRANGE --- */
            var task = new Models.Task();

            /* --- ACT --- */
            task.ReminderRecurringMode = Models.Task.PossibleReminderRecurringMode.Daily.ToString(); /* <-- HERE <-- */
            task.ReminderBeginDate = DateOnly.MinValue; /* <-- HERE <-- */
            task.ReminderBeginTime = TimeOnly.MinValue; /* <-- HERE <-- */

            task.ReminderCeaseDate = null; /* <-- HERE <-- */
            task.ReminderCeaseTime = TimeOnly.MinValue; /* <-- HERE <-- */

            /* --- ASSERT --- */
            Assert.That(task.HasReminderNeverEnd(), Is.False);
        }

        [Test]
        [Parallelizable]
        public void HasReminderNeverEnd_MustReturnT_If_1T_2T_3T()
        {
            /* --- ARRANGE --- */
            var task = new Models.Task();

            /* --- ACT --- */
            task.ReminderRecurringMode = Models.Task.PossibleReminderRecurringMode.Daily.ToString(); /* <-- HERE <-- */
            task.ReminderBeginDate = DateOnly.MinValue; /* <-- HERE <-- */
            task.ReminderBeginTime = TimeOnly.MinValue; /* <-- HERE <-- */

            task.ReminderCeaseDate = null; /* <-- HERE <-- */
            task.ReminderCeaseTime = null; /* <-- HERE <-- */

            /* --- ASSERT --- */
            Assert.That(task.HasReminderNeverEnd(), Is.True);
        }
    }
}
