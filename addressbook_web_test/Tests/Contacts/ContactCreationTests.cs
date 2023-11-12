using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressbookWebTest.Tests.Contacts
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test, TestCaseSource("RandomContactDataProvider")]
        public void ContactCreationTest(ContactData contact)
        {
            List<ContactData> oldContactList = _applicationManager.Contact.GetContactList();

            _applicationManager.Contact.Create(contact);
            List<ContactData> newContactList = _applicationManager.Contact.GetContactList();

            oldContactList.Add(contact);
            oldContactList.Sort();
            newContactList.Sort();
            Assert.AreEqual(oldContactList, newContactList);

        }
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30))
                {
                    Company = GenerateRandomString(100),
                    Address = GenerateRandomString(100)
                });
            }
            return contacts;
        }

        [Test]
        public void ContactCreationTestNoParameter()
        {
            List<ContactData> oldContactList = _applicationManager.Contact.GetContactList();
            ContactData contact = new ContactData(GenerateRandomString(30), GenerateRandomString(30))
            {
                Company = GenerateRandomString(100),
                Address = GenerateRandomString(100)
            };
            _applicationManager.Contact.Create(contact);
            List<ContactData> newContactList = _applicationManager.Contact.GetContactList();

            oldContactList.Add(contact);
            oldContactList.Sort();
            newContactList.Sort();
            Assert.AreEqual(oldContactList, newContactList);

        }
    }
}
