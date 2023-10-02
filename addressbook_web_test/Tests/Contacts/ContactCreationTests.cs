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
        [Test]
        public void ContactCreationTest()
        {
            List<ContactData> oldContactList = _applicationManager.Contact.GetContactList();

            var contact = new ContactData(firstName: "Ivan", lastName: "Ivanov");

            _applicationManager.Contact.Create(contact);
            List<ContactData> newContactList = _applicationManager.Contact.GetContactList();

            oldContactList.Add(contact);
            oldContactList.Sort();
            newContactList.Sort();
            Assert.AreEqual(oldContactList, newContactList);

        }
    }
}
