using NUnit.Framework;

namespace AddressbookWebTest
{
    public class TestBase
    {
        protected ApplicationManager _applicationManager;

        [SetUp]
        public void SetupTest()
        {
            _applicationManager = new ApplicationManager();
            _applicationManager.NavigationHelper.GoToHomePage();
            _applicationManager.LoginHelpers.Login(new AccountData("admin", "secret"));
        }

        [TearDown]
        public void TeardownTest()
        {
            _applicationManager.LoginHelpers.Logout();
            _applicationManager.Stop();
        }
    }
}
