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
            string username = RandomStringWithChars(10);

            AccountData newAccount = new AccountData()
            {
                Username = username,
                Email = $"{ username }@localhost.mbt",
                RealName = RandomStringWithChars(10),
                Password = "12345678"
            };
            app.James.Delete(newAccount);
            app.James.Add(newAccount);
            app.Registration.RegisterNewAccount(newAccount);

            //Assertions
        }
    }
}
