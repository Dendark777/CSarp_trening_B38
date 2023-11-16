using MantisTests.AppManager;
using MantisTests.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisTests.Tests
{
    public class AuthTestBase : TestBase
    {
        [SetUp]
        public void Login()
        {
            _applicationManager.Account.Login(_adminAccount);
        }
    }
}
