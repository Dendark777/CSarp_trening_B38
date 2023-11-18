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
            Login(account);
            return IsElementPresent(By.LinkText("Создать задачу"));
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
