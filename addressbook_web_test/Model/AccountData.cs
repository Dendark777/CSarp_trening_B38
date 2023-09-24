namespace AddressbookWebTest
{
    public class AccountData
    {
        private string _userName;
        private string _password;

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public AccountData(string userName, string password)
        {
            _userName = userName;
            _password = password;
        }

    }
}
