using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressbookWebTest.Tests.Contacts
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            List<ContactData> oldContactList = ContactData.GetAll();
            _applicationManager.Contact.CheckAndCreate(0, new ContactData(firstName: "Ivan2", lastName: "Ivanov2"));
            ContactData toDelContact = oldContactList[0];
            _applicationManager.Contact.Remove(toDelContact);

            List<ContactData> newContactList = ContactData.GetAll();
            if (oldContactList.Any())
            {
                oldContactList.RemoveAt(0);
            }
            oldContactList.Sort();
            newContactList.Sort();
            Assert.AreEqual(oldContactList, newContactList);
        }
    }
}
