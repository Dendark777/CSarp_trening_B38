using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressbookWebTest.Tests.Contacts
{
    [TestFixture]
    public class DeletingContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void DeletingContactFromGroupTest()
        {
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> contactsOldList = group.GetContacts();
            ContactData contact = group.GetContacts()[0];

            _applicationManager.Contact.RemoveContactFromGroup(contact, group);

            List<ContactData> contactsNewList = group.GetContacts();
            contactsOldList.Remove(contact);
            contactsNewList.Sort();
            contactsOldList.Sort();

            Assert.AreEqual(contactsOldList, contactsNewList);

        }
    }
}
