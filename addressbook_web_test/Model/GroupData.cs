namespace AddressbookWebTest
{
    public class GroupData
    {
        private string _name;
        private string _header = "";
        private string _footer = "";

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Header
        {
            get { return _header; }
            set { _header = value; }
        }
        public string Footer
        {
            get { return _footer; }
            set { _footer = value; }
        }
        public GroupData(string name)
        {
            _name = name;
        }

        public GroupData(string name, string header, string footer)
        {
            _name = name;
            _header = header;
            _footer = footer;
        }
    }
}
