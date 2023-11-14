
using NUnit.Framework;
using System.Collections.Generic;

namespace AddressbookWebTest.Tests
{
    public class GroupTestBase : AuthTestBase
    {
        [TearDown]
        public void CompareGroupsUI_DB()
        {
            if (PERFORM_LONG_UI_CHECKS)
            {
                return;
            }
            List<GroupData> fromUI = _applicationManager.Group.GetGroupList();
            List<GroupData> fromDB = GroupData.GetAll();

            fromUI.Sort();
            fromDB.Sort();
            Assert.AreEqual(fromUI, fromDB);

        }
    }
}
