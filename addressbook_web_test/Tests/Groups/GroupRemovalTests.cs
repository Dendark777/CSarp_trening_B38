using NUnit.Framework;

namespace AddressbookWebTest.Tests.Groups
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            _applicationManager.Group.Remove(1);
        }
    }
}
