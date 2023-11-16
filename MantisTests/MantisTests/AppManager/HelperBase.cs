using MantisTests.AppManager;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace MantisTests.AppManager
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

        public void Type(By locator, string text)
        {
            if (text != null)
            {
                _driver.FindElement(locator).Clear();
                _driver.FindElement(locator).SendKeys(text);
            }
        }

        public bool IsElementPresent(By locator)
        {
            try
            {
                _driver.FindElement(locator);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        protected void SubmitConfirmForm(string nameButton)
        {
            _driver.FindElement(By.XPath($"//input[@value='{nameButton}']")).Click();
        }

        public void WaitMsgBox()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }
    }
}
