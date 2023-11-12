using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressbookWebTest.Tests.Contacts
{
    [TestFixture]
    public class ContactSearchTests :AuthTestBase
    {
        [Test]
        public void TestSearch()
        {
            Console.WriteLine(_applicationManager.Contact.GetNumberOfSearchResult());
        }
    }
}
