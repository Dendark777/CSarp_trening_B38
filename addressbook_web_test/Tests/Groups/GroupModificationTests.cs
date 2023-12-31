﻿using NUnit.Framework;
using System.Collections.Generic;

namespace AddressbookWebTest.Tests.Groups
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            var newData = new GroupData(name: "zzz", header: "ttt", footer: "qqq");
            _applicationManager.Group.CheckAndCreate(0, newData);

            List<GroupData> oldGroupList = GroupData.GetAll();

            var oldData = oldGroupList[0];

            _applicationManager.Group.Modify(oldData.Id, newData);
            Assert.AreEqual(oldGroupList.Count, _applicationManager.Group.GetGroupCount());

            List<GroupData> newGroupList = GroupData.GetAll();
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

            List<GroupData> oldGroupList = GroupData.GetAll();
            var oldData = oldGroupList[0];

            _applicationManager.Group.Modify(oldData.Id, newData);

            Assert.AreEqual(oldGroupList.Count, _applicationManager.Group.GetGroupCount());

            List<GroupData> newGroupList = GroupData.GetAll();
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
