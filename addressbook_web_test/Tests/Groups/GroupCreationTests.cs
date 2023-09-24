using NUnit.Framework;

namespace AddressbookWebTest.Tests.Groups
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            var group = new GroupData(name: "aaa", header: "ddd", footer: "fff");

            _applicationManager.GroupHelper.Create(group);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            var group = new GroupData(name: "", header: "", footer: "");

            _applicationManager.GroupHelper.Create(group);
        }
    }
}
