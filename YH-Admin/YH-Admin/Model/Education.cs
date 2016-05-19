using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YH_Admin.Model
{
    public class Education
    {
        public int EducationId { get; set; }

        public string Name { get; set; }

        public int UserId { get; set; }

        public Education(int eId, string name, int uId)
        {
            EducationId = eId;
            Name = name;
            UserId = uId;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Education ed = obj as Education;
            if ((System.Object)ed == null)
                return false;

            // Return true if the fields match:
            return (EducationId == ed.EducationId) && (Name == ed.Name) && (UserId == ed.UserId);
        }

        public override int GetHashCode()
        {
            return EducationId ^ Name.GetHashCode() ^ UserId;
        }

        public override string ToString()
        {
            return $"EducationId: {EducationId}; Name: {Name}; UserId: {UserId}";
        }
    }
}
