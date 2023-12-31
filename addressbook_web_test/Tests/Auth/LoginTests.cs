﻿using NUnit.Framework;

namespace AddressbookWebTest.Tests.Auth
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidationCredentials()
        {
            //prepare
            _applicationManager.Login.Logout();
            //action
            var textAccount = new AccountData("admin", "secret");
            _applicationManager.Login.Login(textAccount);
            //verification
            Assert.IsTrue(_applicationManager.Login.IsLoggedIn(textAccount));
        }
        [Test]
        public void LoginWithInValidationCredentials()
        {
            //prepare
            _applicationManager.Login.Logout();
            //action
            var textAccount = new AccountData("admin", "dsads");
            _applicationManager.Login.Login(textAccount);
            //verification
            Assert.IsFalse(_applicationManager.Login.IsLoggedIn(textAccount));
        }
    }
}
