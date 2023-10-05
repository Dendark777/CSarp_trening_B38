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
            List<ContactData> oldContactList = _applicationManager.Contact.GetContactList();
            _applicationManager.Contact.CheckAndCreate(0, new ContactData(firstName: "Ivan2", lastName: "Ivanov2"));
            _applicationManager.Contact.Remove(0);

            List<ContactData> newContactList = _applicationManager.Contact.GetContactList();

            oldContactList.RemoveAt(0);
            oldContactList.Sort();
            newContactList.Sort();
            Assert.AreEqual(oldContactList, newContactList);
        }
    }
}
