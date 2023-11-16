using MantisTests.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisTests.Tests
{
    public class TaskCreationTests : TestBase
    {
        [Test]
        public void TaskCreationTest()
        {
            AccountData account = new AccountData()
            {
                Name = "Test7",
                Password = "password",
                Email = "Test7@localhost.localdomain",
            };

            _applicationManager.James.Delete(account);
            _applicationManager.James.Add(account);

            _applicationManager.Account.Register(account);
        }
    }
}
