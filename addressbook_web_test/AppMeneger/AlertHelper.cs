using AddressbookWebTest;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_test.AppMeneger
{
    public class AlertHelper : HelperBase
    {
        public AlertHelper(ApplicationManager menager) : base(menager)
        {

        }

        public string CloseAlertAndGetItsText(bool acceptNextAlert)
        {
            IAlert alert = _applicationManager.Driver.SwitchTo().Alert();
            string alertText = alert.Text;
            if (acceptNextAlert)
            {
                alert.Accept();
            }
            else
            {
                alert.Dismiss();
            }
            return alertText;
        }
    }
}
