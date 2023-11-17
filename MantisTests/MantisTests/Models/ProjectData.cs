using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisTests.Models
{
    public class ProjectData : IEquatable<ProjectData>, IComparable<ProjectData>
    {
        public string Name { get;set; }

        public bool Equals(ProjectData other)
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

        public int CompareTo(ProjectData other)
        {
            if (other is null)
            {
                return 1;
            }
            return ToString().CompareTo(other.ToString());
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
