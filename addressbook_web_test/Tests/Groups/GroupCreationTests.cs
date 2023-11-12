using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AddressbookWebTest.Tests.Groups
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void GroupCreationTest(GroupData group)
        {
            List<GroupData> oldGroupList = _applicationManager.Group.GetGroupList();

            _applicationManager.Group.Create(group);

            Assert.AreEqual(oldGroupList.Count + 1, _applicationManager.Group.GetGroupCount());

            List<GroupData> newGroupList = _applicationManager.Group.GetGroupList();
            oldGroupList.Add(group);
            oldGroupList.Sort();
            newGroupList.Sort();
            Assert.AreEqual(oldGroupList, newGroupList);
        }

        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }
            return groups;
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
