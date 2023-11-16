using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisTests.AppManager
{
    public class NavigationHelper : HelperBase
    {
        public NavigationHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void OpenPage(string openUrl = @"http://localhost/mantisbt-2.26.0/login_page.php")
        {
            _applicationManager.Driver.Url = openUrl;
        }

        public void OpenRegistrationForm()
        {
            OpenPage();
            _driver.FindElement(By.ClassName("back-to-login-link")).Click();
        }


    }
}
