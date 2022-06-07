using NUnit.Framework;
using System.IO;
using System;

namespace mantis_tests.Tests.Registration
{
    [TestFixture]
    public class AccountRegistrationTests : RegistrationTestBase
    {
        [Test]
        public void RegisterNewAccountTest()
        {
            AccountData newAccount = new AccountData()
            {
                Username = "Testuser12",
                Email = "Testuser12@localhost.mbt",
                RealName = "Testuser12",
                Password = "12345678"
            };
            app.James.Delete(newAccount);
            app.James.Add(newAccount);
            app.Registration.RegisterNewAccount(newAccount);

            //Assertions
        }
    }
}
