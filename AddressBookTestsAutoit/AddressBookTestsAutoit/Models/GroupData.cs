using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookTestsAutoit.Models
{
    public class GroupData : IComparable<GroupData>, IEquatable<GroupData>
    {
        public string Name { get; set; }

        public int CompareTo(GroupData other)
        {
            return other.Name.CompareTo(Name);
        }

        public bool Equals(GroupData other)
        {
            return other.Name.Equals(Name);
        }
    }
}
