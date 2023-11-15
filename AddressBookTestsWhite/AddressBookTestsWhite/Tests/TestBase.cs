using AddressBookTestsWhite.ApplicationManаgers;
using NUnit.Framework;
using System.Text;
using System;

namespace AddressBookTestsWhite.Tests
{
    public class TestBase
    {
        public ApplicationManаger _applicationManger;
        private static Random _rnd = new Random();

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

        public static string GenerateRandomString(int max)
        {
            int l = _rnd.Next(max + 1);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                sb.Append(Convert.ToChar(32 + _rnd.Next(66)));
            }
            return sb.ToString();
        }
    }
}
