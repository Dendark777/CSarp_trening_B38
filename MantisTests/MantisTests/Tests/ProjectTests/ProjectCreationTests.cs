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
        private Models.ProjectData _project;

        [SetUp]
        public void CreateData()
        {
            _project = new Models.ProjectData()
            {
                Name = "TestProject5",
            };
        }

        [Test]
        public void ProjectCreationTest()
        {
            _applicationManager.Projects.CreateProject(_project);
            Assert.True(_applicationManager.Projects.CheckProjectExist(_project));
        }

        [Test]
        public void ProjectCreationTestCheckApi()
        {
            var oldProjectList = _applicationManager.Projects.GetProjectsFromApi(_adminAccount);
            var existingProject = oldProjectList.FirstOrDefault(p=>p.Name == _project.Name);
            Assert.True(existingProject == null);

            _applicationManager.Projects.CreateProjectWithoutCheck(_project);

            var newProjectList = _applicationManager.Projects.GetProjectsFromApi(_adminAccount);
            oldProjectList.Add(_project);
            oldProjectList.Sort();
            newProjectList.Sort();
            Assert.AreEqual(oldProjectList, newProjectList);
        }
    }
}
