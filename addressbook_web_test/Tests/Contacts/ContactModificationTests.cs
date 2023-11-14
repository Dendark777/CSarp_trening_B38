using NUnit.Framework;
using System.Collections.Generic;

namespace AddressbookWebTest.Tests.Contacts
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {

            var newContact = new ContactData(firstName: "Ivan2", lastName: "Ivanov2");
            _applicationManager.Contact.CheckAndCreate(0, newContact);

            List<ContactData> oldContactList = ContactData.GetAll();
            var oldContact = oldContactList[0];
            _applicationManager.Contact.Modify(oldContact, newContact);

            List<ContactData> newContactList = ContactData.GetAll();

            oldContactList[0] = newContact;
            oldContactList.Sort();
            newContactList.Sort();
            Assert.AreEqual(oldContactList, newContactList);
        }
    }
}
