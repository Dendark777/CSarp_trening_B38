using NUnit.Framework;

namespace AddressbookWebTest.Tests.Groups
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            var newData = new GroupData(name: "zzz", header: "ttt", footer: "qqq");
            _applicationManager.Group.Modify(1, newData);
        }
        [Test]
        public void GroupModificationTestHeaderNull()
        {
            var newData = new GroupData(name: "zzz1", header: null, footer: "qqq1");
            _applicationManager.Group.Modify(1, newData);
        }
    }
}
