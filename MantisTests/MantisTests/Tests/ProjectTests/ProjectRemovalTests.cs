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

        [Test]
        public void ProjectRemovalTestCheckApi()
        {
            var oldProjectList = _applicationManager.Projects.GetProjectsFromApi(_adminAccount);
            if (!oldProjectList.Any()) 
            {
                _applicationManager.Projects.CreateProjectFromApi(_adminAccount, new ProjectData
                {
                    Name = "project test"
                });
                oldProjectList = _applicationManager.Projects.GetProjectsFromApi(_adminAccount);
            }
            var project = oldProjectList.FirstOrDefault();
            _applicationManager.Projects.RemoveProject(project);

            var newProjectList = _applicationManager.Projects.GetProjectsFromApi(_adminAccount);
            oldProjectList.Remove(project);
            oldProjectList.Sort();
            newProjectList.Sort();
            Assert.AreEqual(oldProjectList, newProjectList);
        }
    }
}
