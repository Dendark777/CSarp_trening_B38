using AddressBookTestsAutoit.ApplicationManаgers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookTestsAutoit.Tests
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
