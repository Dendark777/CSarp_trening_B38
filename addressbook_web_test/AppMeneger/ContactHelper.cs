using AddressbookWebTest;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace addressbook_web_test.AppMeneger
{
    public class ContactHelper : HelperBase
    {
        List<ContactData> _contacts = null;
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
            SelectedContact(index);
            RemoveContact();
            Assert.IsTrue(Regex.IsMatch(_applicationManager.Alert.CloseAlertAndGetItsText(acceptNextAlert), "^Delete 1 addresses[\\s\\S]$"));
            ReturnContractPage();
            return this;
        }

        public ContactHelper CheckAndCreate(int index, ContactData newData)
        {
            _applicationManager.Navigation.GoToHomePage();
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
        public ContactHelper ContactDetail(int index)
        {
            _applicationManager.Driver.FindElement(By.XPath($"//tr[@name='entry'][{index + 1}]/td[7]")).Click();
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
            _contacts = null;
            return this;
        }

        public ContactHelper SubmitContractModification()
        {
            _driver.FindElement(By.Name("update")).Click();
            _contacts = null;
            return this;
        }
        public ContactHelper RemoveContact()
        {
            _driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            _contacts = null;
            return this;
        }

        public ContactHelper ReturnContractPage()
        {
            _applicationManager.Driver.FindElement(By.LinkText("home")).Click();
            return this;
        }

        internal List<ContactData> GetContactList()
        {
            if (_contacts != null)
            {
                return _contacts;
            }
            _contacts = new List<ContactData>();
            _applicationManager.Navigation.GoToHomePage();
            var elements = _driver.FindElements(By.XPath("//tr[@name='entry']"));
            for (int i = 0; i < elements.Count; i++)
            {
                var firstName = _driver.FindElement(By.XPath($"//tr[@name='entry'][{i + 1}]/td[3]")).Text;
                var lastName = _driver.FindElement(By.XPath($"//tr[@name='entry'][{i + 1}]/td[2]")).Text;
                _contacts.Add(new ContactData(firstName, lastName));
            }
            return new List<ContactData>(_contacts);
        }


        public ContactData GetContactInformationFromTable(int index)
        {
            _applicationManager.Navigation.GoToHomePage();
            IList<IWebElement> cells = _driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allPhones = cells[5].Text;
            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
            };
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            _applicationManager.Navigation.GoToHomePage();
            InitContactModification(index);
            string firstName = _driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = _driver.FindElement(By.Name("lastname")).GetAttribute("value");
            return new ContactData(firstName, lastName)
            {
                MiddleName = _driver.FindElement(By.Name("middlename")).GetAttribute("value"),
                Nickname = _driver.FindElement(By.Name("nickname")).GetAttribute("value"),
                Company = _driver.FindElement(By.Name("company")).GetAttribute("value"),
                Title = _driver.FindElement(By.Name("title")).GetAttribute("value"),
                Address = _driver.FindElement(By.Name("address")).GetAttribute("value"),
                Home = _driver.FindElement(By.Name("home")).GetAttribute("value"),
                Mobile = _driver.FindElement(By.Name("mobile")).GetAttribute("value"),
                Work = _driver.FindElement(By.Name("work")).GetAttribute("value"),
                Fax = _driver.FindElement(By.Name("fax")).GetAttribute("value"),
                Email = _driver.FindElement(By.Name("email")).GetAttribute("value"),
                Email2 = _driver.FindElement(By.Name("email2")).GetAttribute("value"),
                Email3 = _driver.FindElement(By.Name("email3")).GetAttribute("value"),
                Homepage = _driver.FindElement(By.Name("homepage")).GetAttribute("value"),
                BDay = _driver.FindElement(By.Name("bday")).GetAttribute("value"),
                BMonth = _driver.FindElement(By.Name("bmonth")).GetAttribute("value"),
                BYear = _driver.FindElement(By.Name("byear")).GetAttribute("value"),
                ADay = _driver.FindElement(By.Name("aday")).GetAttribute("value"),
                AMonth = _driver.FindElement(By.Name("amonth")).GetAttribute("value"),
                AYear = _driver.FindElement(By.Name("ayear")).GetAttribute("value"),
                SecondaryAddress = _driver.FindElement(By.Name("address2")).GetAttribute("value"),
                SecondaryHome = _driver.FindElement(By.Name("phone2")).GetAttribute("value"),
                SecondaryNotes = _driver.FindElement(By.Name("notes")).GetAttribute("value")
            };
        }
        public ContactData GetContactInformationFromDetail(int index)
        {
            _applicationManager.Navigation.GoToHomePage();
            ContactDetail(index);
            var content = _driver.FindElement(By.Id("content"));
            var detailContact = content.Text.Split('\r', '\n');
            string fullName = content.FindElement(By.TagName("b")).Text;
            var contact = new ContactData()
            {
                FullName = fullName,
                DetailInforamtion = detailContact,
            };
            return contact;
        }

        public int GetNumberOfSearchResult()
        {
            _applicationManager.Navigation.GoToHomePage();
            string text = _driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return int.Parse(m.Value);
        }

    }
}
