using MantisTests.Models;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace MantisTests.AppManager
{
    public class AccountHelper : HelperBase
    {
        public AccountHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void Register(AccountData account)
        {
            _applicationManager.Navigation.OpenRegistrationForm();
            FillRegistrationForm(account);
            SubmitRegistration();
            string url = GetConfirmationUrl(account);
            FillPasswordForm(url, account);
            SubmitPasswordForm();
        }
        
        public void Login(AccountData account)
        {
            _applicationManager.Navigation.OpenPage();
            FillLoginForm(account);
        }

        public bool CheckAccount(AccountData account)
        {
            try
            {
                Login(new AccountData
                {
                    Name = "administrator",
                    Password="root"
                });
                _applicationManager.Navigation.OpenPage($"{_applicationManager.BaseURL}/manage_user_page.php");

                var tBody = _driver.FindElement(By.XPath("//div[@id='main-container']/div[2]/div[2]/div/div/div[4]/div[2]/div[2]/div/table/tbody"));
                var rows = tBody.FindElements(By.TagName("tr"));
                List<string> names = new List<string>();
                foreach (var row in rows)
                {
                    var cell = row.FindElements(By.TagName("td"))[0];
                    names.Add(cell.Text);
                }
                return names.Contains(account.Name);
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private void FillLoginForm(AccountData account)
        {
            _driver.FindElement(By.Id("username")).SendKeys(account.Name);
            _driver.FindElement(By.ClassName("btn-success")).Click();
            _driver.FindElement(By.Name("password")).SendKeys(account.Password);
            _driver.FindElement(By.ClassName("btn-success")).Click();
        }

        private void SubmitPasswordForm()
        {
            _driver.FindElement(By.ClassName("btn")).Click();
        }

        private void FillPasswordForm(string url, AccountData account)
        {
            _applicationManager.Navigation.OpenPage(url);
            _driver.FindElement(By.Name("password")).SendKeys(account.Password);
            _driver.FindElement(By.Name("password_confirm")).SendKeys(account.Password);
        }

        private string GetConfirmationUrl(AccountData account)
        {
            string message = _applicationManager.Mail.GetLastMail(account);
            var match = Regex.Match(message, @"http://\S*");
            return match.Value;
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
