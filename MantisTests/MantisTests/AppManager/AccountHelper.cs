using MantisTests.Models;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace MantisTests.AppManager
{
    public class RegistrationHelper : HelperBase
    {
        public RegistrationHelper(ApplicationManager manager) : base(manager)
        {
        }

        internal void Register(AccountData account)
        {
            OpenMainPage();
            OpenRegistrationForm();
            FillRegistrationForm(account);
            SubmitRegistration();
            string url = GetConfirmationUrl(account);
            FillPasswordForm(url, account);
            SubmitPasswordForm();
        }

        private void SubmitPasswordForm()
        {
            _driver.FindElement(By.ClassName("btn")).Click();
        }

        private void FillPasswordForm(string url, AccountData account)
        {
            _driver.Url = url;
            _driver.FindElement(By.Name("password")).SendKeys(account.Password);
            _driver.FindElement(By.Name("password_confirm")).SendKeys(account.Password);
        }

        private string GetConfirmationUrl(AccountData account)
        {
            string message = _applicationManager.Mail.GetLastMail(account);
            var match = Regex.Match(message, @"http://\S*");
            return match.Value;
        }

        private void OpenMainPage()
        {
            _applicationManager.Driver.Url = @"http://localhost/mantisbt-2.2.0/login_page.php";

        }

        private void OpenRegistrationForm()
        {
            _driver.FindElement(By.ClassName("back-to-login-link")).Click();
        }


        private void FillRegistrationForm(AccountData account)
        {
            _driver.FindElement(By.Name("username")).SendKeys(account.Name);
            _driver.FindElement(By.Name("email")).SendKeys(account.Email);

        }

        private void SubmitRegistration()
        {
            _driver.FindElement(By.CssSelector("input.btn")).Click();
        }
    }
}
