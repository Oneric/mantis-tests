using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    public class AuthTestBase : TestBase
    {
        [OneTimeSetUp]
        public void Auth()
        {
            AccountData account = new AccountData()
            {
                Username = "Testuser",
                Password = "12345678"
            };
            app.Auth.Autenticate(account);
        }
    }
}
