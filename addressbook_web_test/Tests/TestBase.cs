using NUnit.Framework;

namespace AddressbookWebTest.Tests
{
    public class TestBase
    {
        protected ApplicationManager _applicationManager;

        [SetUp]
        public void SetupApplicationManager()
        {
            _applicationManager = ApplicationManager.GetInstance();
        }
    }
}
