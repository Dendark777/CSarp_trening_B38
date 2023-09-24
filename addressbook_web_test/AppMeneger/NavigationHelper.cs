using OpenQA.Selenium;

namespace AddressbookWebTest
{
    public class NavigationHelper : HelperBase
    {
        protected string _baseURL;

        public NavigationHelper(ApplicationManager manager) : base(manager)
        {
            _baseURL = manager.BaseURL;
        }

        public void GoToHomePage()
        {
            _driver.Navigate().GoToUrl(_baseURL);
        }

        public void GoToGroupsPage()
        {
            _driver.FindElement(By.LinkText("groups")).Click();
        }
    }
}
