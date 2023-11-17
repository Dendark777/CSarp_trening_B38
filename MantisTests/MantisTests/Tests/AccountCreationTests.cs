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
            string guid = Guid.NewGuid().ToString();
            AccountData account = new AccountData()
            {
                Name = guid,
                Password = "password",
                Email = $"{guid}@localhost.localdomain",
            };

            _applicationManager.James.Delete(account);
            _applicationManager.James.Add(account);

            _applicationManager.Account.Register(account);

            Assert.True(_applicationManager.Account.CheckAccount(account));
        }

        [TestFixtureTearDown]
        public void RestoreConfig()
        {
            _applicationManager.Ftp.RestoreBackupFile("");
        }

    }
}
