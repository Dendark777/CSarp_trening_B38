using OpenQA.Selenium;

namespace AddressbookWebTest
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void Login(AccountData account)
        {
            _driver.FindElement(By.Name("user")).Click();
            _driver.FindElement(By.Name("user")).Clear();
            _driver.FindElement(By.Name("user")).SendKeys(account.UserName);
            _driver.FindElement(By.Id("LoginForm")).Click();
            _driver.FindElement(By.Name("pass")).Click();
            _driver.FindElement(By.Name("pass")).Clear();
            _driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            _driver.FindElement(By.Id("LoginForm")).Click();
            _driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        public void Logout()
        {
            _driver.FindElement(By.LinkText("Logout")).Click();
        }
    }
}
