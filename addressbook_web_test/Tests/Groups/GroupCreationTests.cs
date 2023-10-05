using NUnit.Framework;
using System.Collections.Generic;

namespace AddressbookWebTest.Tests.Groups
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            var group = new GroupData(name: "aaa", header: "ddd", footer: "fff");

            List<GroupData> oldGroupList = _applicationManager.Group.GetGroupList();

            _applicationManager.Group.Create(group);

            Assert.AreEqual(oldGroupList.Count + 1, _applicationManager.Group.GetGroupCount());

            List<GroupData> newGroupList = _applicationManager.Group.GetGroupList();
            oldGroupList.Add(group);
            oldGroupList.Sort();
            newGroupList.Sort();
            Assert.AreEqual(oldGroupList, newGroupList);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            var group = new GroupData(name: "", header: "", footer: "");

            List<GroupData> oldGroupList = _applicationManager.Group.GetGroupList();

            _applicationManager.Group.Create(group);

            Assert.AreEqual(oldGroupList.Count + 1, _applicationManager.Group.GetGroupCount());

            List<GroupData> newGroupList = _applicationManager.Group.GetGroupList();
            oldGroupList.Add(group);
            oldGroupList.Sort();
            newGroupList.Sort();
            Assert.AreEqual(oldGroupList, newGroupList);
        }

        [Test]
        public void BadGroupCreationTest()
        {
            var group = new GroupData(name: "a`a", header: "", footer: "");

            List<GroupData> oldGroupList = _applicationManager.Group.GetGroupList();

            _applicationManager.Group.Create(group);
            Assert.AreEqual(oldGroupList.Count + 1, _applicationManager.Group.GetGroupCount());

            List<GroupData> newGroupList = _applicationManager.Group.GetGroupList();
            oldGroupList.Add(group);
            oldGroupList.Sort();
            newGroupList.Sort();
            Assert.AreEqual(oldGroupList, newGroupList);
        }
    }
}
