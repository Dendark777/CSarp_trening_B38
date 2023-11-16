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
    internal class ProjectCreationTests : AuthTestBase
    {
        [Test]
        public void ProjectCreationTest()
        {

            ProjectData project = new ProjectData()
            {
                Name = "TestProject2",
            };
            _applicationManager.Projects.CreateProject(project);
            Assert.True(_applicationManager.Projects.CheckProjectExist(project));
        }
    }
}
