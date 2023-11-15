using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AddressBookTestsWhite.Models
{
    public class ContactData : IComparable<ContactData>, IEquatable<ContactData>
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public string Photo { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Home { get; set; }
        public string Mobile { get; set; }
        public string Work { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Homepage { get; set; }
        public string Group { get; set; }

        public int CompareTo(ContactData other)
        {
            if (other is null)
            {
                return 1;
            }
            return ToString().CompareTo(other.ToString());
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


        public override string ToString()
        {
            return $"Фамилия: {LastName} Имя: {FirstName}";
        }
    }
}
