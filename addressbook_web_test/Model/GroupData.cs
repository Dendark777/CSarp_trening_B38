using System;

namespace AddressbookWebTest
{
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Header { get; set; } = "";
        public string Footer { get; set; } = "";
        public GroupData(string name)
        {
            Name = name;
        }

        public GroupData(string name, string header, string footer)
        {
            Name = name;
            Header = header;
            Footer = footer;
        }

        public bool Equals(GroupData other)
        {
            if (other is null)
            {
                return false;
            }
            if (object.ReferenceEquals(other, this))
            {
                return true;
            }
            return Name == other.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return $"Name={Name}\nHeader={Header}\nFotter={Footer}";
        }

        public int CompareTo(GroupData other)
        {
            if (other is null)
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }
    }
}
