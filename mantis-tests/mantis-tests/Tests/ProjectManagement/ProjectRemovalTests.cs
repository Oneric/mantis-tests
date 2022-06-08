using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace mantis_tests.Tests.ProjectManagement
{
    [TestFixture]
    public class ProjectRemovalTests : ProjectManagementTestBase
    {
        [Test]
        public void RemoveProjectTest()
        {
            if(app.ProjectManagement.GetProjectList().Count == 0)
            {
                ProjectData project = new ProjectData() {
                    Name = RandomStringWithChars(15),
                    Description = RandomStringWithChars(100),
                };
                app.ProjectManagement.Create(project);
            }
            List<ProjectData> oldList = app.ProjectManagement.GetProjectList();

            app.ProjectManagement.Remove(0);

            List<ProjectData> newList = app.ProjectManagement.GetProjectList();
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
