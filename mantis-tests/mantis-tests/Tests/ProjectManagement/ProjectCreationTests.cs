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
            AccountData account = new AccountData()
            {
                Username = "Testuser",
                Password = "12345678"
            };
            ProjectData project = new ProjectData()
            {
                Name = RandomStringWithChars(15),
                Description = RandomStringWithChars(100)
            };

            List<ProjectData> oldList = app.Api.GetProjectList(account);

            app.ProjectManagement.Create(project);

            List<ProjectData> newList = app.Api.GetProjectList(account);

            oldList.Add(project);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList.Count, newList.Count);
            Assert.AreEqual(oldList, newList);
        }
        [Test]
        public void ProjectCreationWithOutGeneratorTest()
        {
            AccountData account = new AccountData()
            {
                Username = "Testuser",
                Password = "12345678"
            };
            ProjectData project = new ProjectData()
            {
                Name = "NewTestProject",
                Description = "NewTestProject Descr"
            };

            ProjectData existingProject = app.Api.GetProjectList(account).Find(x => x.Name == project.Name);
            if (existingProject != null)
            {
                app.Api.Delete(account, existingProject);
            }
            List<ProjectData> oldList = app.Api.GetProjectList(account);

            app.ProjectManagement.Create(project);

            List<ProjectData> newList = app.Api.GetProjectList(account);

            oldList.Add(project);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList.Count, newList.Count);
            Assert.AreEqual(oldList, newList);
        }
    }
}
