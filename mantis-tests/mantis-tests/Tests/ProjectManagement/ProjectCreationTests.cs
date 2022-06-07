using NUnit.Framework;
using System.Collections.Generic;
using System;

namespace mantis_tests.Tests.ProjectManagement
{ 
    [TestFixture]
    public class ProjectCreationTests : ProjectManagementTestBase
    {
        [Test]
        public void ProjectCreationTest()
        {
            ProjectData project = new ProjectData()
            {
                Name = GenerateRandomString(30),
                Description = GenerateRandomString(100)
            };

            List<ProjectData> oldList = app.ProjectManagement.GetProjectList();

            app.ProjectManagement.Create(project);

            List<ProjectData> newList = app.ProjectManagement.GetProjectList();

            oldList.Add(project);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList.Count, newList.Count);
            Assert.AreEqual(oldList, newList);
        }
    }
}
