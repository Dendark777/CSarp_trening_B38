using OpenQA.Selenium;

namespace AddressbookWebTest
{
    public class HelperBase
    {
        protected IWebDriver _driver;
        protected ApplicationManager _applicationManager;
        public HelperBase(ApplicationManager manager)
        {
            _applicationManager = manager;
            _driver = manager.Driver;
        }
    }
}
