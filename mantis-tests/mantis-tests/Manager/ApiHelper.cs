using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mantis_tests.Mantis;

namespace mantis_tests
{
    public class ApiHelper : HelperBase
    {
        public ApiHelper(ApplicationManager manager) : base(manager)
        {

        }
        public List<ProjectData> GetProjectList(AccountData account)
        {
            using (MantisConnectPortTypeClient client = new MantisConnectPortTypeClient())
            {
                List<ProjectData> projects = new List<ProjectData>();
                Mantis.ProjectData[] mantisProjests = client.mc_projects_get_user_accessible(account.Username, account.Password);

                foreach (Mantis.ProjectData project in mantisProjests)
                {
                    projects.Add(new ProjectData()
                    {
                        Id = project.id,
                        Name = project.name,
                        Description = project.description,
                    });
                }
                return projects;
            }
        }
        public void Create(AccountData account, ProjectData project)
        {
            using (MantisConnectPortTypeClient client = new MantisConnectPortTypeClient())
            {
                client.mc_project_add(account.Username, account.Password, new Mantis.ProjectData()
                {
                    name = project.Name,
                    description = project.Description
                });
            }
        }
        public void Delete(AccountData account, ProjectData project)
        {
            using (MantisConnectPortTypeClient client = new MantisConnectPortTypeClient())
            {
                client.mc_project_delete(account.Username, account.Password, project.Id);
            }
        }
    }
}
