using AddressBookTestsWhite.ApplicationManаgers;
using AddressBookTestsWhite.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookTestsWhite.Tests.GroupTests
{
    [TestFixture]
    public class GroupRemoveTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            List<GroupData> oldGroups = _applicationManger.Groups.GetGroupsList();

            _applicationManger.Groups.Remove(0);

            List<GroupData> newGroups = _applicationManger.Groups.GetGroupsList();
            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
