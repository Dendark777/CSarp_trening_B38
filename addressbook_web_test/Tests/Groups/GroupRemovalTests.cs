using NUnit.Framework;
using System.Collections.Generic;

namespace AddressbookWebTest.Tests.Groups
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            List<GroupData> oldGroupList = _applicationManager.Group.GetGroupList();

            _applicationManager.Group.Remove(0);
            var t = _applicationManager.Group.GetGroupCount();
            _applicationManager.Group.CheckAndCreate(0, new GroupData("TTT"));

            Assert.AreEqual(oldGroupList.Count - 1, t);

            List<GroupData> newGroupList = _applicationManager.Group.GetGroupList();

            var toBeRemoved = oldGroupList[0];
            oldGroupList.RemoveAt(0);

            Assert.AreEqual(oldGroupList, newGroupList);

            foreach(var group in newGroupList)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}
