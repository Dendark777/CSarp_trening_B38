using AddressbookWebTest;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_test.Tests.Contacts
{
    public class ContactBaseTest : TestBase
    {

        public void OpenHomePage()
        {
            _applicationManager.Driver.Navigate().GoToUrl(_applicationManager.BaseURL);
        }

        public void Login(AccountData account)
        {
            _applicationManager.Driver.FindElement(By.Name("user")).Click();
            _applicationManager.Driver.FindElement(By.Name("user")).Clear();
            _applicationManager.Driver.FindElement(By.Name("user")).SendKeys(account.UserName);
            _applicationManager.Driver.FindElement(By.Id("LoginForm")).Click();
            _applicationManager.Driver.FindElement(By.Name("pass")).Click();
            _applicationManager.Driver.FindElement(By.Name("pass")).Clear();
            _applicationManager.Driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            _applicationManager.Driver.FindElement(By.Id("LoginForm")).Click();
            _applicationManager.Driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        public void InitNewContractCreation()
        {
            _applicationManager.Driver.FindElement(By.LinkText("add new")).Click();
        }

        public void FillContractForm(ContactData contact)
        {
            _applicationManager.Driver.FindElement(By.Name("firstname")).Click();
            _applicationManager.Driver.FindElement(By.Name("firstname")).Clear();
            _applicationManager.Driver.FindElement(By.Name("firstname")).SendKeys(contact.FirstName);
            _applicationManager.Driver.FindElement(By.Name("lastname")).Click();
            _applicationManager.Driver.FindElement(By.Name("lastname")).Clear();
            _applicationManager.Driver.FindElement(By.Name("lastname")).SendKeys(contact.LastName);
        }

        public void SubmitContractCreation()
        {
            _applicationManager.Driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
        }

        public void ReturnContractPage()
        {
            _applicationManager.Driver.FindElement(By.LinkText("home")).Click();
        }

        public void Logout()
        {
            _applicationManager.Driver.FindElement(By.LinkText("Logout")).Click();
        }

    }
}
