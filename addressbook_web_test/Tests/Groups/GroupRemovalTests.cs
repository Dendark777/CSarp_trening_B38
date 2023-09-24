using NUnit.Framework;

namespace AddressbookWebTest.Tests.Groups
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            _applicationManager.GroupHelper.Remove(1);
        }
    }
}
