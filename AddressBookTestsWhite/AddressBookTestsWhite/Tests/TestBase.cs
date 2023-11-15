using AddressBookTestsWhite.ApplicationManаgers;
using NUnit.Framework;

namespace AddressBookTestsWhite.Tests
{
    public class TestBase
    {
        public ApplicationManаger _applicationManger;

        [SetUp]
        public void InitApplication()
        {
            _applicationManger = new ApplicationManаger();
        }

        [TearDown]
        public void StopApplication()
        {
            _applicationManger.Stop();
        }
    }
}
