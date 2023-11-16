﻿using MantisTests.AppManager;
using MantisTests.Models;
using NUnit.Framework;
using System;
using System.Text;

namespace MantisTests.Tests
{
    public class TestBase
    {
        public static bool PERFORM_LONG_UI_CHECKS = true;
        protected AccountData _adminAccount;
        protected ApplicationManager _applicationManager;
        private static Random _rnd = new Random();
        [TestFixtureSetUp]
        public void SetupApplicationManager()
        {
            _applicationManager = ApplicationManager.GetInstance();
            _adminAccount = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };
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