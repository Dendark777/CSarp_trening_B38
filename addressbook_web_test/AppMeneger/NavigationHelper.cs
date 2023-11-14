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
            if (_driver.Url == $"{_baseURL}")
            {
                return;
            }
            _driver.Navigate().GoToUrl(_baseURL);
        }

        public void GoToGroupContactList(string groupId)
        {
            if (_driver.Url == $"{_baseURL}")
            {
                return;
            }
            _driver.Navigate().GoToUrl($"{_baseURL}/?group={groupId}");
        }

        public void GoToGroupsPage()
        {
            if (_driver.Url == $"{_baseURL}/group.php" &&
                IsElementPresent(By.Name("New")))
            {
                return;
            }
            _driver.FindElement(By.LinkText("groups")).Click();
        }
    }
}
