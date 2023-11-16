using MantisTests.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisTests.Tests
{
    [TestFixture]
    public class AccountCreationTests : TestBase
    {
        [TestFixtureSetUp]
        public void SetUpConfig()
        {
            _applicationManager.Ftp.BackupFile(@"config/config_inc.php");
            using (Stream localFile = File.Open("config_inc.php", FileMode.Open))
            {
                _applicationManager.Ftp.Upload(@"config/config_inc.php", localFile);
            }
        }

        [Test]
        public void AccountRegistrtionTest()
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

        [TestFixtureTearDown]
        public void RestoreConfig()
        {
            _applicationManager.Ftp.RestoreBackupFile("");
        }

    }
}
