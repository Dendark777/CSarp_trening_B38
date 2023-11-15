using AddressBookTestsWhite.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AddressBookTestsWhite.Tests.ContactTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            List<ContactData> oldContacts = _applicationManger.Contacts.GetContactsList();
            ContactData newContact = new ContactData()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = GenerateRandomString(20),
                LastName = GenerateRandomString(20),
                City = GenerateRandomString(20),
                Company = GenerateRandomString(100),
                Address = GenerateRandomString(100)
            };

            _applicationManger.Contacts.Add(newContact);

            List<ContactData> newContacts = _applicationManger.Contacts.GetContactsList();
            oldContacts.Add(newContact);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
        }

    }
}
