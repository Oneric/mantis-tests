using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    public class RegistrationTestBase : TestBase
    {
        [OneTimeSetUp]
        public void SetUpConfig()
        {
            string localPath = TestContext.CurrentContext.TestDirectory + @"\config_inc.php";
            app.Ftp.Backup("/config_inc.php");
            using (Stream localFile = File.Open(localPath, FileMode.Open))
            {
                app.Ftp.Upload("/config_inc.php", localFile);
            }
            app.Registration.GoToRegistrationPage();
        }
        [OneTimeTearDown]
        public void RestoreConfig()
        {
            app.Ftp.Restore("/config_inc.php");
        }
    }
}
