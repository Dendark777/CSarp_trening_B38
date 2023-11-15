using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;

namespace AddressBookTestsWhite.ApplicationManаgers
{
    public class ApplicationManаger
    {
        public static string WINTITLE = "Free Address Book";
        public Window MainWindow { get; private set; }
        private readonly GroupHelper _groupHelper;

        public GroupHelper Groups => _groupHelper;
        public ApplicationManаger()
        {
            Application app = Application.Launch(@"C:\Devs\Courses\software_testing\FreeAddressBookPortable\AddressBook.exe");
            MainWindow = app.GetWindow(WINTITLE);
            _groupHelper = new GroupHelper(this);
        }

        public void Stop()
        {
            MainWindow.Get<Button>("uxExitAddressButton").Click();
        }
    }
}
