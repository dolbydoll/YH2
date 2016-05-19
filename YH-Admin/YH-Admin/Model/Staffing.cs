using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YH_Admin.Model
{
    public class Staffing
    {
        private static int NextStaffingId { get; set; }

        public int StaffingId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public String Name { get { return $"{FirstName} {LastName}"; } }

        public Staffing(string firstName, string lastName) : this(NextStaffingId, firstName, lastName)
        {
        }

        public Staffing(int staffingId, string firstName, string lastName)
        {
            if (staffingId >= NextStaffingId)
                NextStaffingId = staffingId + 1;
            StaffingId = staffingId;
            FirstName = firstName;
            LastName = lastName;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Staffing sf = obj as Staffing;
            if ((System.Object)sf == null)
                return false;

            return (StaffingId == sf.StaffingId) && (Name == sf.Name);
        }

        public override int GetHashCode()
        {
            return StaffingId ^ Name.GetHashCode();
        }

        public string GetStaffString()
        {
            return $"Id: {StaffingId}; Name: {Name}";
        }

        public override string ToString()
        {
            return $"{StaffingId} {FirstName} {LastName}";
        }
    }
}


