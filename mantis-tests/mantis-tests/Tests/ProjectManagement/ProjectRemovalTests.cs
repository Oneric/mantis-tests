using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace mantis_tests.Tests.ProjectManagement
{
    [TestFixture]
    public class ProjectRemovalTests : AuthTestBase
    {
        [Test]
        public void RemoveProjectTest()
        {
            AccountData account = new AccountData()
            {
                Username = "Testuser",
                Password = "12345678"
            };
            if (app.Api.GetProjectList(account).Count == 0)
            {
                ProjectData project = new ProjectData() {
                    Name = RandomStringWithChars(15),
                    Description = RandomStringWithChars(100),
                };
                app.Api.Create(account, project);
            }
            List<ProjectData> oldList = app.Api.GetProjectList(account);

            app.ProjectManagement.Remove(0);

            List<ProjectData> newList = app.Api.GetProjectList(account);
            ProjectData toBeRemoved = oldList[0];
            oldList.RemoveAt(0);
            oldList.Sort();
            newList.Sort();

            foreach (ProjectData project in newList)
            {
                Assert.AreNotEqual(project.Id, toBeRemoved.Id);
            }

            Assert.AreEqual(oldList.Count, newList.Count);
            Assert.AreEqual(oldList, newList);
        }
    }
}
