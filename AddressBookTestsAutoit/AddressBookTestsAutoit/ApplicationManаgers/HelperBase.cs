using AutoItX3Lib;

namespace AddressBookTestsAutoit.ApplicationManаgers
{
    public class HelperBase
    {
        public static string WINTITLE;
        protected readonly AutoItX3 _autoItX3;

        protected ApplicationManаger _applicationManаger;

        public HelperBase(ApplicationManаger applicationManаger)
        {
            _applicationManаger = applicationManаger;
            WINTITLE = ApplicationManаger.WINTITLE;
            _autoItX3 = applicationManаger.AutoItX3;
        }
    }
}