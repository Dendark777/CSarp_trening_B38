using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AddressbookWebTest
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
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
        public string Nickname { get; set; }
        public string Photo { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string Home { get; set; }
        public string Mobile { get; set; }
        public string Work { get; set; }
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
        public string BDay;
        public string BMonth;
        public string BYear;
        public string ADay;
        public string AMonth;
        public string AYear;
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
