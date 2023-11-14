namespace AddressbookWebTest
{
    public class AccountData
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public AccountData(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

    }
}
