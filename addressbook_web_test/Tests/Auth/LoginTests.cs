using AddressbookWebTest;
using AddressbookWebTest.Tests;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_test.Tests.Auth
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
