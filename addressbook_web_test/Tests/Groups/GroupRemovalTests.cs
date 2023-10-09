using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AddressbookWebTest.Tests.Groups
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            List<GroupData> oldGroupList = _applicationManager.Group.GetGroupList();
            _applicationManager.Group.CheckAndCreate(0, new GroupData("TTT"));

            _applicationManager.Group.Remove(0);
            var t = _applicationManager.Group.GetGroupCount();

            Assert.AreEqual(Math.Max(oldGroupList.Count - 1, 0), t);

            List<GroupData> newGroupList = _applicationManager.Group.GetGroupList();

            if (oldGroupList.Any())
            {
                var toBeRemoved = oldGroupList[0];
                oldGroupList.RemoveAt(0);
                foreach (var group in newGroupList)
                {
                    Assert.AreNotEqual(group.Id, toBeRemoved.Id);
                }
            }

            Assert.AreEqual(oldGroupList, newGroupList);


        }
    }
}
