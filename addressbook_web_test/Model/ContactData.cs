using System;

namespace AddressbookWebTest
{
    public class ContactData
    {
        public string FirstName { get; set; } = "";
        public string MiddleName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Nickname { get; set; } = "";
        public string Photo { get; set; } = "";
        public string Title { get; set; } = "";
        public string Company { get; set; } = "";
        public string Address { get; set; } = "";
        public string Home { get; set; } = "";
        public string Mobile { get; set; } = "";
        public string Work { get; set; } = "";
        public string Fax { get; set; } = "";
        public string Email { get; set; } = "";
        public string Email2 { get; set; } = "";
        public string Email3 { get; set; } = "";
        public string Homepage { get; set; } = "";
        public DateTime Birthday { get; set; } = DateTime.Now;
        public DateTime Anniversary { get; set; } = DateTime.Now;
        public string Group { get; set; } = "";
        public string SecondaryAddress { get; set; } = "";
        public string SecondaryHome { get; set; } = "";
        public string SecondaryNotes { get; set; } = "";
        public ContactData()
        {

        }

        public ContactData(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
