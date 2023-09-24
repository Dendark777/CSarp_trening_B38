using NUnit.Framework;

namespace AddressbookWebTest.Tests.Groups
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            var newData = new GroupData(name: "zzz", header: "ttt", footer: "qqq");
            _applicationManager.GroupHelper.Modify(1, newData);
        }
    }
}
