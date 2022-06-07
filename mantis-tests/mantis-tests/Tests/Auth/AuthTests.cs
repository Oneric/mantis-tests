using NUnit.Framework;
using System;

namespace mantis_tests.Tests.Auth
{
    [TestFixture]
    public class AuthTests : TestBase
    {
        [Test]
        public void AuthTest()
        {
            AccountData account = new AccountData() { 
            Username = "Testuser",
            Password = "12345678"
            };
            app.Auth.Autenticate(account);
        }
    }
}
