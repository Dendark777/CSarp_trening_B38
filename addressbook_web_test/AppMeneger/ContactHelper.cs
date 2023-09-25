using AddressbookWebTest;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace addressbook_web_test.AppMeneger
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager menager) : base(menager)
        {
        }

        public ContactHelper Create(ContactData contact)
        {
            _applicationManager.NavigationHelper.GoToHomePage();
            InitNewContractCreation();
            FillContractForm(contact);
            SubmitContractCreation();
            ReturnContractPage();
            return this;
        }

        public ContactHelper Modify(int index, ContactData contact)
        {
            _applicationManager.NavigationHelper.GoToHomePage();
            InitContactModification(index);
            FillContractForm(contact);
            SubmitContractModification();
            ReturnContractPage();
            return this;
        }

        public ContactHelper Remove(int index)
        {
            bool acceptNextAlert = true;
            _applicationManager.NavigationHelper.GoToHomePage();
            SelectedContact(index);
            RemoveContact();
            Assert.IsTrue(Regex.IsMatch(_applicationManager.AlertHelper.CloseAlertAndGetItsText(acceptNextAlert), "^Delete 1 addresses[\\s\\S]$"));
            ReturnContractPage();
            return this;
        }

        public ContactHelper InitNewContractCreation()
        {
            _applicationManager.Driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
        public ContactHelper SelectedContact(int index)
        {
            _applicationManager.Driver.FindElement(By.XPath($"//tr[@name='entry'][{index}]/td[1]")).Click();
            return this;
        }

        public ContactHelper InitContactModification(int index)
        {
            _applicationManager.Driver.FindElement(By.XPath($"//tr[@name='entry'][{index}]/td[8]")).Click();
            return this;
        }

        public ContactHelper FillContractForm(ContactData contact)
        {
            _applicationManager.Driver.FindElement(By.Name("firstname")).Click();
            _applicationManager.Driver.FindElement(By.Name("firstname")).Clear();
            _applicationManager.Driver.FindElement(By.Name("firstname")).SendKeys(contact.FirstName);
            _applicationManager.Driver.FindElement(By.Name("lastname")).Click();
            _applicationManager.Driver.FindElement(By.Name("lastname")).Clear();
            _applicationManager.Driver.FindElement(By.Name("lastname")).SendKeys(contact.LastName);
            return this;
        }

        public ContactHelper SubmitContractCreation()
        {
            _applicationManager.Driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            return this;
        }

        public ContactHelper SubmitContractModification()
        {
            _driver.FindElement(By.Name("update")).Click();
            return this;
        }
        public ContactHelper RemoveContact()
        {
            _driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        public ContactHelper ReturnContractPage()
        {
            _applicationManager.Driver.FindElement(By.LinkText("home")).Click();
            return this;
        }
    }
}
