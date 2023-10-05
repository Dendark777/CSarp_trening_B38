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
            List<ContactData> oldContactList = _applicationManager.Contact.GetContactList();

            var contact = new ContactData(firstName: "Ivan2", lastName: "Ivanov2");
            _applicationManager.Contact.CheckAndCreate(0, contact);

            _applicationManager.Contact.Modify(0, contact);

            List<ContactData> newContactList = _applicationManager.Contact.GetContactList();

            oldContactList[0] = contact;
            oldContactList.Sort();
            newContactList.Sort();
            Assert.AreEqual(oldContactList, newContactList);
        }
    }
}
