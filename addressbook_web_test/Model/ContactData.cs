using System;
using System.Text.RegularExpressions;

namespace AddressbookWebTest
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
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
        private string allPhones;
        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                return $"{CleanUp(Home)}{CleanUp(Mobile)}{CleanUp(Work)}".Trim();
            }
            set
            {
                allPhones = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (string.IsNullOrEmpty(phone))
            {
                return "";
            }
            return $"{Regex.Replace(phone,"[ -()]","")}\r\n";
        }

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

        public ContactData(string[] row)
        {
            LastName = row[0];
            FirstName = row[1];
        }


        public bool Equals(ContactData other)
        {
            if (other is null)
            {
                return false;
            }
            if (object.ReferenceEquals(other, this))
            {
                return true;
            }
            return ToString() == other.ToString();
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public int CompareTo(ContactData other)
        {
            if (other is null)
            {
                return 1;
            }
            return ToString().CompareTo(other.ToString());
        }

        public override string ToString()
        {
            return $"Фамилия: {LastName} Имя: {FirstName}";
        }
    }
}
