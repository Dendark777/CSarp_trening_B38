using NUnit.Framework;
using System;
using System.Text;

namespace AddressbookWebTest.Tests
{
    public class TestBase
    {
        protected ApplicationManager _applicationManager;
        private static Random _rnd = new Random();

        [SetUp]
        public void SetupApplicationManager()
        {
            _applicationManager = ApplicationManager.GetInstance();
        }

        public static string GenerateRandomString(int max)
        {
            int l = _rnd.Next(max + 1);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                sb.Append(Convert.ToChar(32 + _rnd.Next(224)));
            }
            return sb.ToString();
        }

    }
}
