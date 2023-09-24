using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;

namespace AddressbookWebTest
{
    public class ApplicationManager
    {
        protected string baseURL;
        protected IWebDriver driver;

        public LoginHelper LoginHelpers { get; private set; }
        public NavigationHelper NavigationHelper { get; private set; }
        public GroupHelper GroupHelper { get; private set; }
        public IWebDriver Driver { get { return driver; } }
        public String BaseURL { get { return baseURL; } }
        public ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook";

            LoginHelpers = new LoginHelper(this);
            NavigationHelper = new NavigationHelper(this);
            GroupHelper = new GroupHelper(this);
        }

        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
    }
}
