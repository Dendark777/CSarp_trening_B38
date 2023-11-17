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
            var groups = GroupData.GetAll();
            if (!groups.Any())
            {
                _applicationManager.Group.Create(new GroupData
                {
                    Name = "Test",
                    Footer = "Test",
                    Header = "Test",
                });
            }
            List<ContactData> allContactList = ContactData.GetAll();
            if (!allContactList.Any())
            {
                _applicationManager.Contact.Create(new ContactData(firstName: "Ivan2", lastName: "Ivanov2"));
            }
            GroupData group = groups[0];
            List<ContactData> contactsOldList = group.GetContacts();
            ContactData contact;
            if (!contactsOldList.Any())
            {
                _applicationManager.Contact.Create(new ContactData(firstName: "Ivan3", lastName: "Ivanov3"));
                allContactList = ContactData.GetAll();
                contact = allContactList[0];
                _applicationManager.Contact.AddContactToGroup(contact, group);
                contactsOldList = group.GetContacts();
            }
            contact = contactsOldList[0];

            _applicationManager.Contact.RemoveContactFromGroup(contact, group);

            List<ContactData> contactsNewList = group.GetContacts();
            contactsOldList.Remove(contact);
            contactsNewList.Sort();
            contactsOldList.Sort();

            Assert.AreEqual(contactsOldList, contactsNewList);

        }
    }
}
