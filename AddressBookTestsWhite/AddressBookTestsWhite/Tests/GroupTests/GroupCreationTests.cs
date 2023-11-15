using AddressBookTestsWhite.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AddressBookTestsWhite.Tests.GroupTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            List<GroupData> oldGroups = _applicationManger.Groups.GetGroupsList();
            GroupData newGroup = new GroupData { Name = "White" };

            _applicationManger.Groups.Add(newGroup);

            List<GroupData> newGroups = _applicationManger.Groups.GetGroupsList();
            oldGroups.Add(newGroup);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
