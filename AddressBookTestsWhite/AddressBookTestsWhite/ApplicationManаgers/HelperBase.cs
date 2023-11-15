using AddressBookTestsWhite.ApplicationManаgers;

namespace AddressBookTestsWhite.ApplicationManаgers
{
    public class HelperBase
    {
        public static string WINTITLE;

        protected ApplicationManаger _applicationManаger;

        public HelperBase(ApplicationManаger applicationManаger)
        {
            _applicationManаger = applicationManаger;
            WINTITLE = ApplicationManаger.WINTITLE;
        }
    }
}