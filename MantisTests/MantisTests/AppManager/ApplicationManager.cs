using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Threading;

namespace MantisTests.AppManager
{
    public class ApplicationManager
    {
        protected string baseURL;
        protected IWebDriver driver;

        public IWebDriver Driver { get { return driver; } }
        public string BaseURL { get { return baseURL; } }

        private static ThreadLocal<ApplicationManager> _instance = new ThreadLocal<ApplicationManager>();
        public AccountHelper Account { get; private set; }
        public FtpHelper Ftp { get; private set; }
        public JamesHelper James { get; private set; }
        public MailHelper Mail { get; private set; }
        public NavigationHelper Navigation { get; private set; }
        public TaskHelper Tasks { get; private set; }
        internal ProjectHelper Projects { get; private set; }

        public static ApplicationManager GetInstance()
        {
            if (!_instance.IsValueCreated)
            {
                var newInstance = new ApplicationManager();
                newInstance.driver.Url = "http://localhost/mantisbt-2.26.0/login_page.php";
                _instance.Value = newInstance;
            }
            return _instance.Value;
        }

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/mantisbt-2.26.0";
            Account = new AccountHelper(this);
            Ftp = new FtpHelper(this);
            James = new JamesHelper(this);
            Mail = new MailHelper(this);
            Navigation = new NavigationHelper(this);
            Tasks = new TaskHelper(this);
            Projects = new ProjectHelper(this);
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
