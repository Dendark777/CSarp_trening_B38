using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Text;

namespace AddressbookWebTest.Tests.Contacts
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            var contact = new ContactData(firstName: "Ivan", lastName: "Ivanov");
            _applicationManager.ContactHelper.Create(contact);
        }
    }
}
