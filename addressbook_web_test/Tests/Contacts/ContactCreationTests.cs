using addressbook_web_test.Tests.Contacts;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Text;

namespace AddressbookWebTest.Tests.Contacts
{
    [TestFixture]
    public class ContactCreationTests : ContactBaseTest
    {
        [Test]
        public void ContactCreationTest()
        {
            InitNewContractCreation();
            FillContractForm(new ContactData(firstName: "Ivan1", lastName: "Ivanov1"));
            SubmitContractCreation();
            ReturnContractPage();
        }
    }
}
