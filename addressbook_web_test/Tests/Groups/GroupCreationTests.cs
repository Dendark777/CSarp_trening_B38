using NUnit.Framework;

namespace AddressbookWebTest.Tests.Groups
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            var group = new GroupData(name: "aaa", header: "ddd", footer: "fff");

            _applicationManager.Group.Create(group);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            var group = new GroupData(name: "", header: "", footer: "");

            _applicationManager.Group.Create(group);
        }
    }
}
