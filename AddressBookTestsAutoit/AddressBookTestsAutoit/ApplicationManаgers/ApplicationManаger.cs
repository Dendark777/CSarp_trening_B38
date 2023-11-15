using AutoItX3Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookTestsAutoit.ApplicationManаgers
{
    public class ApplicationManаger
    {
        public static string WINTITLE = "Free Address Book";
        private readonly GroupHelper _groupHelper;
        private readonly AutoItX3 _autoItX3;

        public GroupHelper Groups => _groupHelper;
        public AutoItX3 AutoItX3 => _autoItX3;
        public ApplicationManаger()
        {
            _autoItX3 = new AutoItX3();
            _autoItX3.Run(@"C:\Devs\Courses\software_testing\CSarp_trening_B38_Desktop\FreeAddressBookPortable\AddressBook.exe", "", _autoItX3.SW_SHOW);
            _autoItX3.WinWait(WINTITLE);
            _autoItX3.WinActivate(WINTITLE);
            _autoItX3.WinWaitActive(WINTITLE);
            _groupHelper = new GroupHelper(this);
        }

        public void Stop()
        {
            _autoItX3.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d510");
        }
    }
}
