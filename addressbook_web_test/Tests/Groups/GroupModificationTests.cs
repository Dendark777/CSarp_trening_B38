using NUnit.Framework;
using System.Collections.Generic;

namespace AddressbookWebTest.Tests.Groups
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            var newData = new GroupData(name: "zzz", header: "ttt", footer: "qqq");
            List<GroupData> oldGroupList = _applicationManager.Group.GetGroupList();

            _applicationManager.Group.Modify(0, newData);

            List<GroupData> newGroupList = _applicationManager.Group.GetGroupList();
            oldGroupList[0] = newData;
            oldGroupList.Sort();
            newGroupList.Sort();

            Assert.AreEqual(oldGroupList, newGroupList);
        }
        [Test]
        public void GroupModificationTestHeaderNull()
        {
            var newData = new GroupData(name: "zzz1", header: null, footer: "qqq1");

            List<GroupData> oldGroupList = _applicationManager.Group.GetGroupList();

            _applicationManager.Group.Modify(0, newData);

            List<GroupData> newGroupList = _applicationManager.Group.GetGroupList();
            oldGroupList[0] = newData;
            oldGroupList.Sort();
            newGroupList.Sort();

            Assert.AreEqual(oldGroupList, newGroupList);
        }
    }
}
