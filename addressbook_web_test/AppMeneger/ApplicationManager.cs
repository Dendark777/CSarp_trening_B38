using addressbook_web_test.AppMeneger;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Threading;

namespace AddressbookWebTest
{
    public class ApplicationManager
    {
        protected string baseURL;
        protected IWebDriver driver;

        public LoginHelper Login { get; private set; }
        public NavigationHelper Navigation { get; private set; }
        public GroupHelper Group { get; private set; }
        public ContactHelper Contact { get; private set; }
        public AlertHelper Alert { get; private set; }
        public IWebDriver Driver { get { return driver; } }
        public String BaseURL { get { return baseURL; } }

        private static  ThreadLocal<ApplicationManager> _instance = new ThreadLocal<ApplicationManager>();


        public static ApplicationManager GetInstance()
        {
            if (!_instance.IsValueCreated)
            {
                var newInstance = new ApplicationManager();
                newInstance.Navigation.GoToHomePage();
                _instance.Value = newInstance;
            }
            return _instance.Value;
        }

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook";

            Login = new LoginHelper(this);
            Navigation = new NavigationHelper(this);
            Group = new GroupHelper(this);
            Contact = new ContactHelper(this);
            Alert = new AlertHelper(this);
        }
        ~ApplicationManager()
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
