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
            _applicationManager.Navigation.GoToHomePage();
            InitNewContractCreation();
            FillContractForm(contact);
            SubmitContractCreation();
            ReturnContractPage();
            return this;
        }

        public ContactHelper Modify(int index, ContactData contact)
        {
            _applicationManager.Navigation.GoToHomePage();
            CheckAndCreate(index, contact);
            InitContactModification(index);
            FillContractForm(contact);
            SubmitContractModification();
            ReturnContractPage();
            return this;
        }

        public ContactHelper Remove(int index)
        {
            bool acceptNextAlert = true;
            _applicationManager.Navigation.GoToHomePage();
            CheckAndCreate(index, new ContactData("Test", "Testov"));
            SelectedContact(index);
            RemoveContact();
            Assert.IsTrue(Regex.IsMatch(_applicationManager.Alert.CloseAlertAndGetItsText(acceptNextAlert), "^Delete 1 addresses[\\s\\S]$"));
            ReturnContractPage();
            return this;
        }

        public ContactHelper CheckAndCreate(int index, ContactData newData)
        {
            if (!IsElementPresent(By.XPath($"//tr[@name='entry'][{index + 1}]/td[1]")))
            {
                Create(newData);
            }
            return this;
        }



        public ContactHelper InitNewContractCreation()
        {
            _applicationManager.Driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
        public ContactHelper SelectedContact(int index)
        {
            _applicationManager.Driver.FindElement(By.XPath($"//tr[@name='entry'][{index + 1}]/td[1]")).Click();
            return this;
        }

        public ContactHelper InitContactModification(int index)
        {
            _applicationManager.Driver.FindElement(By.XPath($"//tr[@name='entry'][{index + 1}]/td[8]")).Click();
            return this;
        }

        public ContactHelper FillContractForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("lastname"), contact.LastName);
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

        internal List<ContactData> GetContactList()
        {
            var contacts = new List<ContactData>();
            _applicationManager.Navigation.GoToHomePage();
            var elements = _driver.FindElements(By.XPath("//tr[@name='entry']"));
            foreach (var element in elements)
            {
                contacts.Add(new ContactData(element.Text.Split()));
            }
            return contacts;
        }
    }
}
