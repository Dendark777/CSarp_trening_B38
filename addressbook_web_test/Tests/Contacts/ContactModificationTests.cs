using NUnit.Framework;
namespace AddressbookWebTest.Tests.Contacts
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            var contact = new ContactData(firstName: "Ivan", lastName: "Ivanov");
            _applicationManager.ContactHelper.Modify(1,contact);
        }
    }
}
