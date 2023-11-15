using AddressBookTestsAutoit.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AddressBookTestsAutoit.Tests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            List<GroupData> oldGroups = _applicationManger.Groups.GetGroupsList();
            GroupData newGroup = new GroupData { Name = "ZZZ1" };

            _applicationManger.Groups.Add(newGroup);

            List<GroupData> newGroups = _applicationManger.Groups.GetGroupsList();
            oldGroups.Add(newGroup);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
