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
    public class TaskRemovalTests : AuthTestBase
    {
        [Test]
        public void TaskRemovalTest()
        {
            int idTask = _applicationManager.Tasks.RemoveTask(1);
            Assert.True(_applicationManager.Tasks.CheckTask(idTask));
        }
    }
}
