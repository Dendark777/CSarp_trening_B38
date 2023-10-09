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
            _applicationManager.Group.CheckAndCreate(0, newData);

            List<GroupData> oldGroupList = _applicationManager.Group.GetGroupList();
            var oldData = oldGroupList[0];

            _applicationManager.Group.Modify(0, newData);
            Assert.AreEqual(oldGroupList.Count, _applicationManager.Group.GetGroupCount());

            List<GroupData> newGroupList = _applicationManager.Group.GetGroupList();
            oldGroupList[0] = newData;
            oldGroupList.Sort();
            newGroupList.Sort();

            Assert.AreEqual(oldGroupList, newGroupList);

            foreach (var group in newGroupList)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }
        [Test]
        public void GroupModificationTestHeaderNull()
        {
            var newData = new GroupData(name: "zzz1", header: null, footer: "qqq1");
            _applicationManager.Group.CheckAndCreate(0, newData);

            List<GroupData> oldGroupList = _applicationManager.Group.GetGroupList();
            var oldData = oldGroupList[0];

            _applicationManager.Group.Modify(0, newData);
            Assert.AreEqual(oldGroupList.Count, _applicationManager.Group.GetGroupCount());

            List<GroupData> newGroupList = _applicationManager.Group.GetGroupList();
            oldGroupList[0] = newData;
            oldGroupList.Sort();
            newGroupList.Sort();

            Assert.AreEqual(oldGroupList, newGroupList);

            foreach (var group in newGroupList)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }
    }
}
