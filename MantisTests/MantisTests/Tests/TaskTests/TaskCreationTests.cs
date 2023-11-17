using MantisTests.Mantis;
using MantisTests.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisTests.Tests.TaskTests
{
    [TestFixture]
    public class TaskCreationTests : AuthTestBase
    {
        private Models.ProjectData _project;
        private TaskData _task;

        [SetUp]
        public void CreateData()
        {
            _project = new Models.ProjectData()
            {
                Name = "TestProject",
            };
            _task = new TaskData()
            {
                Summary = "Test",
                Description = "Test"
            };
        }

        [Test]
        public void TaskCreationTest()
        {
            var idTask = _applicationManager.Tasks.CreateTask(_task, _project);
            Assert.False(_applicationManager.Tasks.CheckTask(idTask));
        }
    }
}
