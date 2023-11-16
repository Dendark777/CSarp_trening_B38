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
        [Test]
        public void TaskCreationTest()
        {

            ProjectData project = new ProjectData()
            {
                Name = "TestProject",
            };
            TaskData task = new TaskData()
            {
                Summary = "Test",
                Description = "Test"
            };
            var idTask = _applicationManager.Tasks.CreateTask(task, project);
            Assert.False(_applicationManager.Tasks.CheckTask(idTask));
        }
    }
}
