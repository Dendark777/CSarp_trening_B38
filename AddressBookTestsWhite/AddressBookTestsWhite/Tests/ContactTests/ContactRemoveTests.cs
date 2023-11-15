using AddressBookTestsWhite.ApplicationManаgers;
using AddressBookTestsWhite.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookTestsWhite.Tests.ContactTests
{
    [TestFixture]
    public class ContactRemoveTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            List<ContactData> oldContacts = _applicationManger.Contacts.GetContactsList();

            _applicationManger.Contacts.Remove(0);

            List<ContactData> newContacts = _applicationManger.Contacts.GetContactsList();
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
