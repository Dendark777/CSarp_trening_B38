using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressbookWebTest.Tests.Contacts
{
    [TestFixture]
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void AddingContactToGroupTest()
        {
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> contactsOldList = group.GetContacts();
            ContactData contact = ContactData.GetAll().Except(contactsOldList).First();

            _applicationManager.Contact.AddContactToGroup(contact, group);

            List<ContactData> contactsNewList = group.GetContacts();
            contactsOldList.Add(contact);
            contactsNewList.Sort();
            contactsOldList.Sort();

            Assert.AreEqual(contactsOldList, contactsNewList);

        }
    }
}
