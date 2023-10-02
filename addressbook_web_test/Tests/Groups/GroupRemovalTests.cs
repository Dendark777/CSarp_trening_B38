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

            List<GroupData> newGroupList = _applicationManager.Group.GetGroupList();
            newGroupList.RemoveAt(0);
            oldGroupList.Sort();
            newGroupList.Sort();
            Assert.AreEqual(oldGroupList, newGroupList);
        }
    }
}
