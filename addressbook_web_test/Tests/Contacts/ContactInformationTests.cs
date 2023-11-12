using NUnit.Framework;
using System.Linq;

namespace AddressbookWebTest.Tests.Contacts
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            ContactData fromForm = _applicationManager.Contact.GetContactInformationFromEditForm(0);
            ContactData fromTable = _applicationManager.Contact.GetContactInformationFromTable(0);

            //verification
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }

        [Test]
        public void TestContactDetailInformation()
        {
            ContactData fromForm = _applicationManager.Contact.GetContactInformationFromEditForm(0);
            ContactData fromDetail = _applicationManager.Contact.GetContactInformationFromDetail(0);

            //verification
            Assert.AreEqual(fromForm.FullName, fromDetail.FullName);
            Assert.True(fromForm.DetailInforamtion.SequenceEqual(fromDetail.DetailInforamtion));
        }
    }
}
