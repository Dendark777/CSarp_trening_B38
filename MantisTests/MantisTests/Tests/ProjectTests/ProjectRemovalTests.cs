using MantisTests.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisTests.Tests.ProjectTests
{
    [TestFixture]
    public class ProjectRemovalTests : AuthTestBase
    {
        [Test]
        public void ProjectRemovalTest()
        {

            ProjectData project = new ProjectData()
            {
                Name = "TestProject2",
            };
            _applicationManager.Projects.RemoveProject(project);
            Assert.False(_applicationManager.Projects.CheckProjectExist(project));
        }
    }
}
