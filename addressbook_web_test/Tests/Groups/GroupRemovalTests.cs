using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AddressbookWebTest.Tests.Groups
{
    [TestFixture]
    public class GroupRemovalTests : GroupTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            List<GroupData> oldGroupList = GroupData.GetAll();
            _applicationManager.Group.CheckAndCreate(0, new GroupData("TTT"));

            GroupData toBeRemoved = oldGroupList[0];
            _applicationManager.Group.Remove(toBeRemoved);
            var t = GroupData.GetAll();

            Assert.AreEqual(Math.Max(oldGroupList.Count - 1, 0), t.Count);

            List<GroupData> newGroupList = GroupData.GetAll();

            if (oldGroupList.Any())
            {
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
