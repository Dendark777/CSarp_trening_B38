using NUnit.Framework;
namespace AddressbookWebTest.Tests.Contacts
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            var contact = new ContactData(firstName: "Ivan2", lastName: "Ivanov2");
            _applicationManager.Contact.Modify(1,contact);
        }
    }
}
