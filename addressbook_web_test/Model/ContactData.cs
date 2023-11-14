using LinqToDB.Mapping;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AddressbookWebTest
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        [Column(Name = "id"), PrimaryKey]
        public string Id { get; set; }
        [Column(Name = "firstname")]
        public string FirstName { get; set; }
        [Column(Name = "middlename")]
        public string MiddleName { get; set; }
        [Column(Name = "lastname")]
        public string LastName { get; set; }
        private string _fullName;
        public string FullName
        {
            get
            {
                if (_fullName != null)
                {
                    return _fullName;
                }
                return $"{(string.IsNullOrEmpty(FirstName) ? "" : $"{FirstName} ")}" +
                       $"{(string.IsNullOrEmpty(MiddleName) ? "" : $"{MiddleName} ")}" +
                       $"{LastName}";
            }
            set
            {
                _fullName = value;
            }
        }
        [Column(Name = "nickname")]
        public string Nickname { get; set; }
        public string Photo { get; set; }
        [Column(Name = "title")]
        public string Title { get; set; }
        [Column(Name = "company")]
        public string Company { get; set; }
        [Column(Name = "address")]
        public string Address { get; set; }
        public string Home { get; set; }
        public string Mobile { get; set; }
        public string Work { get; set; }
        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }
        private string _allPhones;
        public string AllPhones
        {
            get
            {
                if (_allPhones != null)
                {
                    return _allPhones;
                }
                return $"{CleanUp(Home)}{CleanUp(Mobile)}{CleanUp(Work)}{CleanUp(SecondaryHome)}".Trim();
            }
            set
            {
                _allPhones = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (string.IsNullOrEmpty(phone))
            {
                return "";
            }
            return $"{Regex.Replace(phone, "[ -()]", "")}\r\n";
        }

        public string Fax { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string Homepage { get; set; }
        public string BDay { get; set; }
        public string BMonth { get; set; }
        public string BYear { get; set; }
        public string ADay { get; set; }
        public string AMonth { get; set; }
        public string AYear { get; set; }
        public string Group { get; set; }
        public string SecondaryAddress { get; set; }
        public string SecondaryHome { get; set; }
        public string SecondaryNotes { get; set; }

        private string[] _detailInforamtion;
        public string[] DetailInforamtion
        {
            get
            {
                if (_detailInforamtion != null)
                {
                    return _detailInforamtion;
                }
                return GetDetailInforamtion();
            }
            set
            {
                _detailInforamtion = value;
            }
        }

        private string[] GetDetailInforamtion()
        {
            bool addEmpityRows = false;
            List<string> result = new List<string>();
            if (!string.IsNullOrEmpty(FullName))
            {
                addEmpityRows = true;
                result.Add(FullName);
                result.Add("");
            }
            if (!string.IsNullOrEmpty(Nickname))
            {
                addEmpityRows = true;
                result.Add(Nickname);
                result.Add("");
            }
            if (!string.IsNullOrEmpty(Title))
            {
                addEmpityRows = true;
                result.Add(Title);
                result.Add("");
            }
            if (!string.IsNullOrEmpty(Company))
            {
                addEmpityRows = true;
                result.Add(Company);
                result.Add("");
            }
            if (!string.IsNullOrEmpty(Address))
            {
                addEmpityRows = true;
                result.Add(Address);
                result.Add("");
            }
            if (addEmpityRows)
            {
                result.Add("");
                result.Add("");
                addEmpityRows = false;
            }

            if (!string.IsNullOrEmpty(Home))
            {
                addEmpityRows = true;
                result.Add($"H: {Home}");
                result.Add("");
            }
            if (!string.IsNullOrEmpty(Mobile))
            {
                addEmpityRows = true;
                result.Add($"M: {Mobile}");
                result.Add("");
            }
            if (!string.IsNullOrEmpty(Work))
            {
                addEmpityRows = true;
                result.Add($"W: {Work}");
                result.Add("");
            }
            if (!string.IsNullOrEmpty(Fax))
            {
                addEmpityRows = true;
                result.Add($"F: {Fax}");
                result.Add("");
            }
            if (addEmpityRows)
            {
                result.Add("");
                result.Add("");
                addEmpityRows = false;
            }
            if (!string.IsNullOrEmpty(Email))
            {
                result.Add(Email);
                result.Add("");
                addEmpityRows = true;
            }
            if (!string.IsNullOrEmpty(Email2))
            {
                result.Add(Email2);
                result.Add("");
                addEmpityRows = true;
            }
            if (!string.IsNullOrEmpty(Email3))
            {
                result.Add(Email3);
                result.Add("");
                addEmpityRows = true;
            }
            if (!string.IsNullOrEmpty(Homepage))
            {
                result.Add("Homepage:");
                result.Add("");
                result.Add(Regex.Replace(Homepage, @"^((http|https|ftp)://)", ""));
                result.Add("");
                addEmpityRows = true;
            }
            if (addEmpityRows)
            {
                result.Add("");
                result.Add("");
                addEmpityRows = false;
            }

            int year;
            if (BDay != "0" || BMonth != "-" || !string.IsNullOrEmpty(BYear))
            {
                addEmpityRows = true;
                var birthdayStraing = $"{(BDay == "0" ? "" : $"{BDay} . ")}" +
                                      $"{(BMonth == "-" ? "" : $"{BMonth} ")}" +
                                      $"{(string.IsNullOrEmpty(BYear) ? "" : BYear)}" +
                                      $"{(int.TryParse(BYear, out year) ? $"({(DateTime.Now.Year - year)})" : "")}";
                result.Add($"Birthday {birthdayStraing}");
                result.Add("");
            }
            if (ADay != "0" || AMonth != "-" || !string.IsNullOrEmpty(AYear))
            {
                addEmpityRows = true;
                var birthdayStraing = $"{(ADay == "0" ? "" : $"{ADay} . ")}" +
                                      $"{(AMonth == "-" ? "" : $"{AMonth} ")}" +
                                      $"{(string.IsNullOrEmpty(AYear) ? "" : AYear)}" +
                                      $"{(int.TryParse(AYear, out year) ? $"({(DateTime.Now.Year - year)})" : "")}";
                result.Add($"Birthday {birthdayStraing}");
                result.Add("");
            }
            if (addEmpityRows)
            {
                result.Add("");
                result.Add("");
            }
            if (!string.IsNullOrEmpty(SecondaryAddress))
            {
                result.Add(SecondaryAddress);
                result.Add("");
                result.Add("");
                result.Add("");
            }
            if (!string.IsNullOrEmpty(SecondaryHome))
            {
                result.Add($"P: {SecondaryAddress}");
                result.Add("");
                result.Add("");
                result.Add("");
            }
            if (!string.IsNullOrEmpty(SecondaryNotes))
            {
                result.Add(SecondaryNotes);
            }
            while (string.IsNullOrEmpty(result.Last()))
            {
                result.RemoveAt(result.Count - 1);
            }
            return result.ToArray();
        }

        public ContactData()
        {

        }

        public ContactData(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
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
        public static List<ContactData> GetAll()
        {
            using (AddresBookDB db = new AddresBookDB())
            {
                return (from g in db.Contacts.Where(c => c.Deprecated == "0000-00-00 00:00:00") select g).ToList();
            }
        }

    }
}
